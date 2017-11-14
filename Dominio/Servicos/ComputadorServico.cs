using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Servico;

namespace Dominio.Servicos
{
    public class ComputadorServico : ServicoBase<Computador>, IComputadorServico
    {
        private readonly IComputadorRepositorio _comptadorRepositorio;

        public ComputadorServico(IComputadorRepositorio comptadorRepositorio) : base(comptadorRepositorio)
        {
            _comptadorRepositorio = comptadorRepositorio;
        }
    }
}