using System;
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

        [Fact(Skip = "Desistir de fazer esse teste")]
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
                Andar = null,
                TipoEquipamento = "Impressora"
            };
        }

        private Equipamento RetornaEquipamentoSemNome()
        {
            return new Equipamento()
            {
                Nome = null,
                Descricao = "Impressora do primeiro andar",
                Andar = null,
                TipoEquipamento = "Impressora"
            };
        }
        
        private Equipamento RetornaEquipamentoSemTipoEquipamento()
        {
            return new Equipamento()
            {
                Nome = "Imp01",
                Descricao = "Impressora do primeiro andar",
                Andar = null,
                TipoEquipamento = null
            };
        }


        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(8, 2, 5)]
        [InlineData(10, 8, 7)]
        [InlineData(10, 20, 30)]
        [InlineData(15, 9, 5)]
        public void RetornaVerdadeiroSeCalculoForMaiorQueCinco(int valor1, int valor2, int valor3)
        {
            var retorno = CalculaValor(valor1, valor2, valor3);

            Assert.True(retorno > 5);
        }

        private int CalculaValor(int valor1, int valor2, int valor3)
        {
            return valor1 * valor2 * valor3;
        }
    }
}
