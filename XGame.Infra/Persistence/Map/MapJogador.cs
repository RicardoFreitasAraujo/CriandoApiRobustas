using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence.Map
{
    public class MapJogador: EntityTypeConfiguration<Jogador>
    {
        public MapJogador()
        {
            this.ToTable("Jogador");

            this.Property(p => p.Email.Endereco)
                    .HasMaxLength(200)
                    .IsRequired();

            this.Property(p => p.Nome.PrimeiroNome).HasMaxLength(50).HasColumnName("PrimeiroNome");
            this.Property(p => p.Nome.UltimoNome).HasMaxLength(50).HasColumnName("UltimoNome");
            this.Property(p => p.Senha).IsRequired();
            this.Property(p => p.Status).IsRequired();
        }
    }
}
