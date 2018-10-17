using System;
using XGame.Domain.Entities.Base;

namespace XGame.Domain.Entities
{
    public class Jogo: EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Produtora { get; set; }
        public string Distribuidora { get; set; }
        public string Genero { get; set; }
        public string Site { get; set; }

    }
}
