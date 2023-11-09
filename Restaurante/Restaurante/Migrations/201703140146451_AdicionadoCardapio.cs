namespace Restaurante.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoCardapio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cardapios",
                c => new
                    {
                        CardapioId = c.Int(nullable: false, identity: true),
                        nomePrato = c.String(),
                        valorPrato = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CardapioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cardapios");
        }
    }
}
