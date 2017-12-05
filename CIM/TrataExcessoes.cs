using System;

namespace CIM
{
    public class TrataExcessoes
    {
        public string RetornaTodasAsExcessoes(Exception ex)
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