namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pickupdt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "PickUpDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "PickUpDate", c => c.String());
        }
    }
}
