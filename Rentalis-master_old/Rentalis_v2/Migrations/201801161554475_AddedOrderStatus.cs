namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderStatusModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.BookingModels", "OrderStatusId_id", c => c.Int());
            CreateIndex("dbo.BookingModels", "OrderStatusId_id");
            AddForeignKey("dbo.BookingModels", "OrderStatusId_id", "dbo.OrderStatusModels", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingModels", "OrderStatusId_id", "dbo.OrderStatusModels");
            DropIndex("dbo.BookingModels", new[] { "OrderStatusId_id" });
            DropColumn("dbo.BookingModels", "OrderStatusId_id");
            DropTable("dbo.OrderStatusModels");
        }
    }
}
