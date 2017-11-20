using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Servico;
using System.Collections.Generic;

namespace Dominio.Servicos
{
    public class EquipamentoServico : ServicoBase<Equipamento>, IEquipamentoServico
    {
        private readonly IEquipamentoRepositorio _equipamentoRepositorio;

        public EquipamentoServico(IEquipamentoRepositorio equipamentoRepositorio) : base(equipamentoRepositorio)
        {
            _equipamentoRepositorio = equipamentoRepositorio;
        }

        public IEnumerable<Equipamento> ObterEquipamentosLivres()
        {
            return _equipamentoRepositorio.ObterEquipamentosLivres();
        }

        public IEnumerable<Equipamento> ObterEquipamentosImobilizados()
        {
            return _equipamentoRepositorio.ObterEquipamentosImobilizados();
        }
    }
}