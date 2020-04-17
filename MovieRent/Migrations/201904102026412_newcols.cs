namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcols : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SecondName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Phone", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Phone");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Customers", "SecondName");
        }
    }
}
