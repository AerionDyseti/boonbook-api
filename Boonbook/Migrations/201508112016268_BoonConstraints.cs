namespace Boonbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoonConstraints : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Boons", new[] { "Creditor_Id" });
            DropIndex("dbo.Boons", new[] { "Debtor_Id" });
            DropIndex("dbo.Boons", new[] { "Registrar_Id" });
            AlterColumn("dbo.Boons", "Creditor_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Boons", "Debtor_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Boons", "Registrar_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Boons", "Creditor_Id");
            CreateIndex("dbo.Boons", "Debtor_Id");
            CreateIndex("dbo.Boons", "Registrar_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Boons", new[] { "Registrar_Id" });
            DropIndex("dbo.Boons", new[] { "Debtor_Id" });
            DropIndex("dbo.Boons", new[] { "Creditor_Id" });
            AlterColumn("dbo.Boons", "Registrar_Id", c => c.Int());
            AlterColumn("dbo.Boons", "Debtor_Id", c => c.Int());
            AlterColumn("dbo.Boons", "Creditor_Id", c => c.Int());
            CreateIndex("dbo.Boons", "Registrar_Id");
            CreateIndex("dbo.Boons", "Debtor_Id");
            CreateIndex("dbo.Boons", "Creditor_Id");
        }
    }
}
