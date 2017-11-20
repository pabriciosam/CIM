using Dominio.Entidades;
using Xunit;

namespace TestesAutomatizados
{
    public class EquipamentoTeste
    {
        [Fact]
        public void RetornaVerdadeiroSeEquipamentoPossuirNome()
        {
            Equipamento equipamento = RetornaInstanciaDeEquipamento();

            Assert.True(equipamento.PossuiNome());
        }

        [Fact]
        public void RetornaFalseSeEquipamentoNaoPossuirNome()
        {
            Equipamento equipamento = RetornaEquipamentoSemNome();

            Assert.False(equipamento.PossuiNome());
        }

        [Fact]
        public void RetornaVerdadeiroSeEquipamentoPossuirTipoEquipamento()
        {
            Equipamento equipamento = RetornaInstanciaDeEquipamento();

            Assert.True(equipamento.PossuiTipoEquipamento());
        }

        [Fact]
        public void RetornaFalseSeEquipamentoNaoPossuirTipoEquipamento()
        {
            Equipamento equipamento = RetornaEquipamentoSemTipoEquipamento();

            Assert.False(equipamento.PossuiTipoEquipamento());
        }

        private Equipamento RetornaInstanciaDeEquipamento()
        {
            return new Equipamento()
            {
                Nome = "Imp01",
                Descricao = "Impressora do primeiro andar",
                Andar = 1,
                TipoEquipamento = "Impressora"
            };
        }

        private Equipamento RetornaEquipamentoSemNome()
        {
            return new Equipamento()
            {
                Nome = null,
                Descricao = "Impressora do primeiro andar",
                Andar = 1,
                TipoEquipamento = "Impressora"
            };
        }
        
        private Equipamento RetornaEquipamentoSemTipoEquipamento()
        {
            return new Equipamento()
            {
                Nome = "Imp01",
                Descricao = "Impressora do primeiro andar",
                Andar = 1,
                TipoEquipamento = null
            };
        }
    }
}
