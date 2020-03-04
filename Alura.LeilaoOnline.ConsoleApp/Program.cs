using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleApp
{

    class Program
    {
        private static void LeilaoComVariosLances (){

            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 950);

            leilao.TerminaPregao();

            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Assert(valorEsperado, valorObtido);
        }
        private static void LeilaoComApenasUmLance()
        {
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.RecebeLance(fulano, 800);

            leilao.TerminaPregao();

            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Assert(valorEsperado, valorObtido);

            
        }

        private static void Assert(double esperado, double obtido)
        {
            var corConsole = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste Passou!");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Teste Falhou. \nEsperado: {esperado}, Obtido: {obtido}.");
                Console.ReadKey();
            }
            Console.ForegroundColor = corConsole;
        }

        static void Main(string[] args)
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }

        
    }
}
