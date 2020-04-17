namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frgnkeyorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerId_Id", c => c.Int());
            CreateIndex("dbo.Orders", "CustomerId_Id");
            AddForeignKey("dbo.Orders", "CustomerId_Id", "dbo.Customers", "Id");
            DropColumn("dbo.Orders", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CustomerId", c => c.Int());
            DropForeignKey("dbo.Orders", "CustomerId_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerId_Id" });
            DropColumn("dbo.Orders", "CustomerId_Id");
        }
    }
}
