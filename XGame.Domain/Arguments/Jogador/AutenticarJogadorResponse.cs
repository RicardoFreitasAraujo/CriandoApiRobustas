using System;
using XGame.Domain.Entities;
using XGame.Domain.Enum;
using XGame.Domain.Interfaces.Arguments;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse: IResponse
    {
        public string PrimeiroNome { get; set; }
        public string Email { get; set; }

        public int Status { get; set; }

        public static explicit operator AutenticarJogadorResponse(Entities.Jogador entidade)
        {
            return new AutenticarJogadorResponse()
            {
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                Email = entidade.Email.Endereco,
                Status = (int)entidade.Status
            };
        }
    }
}
