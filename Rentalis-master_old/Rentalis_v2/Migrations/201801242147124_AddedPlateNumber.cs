namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPlateNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarModels", "PlateNumber", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarModels", "PlateNumber");
        }
    }
}
