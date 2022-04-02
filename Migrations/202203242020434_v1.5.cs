﻿namespace CookiesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Note");
        }
    }
}
