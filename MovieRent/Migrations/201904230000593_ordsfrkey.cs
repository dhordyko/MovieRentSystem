namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordsfrkey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "CustomerId_Id", newName: "CustomerId");
            RenameIndex(table: "dbo.Orders", name: "IX_CustomerId_Id", newName: "IX_CustomerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_CustomerId", newName: "IX_CustomerId_Id");
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "CustomerId_Id");
        }
    }
}
