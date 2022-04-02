namespace CookiesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Url");
        }
    }
}
