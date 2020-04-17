namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orders_chngs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "AbonementType_Id", "dbo.MembershipTypes");
            DropForeignKey("dbo.Orders", "CustomerId_Id", "dbo.Customers");
            DropForeignKey("dbo.Orders", "MovieId_Id", "dbo.Movies");
            DropIndex("dbo.Orders", new[] { "AbonementType_Id" });
            DropIndex("dbo.Orders", new[] { "CustomerId_Id" });
            DropIndex("dbo.Orders", new[] { "MovieId_Id" });
            AddColumn("dbo.Orders", "MovieId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "AbonementType", c => c.String());
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "AbonementType_Id");
            DropColumn("dbo.Orders", "CustomerId_Id");
            DropColumn("dbo.Orders", "MovieId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "MovieId_Id", c => c.Int());
            AddColumn("dbo.Orders", "CustomerId_Id", c => c.Int());
            AddColumn("dbo.Orders", "AbonementType_Id", c => c.Byte());
            DropColumn("dbo.Orders", "CustomerId");
            DropColumn("dbo.Orders", "AbonementType");
            DropColumn("dbo.Orders", "MovieId");
            CreateIndex("dbo.Orders", "MovieId_Id");
            CreateIndex("dbo.Orders", "CustomerId_Id");
            CreateIndex("dbo.Orders", "AbonementType_Id");
            AddForeignKey("dbo.Orders", "MovieId_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Orders", "CustomerId_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Orders", "AbonementType_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
