using Dominio.Entidades;

namespace CIM
{
    public class Validacao
    {
        public enum Operacao
        {
            Inclusao = 1,
            Alteracao = 2
        }

        public string ValidarEquipamento(Equipamento equipamento, Operacao operacao)
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
    }
}