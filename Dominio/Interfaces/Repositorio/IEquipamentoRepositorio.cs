using Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Interfaces.Repositorio
{
    public interface IEquipamentoRepositorio : IRepositorioBase<Equipamento>
    {
        IEnumerable<Equipamento> ObterEquipamentosLivres();
        IEnumerable<Equipamento> ObterEquipamentosImobilizados();
    }
}