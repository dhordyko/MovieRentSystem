namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ords1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Cena", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "Cena");
        }
    }
}
