using System;
using XGame.Domain.Entities.Base;

namespace XGame.Domain.Entities
{
    public class JogoPlataforma: EntityBase
    {
        public Jogo Jogo { get; set; }
        public Plataforma Plataforma { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
