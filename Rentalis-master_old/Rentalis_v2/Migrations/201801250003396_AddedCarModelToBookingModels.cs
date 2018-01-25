namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCarModelToBookingModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingModels", "CarModel_Id", c => c.Int());
            CreateIndex("dbo.BookingModels", "CarModel_Id");
            AddForeignKey("dbo.BookingModels", "CarModel_Id", "dbo.CarModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingModels", "CarModel_Id", "dbo.CarModels");
            DropIndex("dbo.BookingModels", new[] { "CarModel_Id" });
            DropColumn("dbo.BookingModels", "CarModel_Id");
        }
    }
}
