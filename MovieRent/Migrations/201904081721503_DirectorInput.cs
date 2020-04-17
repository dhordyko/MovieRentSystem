namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DirectorInput : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Director", c => c.String());
            AddColumn("dbo.Movies", "Duration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Duration");
            DropColumn("dbo.Movies", "Director");
        }
    }
}
