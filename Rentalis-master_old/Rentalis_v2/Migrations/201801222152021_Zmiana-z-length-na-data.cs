namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zmianazlengthnadata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarServices", "FromDateTime", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.CarServices", "ToDateTime", c => c.DateTime(nullable: false, precision: 0));
            DropColumn("dbo.CarServices", "DateTime");
            DropColumn("dbo.CarServices", "LengthService");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarServices", "LengthService", c => c.Int(nullable: false));
            AddColumn("dbo.CarServices", "DateTime", c => c.DateTime(nullable: false, precision: 0));
            DropColumn("dbo.CarServices", "ToDateTime");
            DropColumn("dbo.CarServices", "FromDateTime");
        }
    }
}
