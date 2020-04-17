namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ords : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Cena");
            DropColumn("dbo.Orders", "OrderDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Cena", c => c.Int(nullable: false));
        }
    }
}
