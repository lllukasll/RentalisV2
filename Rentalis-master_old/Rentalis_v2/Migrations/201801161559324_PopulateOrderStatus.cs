namespace Rentalis_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateOrderStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO orderstatusmodels VALUES (1,'Oczekuje na zap�at�')");
            Sql("INSERT INTO orderstatusmodels VALUES (2,'Op�acone')");
            Sql("INSERT INTO orderstatusmodels VALUES (3,'W trakcie')");
            Sql("INSERT INTO orderstatusmodels VALUES (4,'Zako�czone')");

        }
        
        public override void Down()
        {
        }
    }
}
