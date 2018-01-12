namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChagesInBookingModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingModels", "TotalPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.BookingModels", "userId", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookingModels", "userId", c => c.Int(nullable: false));
            DropColumn("dbo.BookingModels", "TotalPrice");
        }
    }
}
