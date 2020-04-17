namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentPeriod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "RentPeriod", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "RentPeriod");
        }
    }
}
