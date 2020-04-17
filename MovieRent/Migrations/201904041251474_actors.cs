namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Actors", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Actors");
        }
    }
}
