namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "isSubsribedtoNewsLetter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "isSubsribedtoNewsLetter", c => c.Boolean(nullable: false));
        }
    }
}
