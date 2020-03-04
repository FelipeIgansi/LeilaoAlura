using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
  
        [Theory]
        [InlineData(1000, new double[] { 800, 900, 1000, 980 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 1400 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMeiorValorComPeloMenosUmLance(
            double valorEsperado,
            double[] ofertas)
        {

            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
                leilao.RecebeLance(fulano, valor);
            }

            leilao.TerminaPregao();

            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }





        [Fact]
        public void RetornaZeroCasoLeilaoSemLances()
        {
            var leilao = new Leilao("Van Gogh");


            leilao.TerminaPregao();

            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);


        }




        


    }
}
