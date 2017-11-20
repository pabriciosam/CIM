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

        enum Operacao
        {
            Inclusao = 1,
            Alteracao = 2
        }

        public EquipamentoController(IEquipamentoAplicacao equipamentoAplicacao, IAndarAplicacao andarAplicacao)
        {
            _equipamentoAplicacao = equipamentoAplicacao;
            _andarAplicacao = andarAplicacao;
        }

        [HttpPost]
        [Route("equipamento")]
        public HttpResponseMessage InserirEquipamento(Equipamento equipamento)
        {
            try
            {
                if (equipamento == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não é possível inserir equipamento nulo.");
                else
                {
                    var retorno = Validar(equipamento, Operacao.Inclusao);

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
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao inserir equipamento. " + TodasAsExcessoes(ex));
            }
        }

        [HttpPut]
        [Route("equipamento")]
        public HttpResponseMessage AtualizarEquipamento(Equipamento equipamento)
        {
            try
            {
                if (equipamento == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não é possível alterar equipamento nulo.");
                else
                {
                    var retorno = Validar(equipamento, Operacao.Alteracao);

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
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao alterar equipamento. " + TodasAsExcessoes(ex));
            }
        }

        [HttpDelete]
        [Route("equipamento")]
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro ao excluir equipamento. " + TodasAsExcessoes(ex));
            }
        }

        [HttpGet]
        [Route("equipamento")]
        public HttpResponseMessage ObterTodosEquipamentos()
        {
            var equipamentos = _equipamentoAplicacao.ObterTodos();

            if (equipamentos == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum equipamento encontrado.");

            return Request.CreateResponse(HttpStatusCode.OK, equipamentos);
        }

        [HttpGet]
        [Route("equipamento/{ID}")]
        public HttpResponseMessage ObterEquipamentoPorId(string id)
        {
            var equipamento = _equipamentoAplicacao.ObterPorId(id);

            if (equipamento == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum equipamento encontrado.");

            return Request.CreateResponse(HttpStatusCode.OK, equipamento);
        }

        [HttpGet]
        [Route("equipamento/livre")]
        public HttpResponseMessage ObterEquipamentosLivres()
        {
            var equipamentos = _equipamentoAplicacao.ObterEquipamentosLivres();

            if (equipamentos == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum equipamento encontrado.");

            return Request.CreateResponse(HttpStatusCode.OK, equipamentos);
        }

        [HttpGet]
        [Route("equipamento/imobilizado")]
        public HttpResponseMessage ObterEquipamentosImobilizados()
        {
            var equipamentos = _equipamentoAplicacao.ObterEquipamentosImobilizados();

            if (equipamentos == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum equipamento encontrado.");

            return Request.CreateResponse(HttpStatusCode.OK, equipamentos);
        }

        private string Validar(Equipamento equipamento, Operacao operacao)
        {
            string retorno = null;

            if ((operacao == Operacao.Alteracao) && string.IsNullOrWhiteSpace(equipamento.Id))
                retorno = "Informe o ID do equipamento a ser alterado.";

            if (!equipamento.PossuiNome())
                retorno += " Informe o nome do equipamento.";

            if (!equipamento.PossuiTipoEquipamento())
                retorno += " Informe o tipo do equipamento.";

            return retorno;
        }

        private string TodasAsExcessoes(Exception ex)
        {
            var mensagem = String.Empty;

            while (ex != null)
            {
                mensagem += ex.Message;
                ex = ex.InnerException;
            }

            return mensagem;
        }
    }
}
