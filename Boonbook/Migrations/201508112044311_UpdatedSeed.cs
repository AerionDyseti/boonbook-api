namespace Boonbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clans", "PillarClan", c => c.Boolean(nullable: false));
            AlterColumn("dbo.SocialClasses", "Name", c => c.String());
            DropColumn("dbo.Players", "FirstName");
            DropColumn("dbo.Players", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "LastName", c => c.String());
            AddColumn("dbo.Players", "FirstName", c => c.String());
            AlterColumn("dbo.SocialClasses", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Clans", "PillarClan");
        }
    }
}
