namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRegistrationFieldsToRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.AspNetUsers", "Surname", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.AspNetUsers", "CarLicenceNumber", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.AspNetUsers", "Adress", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Adress", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "CarLicenceNumber", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "Surname", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(unicode: false));
        }
    }
}
