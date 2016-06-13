namespace CCiezkiCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixinginventory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InventoryModels", "url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InventoryModels", "url", c => c.Int(nullable: false));
        }
    }
}
