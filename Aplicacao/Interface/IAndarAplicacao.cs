using Dominio.Entidades;

namespace Aplicacao.Interface
{
    public interface IAndarAplicacao : IAplicacaoBase<Andar>
    {
        Andar ObterAndarPorNumero(int Numero);
    }
}
