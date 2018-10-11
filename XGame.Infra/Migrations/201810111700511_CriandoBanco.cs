namespace XGame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogador",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PrimeiroNome = c.String(maxLength: 50, unicode: false),
                        UltimoNome = c.String(maxLength: 50, unicode: false),
                        Email_Endereco = c.String(nullable: false, maxLength: 200, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 100, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plataforma",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Plataforma");
            DropTable("dbo.Jogador");
        }
    }
}
