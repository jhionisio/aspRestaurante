namespace Restaurante.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cardapios", "nomePrato", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cardapios", "nomePrato", c => c.String());
        }
    }
}
