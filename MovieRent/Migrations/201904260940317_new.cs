namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "DeliveryMode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "DeliveryMode", c => c.String(nullable: false));
        }
    }
}
