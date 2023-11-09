namespace Restaurante.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Chavesestrangeiras2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cardapios", "Restaurante_RestauranteId", c => c.Int());
            CreateIndex("dbo.Cardapios", "Restaurante_RestauranteId");
            AddForeignKey("dbo.Cardapios", "Restaurante_RestauranteId", "dbo.Restaurantes", "RestauranteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cardapios", "Restaurante_RestauranteId", "dbo.Restaurantes");
            DropIndex("dbo.Cardapios", new[] { "Restaurante_RestauranteId" });
            DropColumn("dbo.Cardapios", "Restaurante_RestauranteId");
        }
    }
}
