namespace Boonbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stipulations = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        RegistrationCause = c.String(),
                        ExpenditureDate = c.DateTime(nullable: false),
                        ExpenditureCause = c.String(),
                        Creditor_Id = c.Int(),
                        Debtor_Id = c.Int(),
                        Level_Id = c.Int(),
                        Registrar_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Creditor_Id)
                .ForeignKey("dbo.Characters", t => t.Debtor_Id)
                .ForeignKey("dbo.BoonLevels", t => t.Level_Id)
                .ForeignKey("dbo.Characters", t => t.Registrar_Id)
                .Index(t => t.Creditor_Id)
                .Index(t => t.Debtor_Id)
                .Index(t => t.Level_Id)
                .Index(t => t.Registrar_Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Clan_Id = c.Int(),
                        Player_Id = c.Int(),
                        Sect_Id = c.Int(),
                        SocialClass_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clans", t => t.Clan_Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .ForeignKey("dbo.Sects", t => t.Sect_Id)
                .ForeignKey("dbo.SocialClasses", t => t.SocialClass_Id)
                .Index(t => t.Clan_Id)
                .Index(t => t.Player_Id)
                .Index(t => t.Sect_Id)
                .Index(t => t.SocialClass_Id);
            
            CreateTable(
                "dbo.Clans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        PasswordHash = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Sects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BoonLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boons", "Registrar_Id", "dbo.Characters");
            DropForeignKey("dbo.Boons", "Level_Id", "dbo.BoonLevels");
            DropForeignKey("dbo.Boons", "Debtor_Id", "dbo.Characters");
            DropForeignKey("dbo.Boons", "Creditor_Id", "dbo.Characters");
            DropForeignKey("dbo.Characters", "SocialClass_Id", "dbo.SocialClasses");
            DropForeignKey("dbo.Characters", "Sect_Id", "dbo.Sects");
            DropForeignKey("dbo.Characters", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Roles", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Characters", "Clan_Id", "dbo.Clans");
            DropIndex("dbo.Roles", new[] { "Player_Id" });
            DropIndex("dbo.Characters", new[] { "SocialClass_Id" });
            DropIndex("dbo.Characters", new[] { "Sect_Id" });
            DropIndex("dbo.Characters", new[] { "Player_Id" });
            DropIndex("dbo.Characters", new[] { "Clan_Id" });
            DropIndex("dbo.Boons", new[] { "Registrar_Id" });
            DropIndex("dbo.Boons", new[] { "Level_Id" });
            DropIndex("dbo.Boons", new[] { "Debtor_Id" });
            DropIndex("dbo.Boons", new[] { "Creditor_Id" });
            DropTable("dbo.BoonLevels");
            DropTable("dbo.SocialClasses");
            DropTable("dbo.Sects");
            DropTable("dbo.Roles");
            DropTable("dbo.Players");
            DropTable("dbo.Clans");
            DropTable("dbo.Characters");
            DropTable("dbo.Boons");
        }
    }
}
