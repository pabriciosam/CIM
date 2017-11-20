using Aplicacao.Interface;
using Dominio.Entidades;
using Dominio.Interfaces.Servico;

namespace Aplicacao
{
    public class AndarAplicacao : AplicacaoBase<Andar>, IAndarAplicacao
    {
        private readonly IAndarServico _andarServico;

        public AndarAplicacao(IAndarServico andarServico) : base(andarServico)
        {
            _andarServico = andarServico;
        }

        public Andar ObterAndarPorNumero(int Numero)
        {
            return _andarServico.ObterAndarPorNumero(Numero);
        }
    }
}