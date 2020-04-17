namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dlt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "PickUpDate");
            DropColumn("dbo.Orders", "RentPeriod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "RentPeriod", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "PickUpDate", c => c.DateTime(nullable: false));
        }
    }
}
