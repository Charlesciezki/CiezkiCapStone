namespace CCiezkiCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventoryv4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryModels", "url", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InventoryModels", "url");
        }
    }
}
