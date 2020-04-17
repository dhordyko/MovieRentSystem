namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordernmbadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderNmb", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderNmb");
        }
    }
}
