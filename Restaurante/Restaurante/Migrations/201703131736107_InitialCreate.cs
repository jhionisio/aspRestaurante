namespace Restaurante.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        RestauranteId = c.Int(nullable: false, identity: true),
                        NomeRestaurante = c.String(),
                    })
                .PrimaryKey(t => t.RestauranteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurantes");
        }
    }
}
