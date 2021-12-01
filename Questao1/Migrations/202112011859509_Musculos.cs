namespace Questao1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Musculos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atividades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Serie = c.String(),
                        Descricao = c.String(),
                        Repeticao = c.Int(nullable: false),
                        Peso = c.Double(nullable: false),
                        FichaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fichas", t => t.FichaId, cascadeDelete: true)
                .Index(t => t.FichaId);
            
            CreateTable(
                "dbo.Fichas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataCriacao = c.DateTime(),
                        NomeInstrutor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Sexo = c.String(),
                        Idade = c.Int(nullable: false),
                        Peso = c.Double(nullable: false),
                        Altura = c.Double(nullable: false),
                        IMC = c.Double(nullable: false),
                        FichaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fichas", t => t.FichaId, cascadeDelete: true)
                .Index(t => t.FichaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "FichaId", "dbo.Fichas");
            DropForeignKey("dbo.Atividades", "FichaId", "dbo.Fichas");
            DropIndex("dbo.Usuarios", new[] { "FichaId" });
            DropIndex("dbo.Atividades", new[] { "FichaId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Fichas");
            DropTable("dbo.Atividades");
        }
    }
}
