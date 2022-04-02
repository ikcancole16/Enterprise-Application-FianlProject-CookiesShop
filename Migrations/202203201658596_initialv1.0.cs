namespace CookiesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialv10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "DateOfBirth");
        }
    }
}
