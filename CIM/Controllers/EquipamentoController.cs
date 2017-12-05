using Aplicacao.Interface;
using Dominio.Entidades;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CIM.Controllers
{
    [RoutePrefix("api/v1")]
    public class EquipamentoController : ApiController
    {
        private readonly IEquipamentoAplicacao _equipamentoAplicacao;
        private readonly IAndarAplicacao _andarAplicacao;
        private readonly Validacao _validacao = new Validacao();
        private readonly TrataExcessoes _trataExcessoes = new TrataExcessoes();

        public EquipamentoController(IEquipamentoAplicacao equipamentoAplicacao, IAndarAplicacao andarAplicacao)
        {
            _equipamentoAplicacao = equipamentoAplicacao;
            _andarAplicacao = andarAplicacao;
        }

        [HttpPost]
        [Route("equipamentos")]
        public HttpResponseMessage InserirEquipamento(Equipamento equipamento)
        {
            try
            {
                if (equipamento == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não é possível inserir equipamento nulo.");
                else
                {
                    var retorno = _validacao.ValidarEquipamento(equipamento, Validacao.Operacao.Inclusao);

                    if (!string.IsNullOrWhiteSpace(retorno))
                        return Request.CreateResponse(HttpStatusCode.BadRequest, retorno);

                    var retornoAcesso = _equipamentoAplicacao.ValidarAcessos(equipamento.EquipamentosAcessados);

                    if (!string.IsNullOrWhiteSpace(retornoAcesso))
                        return Request.CreateResponse(HttpStatusCode.BadRequest, retornoAcesso);

                    return Request.CreateResponse(HttpStatusCode.OK, _equipamentoAplicacao.Inserir(equipamento));
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao inserir equipamento. " + _trataExcessoes.RetornaTodasAsExcessoes(ex));
            }
        }

        [HttpPut]
        [Route("equipamentos")]
        public HttpResponseMessage AtualizarEquipamento(Equipamento equipamento)
        {
            try
            {
                if (equipamento == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não é possível alterar equipamento nulo.");
                else
                {
                    var retorno = _validacao.ValidarEquipamento(equipamento, Validacao.Operacao.Alteracao);

                    if (!string.IsNullOrWhiteSpace(retorno))
                        return Request.CreateResponse(HttpStatusCode.BadRequest, retorno);

                    var retornoAcesso = _equipamentoAplicacao.ValidarAcessos(equipamento.EquipamentosAcessados);

                    if (!string.IsNullOrWhiteSpace(retornoAcesso))
                        return Request.CreateResponse(HttpStatusCode.BadRequest, retornoAcesso);

                    _equipamentoAplicacao.Atualizar(equipamento);

                    return Request.CreateResponse(HttpStatusCode.OK, "Equipamento alterado.");
                }   
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao alterar equipamento. " + _trataExcessoes.RetornaTodasAsExcessoes(ex));
            }
        }

        [HttpDelete]
        [Route("equipamentos")]
        public HttpResponseMessage ExcluirEquipamento(string id)
        {
            try
            {
                if (id == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Informe o ID do equipamento a ser excluído.");
                else
                {
                    _equipamentoAplicacao.Excluir(id);

                    return Request.CreateResponse(HttpStatusCode.OK, "Equipamento excluído.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao excluir equipamento. " + _trataExcessoes.RetornaTodasAsExcessoes(ex));
            }
        }

        [HttpGet]
        [Route("equipamentos")]
        public HttpResponseMessage ObterTodosEquipamentos()
        {
            try
            {
                var equipamentos = _equipamentoAplicacao.ObterTodos();

                if (equipamentos == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum equipamento encontrado.");

                return Request.CreateResponse(HttpStatusCode.OK, equipamentos);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao obter todos os equipamentos. " + _trataExcessoes.RetornaTodasAsExcessoes(ex));
            }
        }

        [HttpGet]
        [Route("equipamentos/{ID}")]
        public HttpResponseMessage ObterEquipamentoPorId(string id)
        {
            try
            {
                var equipamento = _equipamentoAplicacao.ObterPorId(id);

                if (equipamento == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum equipamento encontrado.");

                return Request.CreateResponse(HttpStatusCode.OK, equipamento);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao obter o equipamento: " + id + _trataExcessoes.RetornaTodasAsExcessoes(ex));
            }
        }

        [HttpGet]
        [Route("equipamentos/livres")]
        public HttpResponseMessage ObterEquipamentosLivres()
        {
            try
            {
                var equipamentos = _equipamentoAplicacao.ObterEquipamentosLivres();

                if (equipamentos == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum equipamento encontrado.");

                return Request.CreateResponse(HttpStatusCode.OK, equipamentos);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter equipamentos livres: " + _trataExcessoes.RetornaTodasAsExcessoes(ex));
            }
        }

        [HttpGet]
        [Route("equipamentos/imobilizados")]
        public HttpResponseMessage ObterEquipamentosImobilizados()
        {
            try
            {
                var equipamentos = _equipamentoAplicacao.ObterEquipamentosImobilizados();

                if (equipamentos == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum equipamento encontrado.");

                return Request.CreateResponse(HttpStatusCode.OK, equipamentos);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter equipamentos imobilizados: " + _trataExcessoes.RetornaTodasAsExcessoes(ex));
            }
        }
    }
}