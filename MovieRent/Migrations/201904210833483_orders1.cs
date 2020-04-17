namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orders1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerId_Id", c => c.Int());
            AddColumn("dbo.Orders", "MovieId_Id", c => c.Int());
            CreateIndex("dbo.Orders", "CustomerId_Id");
            CreateIndex("dbo.Orders", "MovieId_Id");
            AddForeignKey("dbo.Orders", "CustomerId_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Orders", "MovieId_Id", "dbo.Movies", "Id");
            DropColumn("dbo.Orders", "MovieId");
            DropColumn("dbo.Orders", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CustomerId", c => c.String());
            AddColumn("dbo.Orders", "MovieId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "MovieId_Id", "dbo.Movies");
            DropForeignKey("dbo.Orders", "CustomerId_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "MovieId_Id" });
            DropIndex("dbo.Orders", new[] { "CustomerId_Id" });
            DropColumn("dbo.Orders", "MovieId_Id");
            DropColumn("dbo.Orders", "CustomerId_Id");
        }
    }
}
