namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Register_fields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "CarLicenceNumber", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "Adress", c => c.String(unicode: false));
            DropColumn("dbo.AspNetUsers", "Imie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Imie", c => c.String(unicode: false));
            DropColumn("dbo.AspNetUsers", "Adress");
            DropColumn("dbo.AspNetUsers", "CarLicenceNumber");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
