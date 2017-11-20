using Dominio.Entidades;
using System.Collections.Generic;

namespace Aplicacao.Interface
{
    public interface IEquipamentoAplicacao : IAplicacaoBase<Equipamento>
    {
        IEnumerable<Equipamento> ObterEquipamentosLivres();
        IEnumerable<Equipamento> ObterEquipamentosImobilizados();

        string ValidarAcessos(List<string> equipamentosAcessados);
    }
}