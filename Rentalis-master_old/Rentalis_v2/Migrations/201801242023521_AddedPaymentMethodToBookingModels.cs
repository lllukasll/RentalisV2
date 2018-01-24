namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPaymentMethodToBookingModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingModels", "PaymentMethod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {            
            DropColumn("dbo.BookingModels", "PaymentMethod");
        }
    }
}
