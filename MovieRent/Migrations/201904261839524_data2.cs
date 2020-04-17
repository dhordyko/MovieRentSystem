namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PickUpDate", c => c.String());
            AddColumn("dbo.Orders", "RentPeriod", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "RentPeriod");
            DropColumn("dbo.Orders", "PickUpDate");
        }
    }
}
