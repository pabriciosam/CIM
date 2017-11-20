using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Infraestrutura.Repositorios
{
    public class EquipamentoRepositorio : RepositorioBase<Equipamento>, IEquipamentoRepositorio
    {
        public IEnumerable<Equipamento> ObterEquipamentosLivres()
        {
            return ObterEquipamentosPorStatus(true);
        }

        public IEnumerable<Equipamento> ObterEquipamentosImobilizados()
        {
            return ObterEquipamentosPorStatus(false);
        }

        private IEnumerable<Equipamento> ObterEquipamentosPorStatus(bool status)
        {
            var filtro = Builders<Equipamento>.Filter.Eq("StatusAcesso", status);

            return colecao.Find(filtro).ToList();
        }
    }
}