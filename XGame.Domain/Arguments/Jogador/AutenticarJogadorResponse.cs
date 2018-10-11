using XGame.Domain.Interfaces.Arguments;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse: IResponse
    {
        public string PrimeiroNome { get; set; }
        public string Email { get; set; }

        public int Status { get; set; }
    }
}
