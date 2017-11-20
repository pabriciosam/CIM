using Dominio.Entidades;
using Dominio.Interface.Servico;

namespace Dominio.Interfaces.Servico
{
    public interface IAndarServico : IServicoBase<Andar>
    {
        Andar ObterAndarPorNumero(int Numero);
    }
}