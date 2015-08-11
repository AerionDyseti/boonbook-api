namespace Boonbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Characters", "RetireDate", c => c.DateTime());
            AddColumn("dbo.Players", "MesNumber", c => c.String());
            AddColumn("dbo.Players", "FirstName", c => c.String());
            AddColumn("dbo.Players", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "LastName");
            DropColumn("dbo.Players", "FirstName");
            DropColumn("dbo.Players", "MesNumber");
            DropColumn("dbo.Characters", "RetireDate");
            DropColumn("dbo.Characters", "StartDate");
        }
    }
}
