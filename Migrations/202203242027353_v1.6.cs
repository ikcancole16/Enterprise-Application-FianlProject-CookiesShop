namespace CookiesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order_Product", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Order_Product", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Order_Product", "Price");
            DropColumn("dbo.Order_Product", "Quantity");
        }
    }
}
