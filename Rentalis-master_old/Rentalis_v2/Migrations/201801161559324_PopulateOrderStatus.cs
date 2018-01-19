namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateOrderStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO orderstatusmodels VALUES (1,'Oczekuje na zap³atê')");
            Sql("INSERT INTO orderstatusmodels VALUES (2,'Op³acone')");
            Sql("INSERT INTO orderstatusmodels VALUES (3,'W trakcie')");
            Sql("INSERT INTO orderstatusmodels VALUES (4,'Zakoñczone')");

        }
        
        public override void Down()
        {
        }
    }
}
