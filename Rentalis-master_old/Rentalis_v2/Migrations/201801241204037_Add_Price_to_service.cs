namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Price_to_service : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarServices", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarServices", "Price");
        }
    }
}
