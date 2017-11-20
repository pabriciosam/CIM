using Dominio.Entidades;

namespace Dominio.Interfaces.Repositorio
{
    public interface IAndarRepositorio : IRepositorioBase<Andar>
    {
        Andar ObterAndarPorNumero(int Numero);
    }
}