using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Servico;

namespace Dominio.Servicos
{
    public class AndarServico : ServicoBase<Andar>, IAndarServico
    {
        private readonly IAndarRepositorio _andarRepositorio;

        public AndarServico(IAndarRepositorio andarRepositorio) : base(andarRepositorio)
        {
            _andarRepositorio = andarRepositorio;
        }

        public Andar ObterAndarPorNumero(int Numero)
        {
            return _andarRepositorio.ObterAndarPorNumero(Numero);
        }
    }
}