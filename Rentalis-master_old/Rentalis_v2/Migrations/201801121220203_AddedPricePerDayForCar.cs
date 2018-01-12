namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPricePerDayForCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarModels", "PricePerDay", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarModels", "PricePerDay");
        }
    }
}
