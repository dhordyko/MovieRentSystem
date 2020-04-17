namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrdersId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        Name = c.String(),
                        CustomerId = c.String(),
                        AbonementType_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.OrdersId)
                .ForeignKey("dbo.MembershipTypes", t => t.AbonementType_Id)
                .Index(t => t.AbonementType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "AbonementType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Orders", new[] { "AbonementType_Id" });
            DropTable("dbo.Orders");
        }
    }
}
