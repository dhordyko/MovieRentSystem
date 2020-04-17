namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countriesseed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Countries (Id, Name) VALUES(1, 'USA' ); ");
            Sql("INSERT INTO dbo.Countries (Id, Name) VALUES(2, 'Italy' ); ");
            Sql("INSERT INTO dbo.Countries (Id, Name) VALUES(3, 'UK' ); ");
            Sql("INSERT INTO dbo.Countries (Id, Name) VALUES(4, 'France' ); ");
            Sql("INSERT INTO dbo.Countries (Id, Name) VALUES(5, 'Poland' ); ");


        }
        
        public override void Down()
        {
        }
    }
}
