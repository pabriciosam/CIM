using Aplicacao.Interface;
using Dominio.Entidades;
using Dominio.Interfaces.Servico;

namespace Aplicacao
{
    public class ComputadorAplicacao : AplicacaoBase<Computador>, IComputadorAplicacao
    {
        private readonly IComputadorServico _computadorServico;

        public ComputadorAplicacao(IComputadorServico computadorServico) : base(computadorServico)
        {
            _computadorServico = computadorServico;
        }
    }
}