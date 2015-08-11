namespace Boonbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Boon_OptionalExpenditureDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boons", "ExpenditureDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boons", "ExpenditureDate", c => c.DateTime(nullable: false));
        }
    }
}
