namespace CCiezkiCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InventoryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        productName = c.String(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                        warningSent = c.Int(nullable: false),
                        warningLevel = c.Int(nullable: false),
                        refillLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InventoryModels");
        }
    }
}
