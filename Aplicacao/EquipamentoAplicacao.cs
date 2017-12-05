using Aplicacao.Interface;
using Dominio.Entidades;
using Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;

namespace Aplicacao
{
    public class EquipamentoAplicacao : AplicacaoBase<Equipamento>, IEquipamentoAplicacao
    {
        private readonly IEquipamentoServico _equipamentoServico;
        private readonly IAndarAplicacao _andarAplicacao;

        public EquipamentoAplicacao(IEquipamentoServico equipamentoServico, IAndarAplicacao andarAplicacao) : base(equipamentoServico)
        {
            _equipamentoServico = equipamentoServico;
            _andarAplicacao = andarAplicacao;
        }

        public IEnumerable<Equipamento> ObterEquipamentosLivres()
        {
            return _equipamentoServico.ObterEquipamentosLivres();
        }

        public IEnumerable<Equipamento> ObterEquipamentosImobilizados()
        {
            return _equipamentoServico.ObterEquipamentosImobilizados();
        }

        public string ValidarAcessos(List<string> equipamentosAcessados)
        {
            try
            {
                string equipamentosImobilizados = string.Empty;
                string equipamentoEmAndarPrivado = string.Empty;

                foreach (var equipamentoId in equipamentosAcessados)
                {
                    var equipamento = _equipamentoServico.ObterPorId(equipamentoId);

                    if (equipamento.Andar.Privado)
                        equipamentoEmAndarPrivado += equipamentoId + " - ";
                    else if (!equipamento.StatusAcesso)
                        equipamentosImobilizados += equipamentoId + " - ";
                }

                var retorno = string.IsNullOrWhiteSpace(equipamentosImobilizados) ? string.Empty : "Equipamentos imobilizados: " + equipamentosImobilizados.Substring(0, equipamentosImobilizados.Length - 3) + " ";

                retorno += string.IsNullOrWhiteSpace(equipamentoEmAndarPrivado) ? string.Empty : "Equipamentos em andar privado: " + equipamentoEmAndarPrivado.Substring(0, equipamentoEmAndarPrivado.Length - 3);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception("EquipamentoAplicacao: Erro ao validar acessos. ", ex);
            }
            
        }
    }
}