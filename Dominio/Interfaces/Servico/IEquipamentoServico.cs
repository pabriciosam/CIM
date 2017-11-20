using Dominio.Entidades;
using Dominio.Interface.Servico;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servico
{
    public interface IEquipamentoServico : IServicoBase<Equipamento>
    {
        IEnumerable<Equipamento> ObterEquipamentosLivres();
        IEnumerable<Equipamento> ObterEquipamentosImobilizados();
    }
}