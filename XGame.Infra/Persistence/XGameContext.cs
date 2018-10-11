using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XGame.Domain.Entities;
using XGame.Infra.Persistence.Map;

namespace XGame.Infra.Persistence
{
    public class XGameContext: DbContext
    {
        public XGameContext(): base("XGameConnectionString")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        #region DbSets
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Seta SCHEMA default
            //modelBuilder.HasDefaultSchema("Apoio");

            //Remover a pluralização dos nomes de tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Remover exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Setar para usar varchar ao invés de nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Caso eu esqueça de informar o tamanho do campo le irá colocar varchar de 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //Mapeia as entidades
            modelBuilder.Configurations.Add(new MapJogador());

            base.OnModelCreating(modelBuilder);
        }
    }
}
