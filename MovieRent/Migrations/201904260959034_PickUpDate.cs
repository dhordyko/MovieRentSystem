namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PickUpDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PickUpDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PickUpDate");
        }
    }
}
