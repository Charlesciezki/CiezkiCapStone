namespace CCiezkiCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventoryv3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FullcalendarModels", "start");
            DropColumn("dbo.FullcalendarModels", "end");
            DropColumn("dbo.FullcalendarModels", "url");
            DropColumn("dbo.FullcalendarModels", "description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FullcalendarModels", "description", c => c.String(nullable: false));
            AddColumn("dbo.FullcalendarModels", "url", c => c.String());
            AddColumn("dbo.FullcalendarModels", "end", c => c.String());
            AddColumn("dbo.FullcalendarModels", "start", c => c.String(nullable: false));
        }
    }
}
