namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addservice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        serviceName = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Description = c.String(nullable: false, unicode: false),
                        DateTime = c.DateTime(nullable: false, precision: 0),
                        LengthService = c.Int(nullable: false),
                        CarModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarModels", t => t.CarModel_Id)
                .Index(t => t.CarModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarServices", "CarModel_Id", "dbo.CarModels");
            DropIndex("dbo.CarServices", new[] { "CarModel_Id" });
            DropTable("dbo.CarServices");
        }
    }
}
