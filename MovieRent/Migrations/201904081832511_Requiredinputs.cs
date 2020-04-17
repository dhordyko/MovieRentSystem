namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requiredinputs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Actors", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Director", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Duration", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Duration", c => c.String());
            AlterColumn("dbo.Movies", "Director", c => c.String());
            AlterColumn("dbo.Movies", "Actors", c => c.String());
        }
    }
}
