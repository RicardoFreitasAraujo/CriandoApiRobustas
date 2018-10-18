using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;
using XGame.Domain.ValueObjects;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Iniciando...");

            var service = new ServiceJogador();
            Console.Write("Criei instância do serviço");

            //AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            //Console.Write("Criei instância do meu objeto request");
            //request.Email = "paulo@paulo.com";
            //request.Senha = "123456789";

            /*
            var request = new AdicionarJogadorRequest()
            {
                Email = new Email("paulo.analista@outlook.com"),
                Nome = new Nome("Ricardo","Freitas"),
                Senha = "123456"
            };



            var response = service.AdicionarJogador(request);
            */
            
            
            
            //var response = service.AutenticarJogador(request);
            
            Console.ReadKey();
        }
    }
}
