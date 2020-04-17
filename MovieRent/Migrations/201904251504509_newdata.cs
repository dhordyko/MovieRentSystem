namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PickUpDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "DeliveryMode", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "RentPeriod", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "RentPeriod");
            DropColumn("dbo.Orders", "DeliveryMode");
            DropColumn("dbo.Orders", "PickUpDate");
        }
    }
}
