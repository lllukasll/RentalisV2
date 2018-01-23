namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Imie_do_Identity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Imie", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Imie");
        }
    }
}
