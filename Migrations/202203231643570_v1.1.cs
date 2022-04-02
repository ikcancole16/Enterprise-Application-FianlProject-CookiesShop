namespace CookiesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductName = c.String(),
                        Price = c.Double(nullable: false),
                        CakeType = c.String(),
                        CreanType = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        Description = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "ShippingAddress", c => c.String());
            AddColumn("dbo.Orders", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ProductId");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "FirstName");
            DropColumn("dbo.Orders", "LastName");
            DropColumn("dbo.Orders", "DateOfBirth");
            DropColumn("dbo.Orders", "Phone");
            DropColumn("dbo.Orders", "Message");
            DropColumn("dbo.Orders", "ProductNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProductNo", c => c.String());
            AddColumn("dbo.Orders", "Message", c => c.String());
            AddColumn("dbo.Orders", "Phone", c => c.String());
            AddColumn("dbo.Orders", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "LastName", c => c.String());
            AddColumn("dbo.Orders", "FirstName", c => c.String());
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ProductId" });
            AlterColumn("dbo.Orders", "Quantity", c => c.String());
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Orders", "ProductId");
            DropColumn("dbo.Orders", "CreatedAt");
            DropColumn("dbo.Orders", "ShippingAddress");
            DropTable("dbo.Products");
        }
    }
}
