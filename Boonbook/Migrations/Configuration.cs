using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Boonbook.Models;
using Boonbook.Models.Boons;
using Boonbook.Models.Characters;
using Boonbook.Models.Users;

namespace Boonbook.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BoonbookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BoonbookContext context)
        {
            //  This method will be called after migrating to the latest version.

            // Player Stuff.
            var User = new Role {Name = "User"};
            var Admin = new Role {Name = "Administrator"};
            var Harpy = new Role {Name = "Harpy"};
            var Talon = new Role {Name = "Talon"};
            context.Roles.AddOrUpdate(User, Admin, Harpy, Talon);

            var Kevin = new Player
            {
                Username = "DrTennyson",
                MesNumber = "US2010123456",
                FirstName = "Kevin",
                LastName = "Whiteside",
                PasswordHash = "SuperPass123",
                Email = "dr.g.tennyson@gmail.com",
                Roles = new List<Role> {Admin, Harpy}
            };
            var Paula = new Player
            {
                Username = "DrSyd",
                MesNumber = "US2010123456",
                FirstName = "Paula",
                LastName = "Wilkinson",
                PasswordHash = "An4chsRule",
                Email = "dr.syd@gmail.com",
                Roles = new List<Role> {User}
            };
            var Austin = new Player
            {
                Username = "Bonecutter",
                MesNumber = "US2010123456",
                FirstName = "Austin",
                LastName = "Bonecutter",
                PasswordHash = "p4ssword",
                Email = "caleb.bonecutter@gmail.com",
                Roles = new List<Role> {User, Talon}
            };
            context.Players.AddOrUpdate(Kevin, Paula, Austin);

            // Character Stuff.
            var Toreador = new Clan {Name = "Toreador", PillarClan = true};
            var Ravnos = new Clan {Name = "Ravnos"};
            var Setite = new Clan {Name = "Followers of Set"};
            context.Clans.AddOrUpdate(Toreador, Ravnos, Setite);

            var Elder = new SocialClass {Name = "Elder"};
            var Ancilla = new SocialClass {Name = "Ancilla"};
            var Neonate = new SocialClass {Name = "Neonate"};
            context.SocialClasses.AddOrUpdate(Elder, Ancilla, Neonate);

            var Camarilla = new Sect {Name = "Camarilla"};
            var Anarch = new Sect {Name = "Anarch Movement"};
            context.Sects.AddOrUpdate(Camarilla, Anarch);

            var Gabriel = new Character
            {
                Name = "Dr. Gabriel Tennyson",
                Clan = Toreador,
                Sect = Camarilla,
                SocialClass = Elder,
                Player = Kevin,
                StartDate = DateTime.Now.AddMonths(-14).AddDays(-3)
            };
            var DrSyd = new Character
            {
                Name = "Dr. Sydney Baker",
                Clan = Ravnos,
                Sect = Anarch,
                SocialClass = Neonate,
                Player = Paula,
                StartDate = DateTime.Now.AddMonths(-4).AddDays(-215)
            };
            var Culebra = new Character
            {
                Name = "Miguel Culebra",
                Clan = Setite,
                Sect = Camarilla,
                SocialClass = Ancilla,
                Player = Austin,
                StartDate = DateTime.Now.AddMonths(-54).AddDays(55)
            };
            context.Characters.AddOrUpdate(Gabriel, DrSyd, Culebra);

            // Boon Stuff.
            var Trivial = new BoonLevel { Name = "Trivial" };
            var Blood = new BoonLevel { Name = "Blood" };
            context.BoonLevels.AddOrUpdate(Trivial);

            var testBoon = new Boon
            {
                Registrar = Gabriel,
                Creditor = DrSyd,
                Debtor = Culebra,
                Level = Trivial,
                RegistrationDate = DateTime.Now,
                RegistrationCause = "Not going all Anarch on that snakey ass.",
                Stipulations = "Debtor cannot sneeze in front of Creditor while boon is held."
            };
            var secondBoon = new Boon
            {
                Registrar = Culebra,
                Creditor = Gabriel,
                Debtor = DrSyd,
                Level = Blood,
                RegistrationDate = DateTime.Now,
                RegistrationCause = "Teaching both Elder Daimonion powers.",
                Stipulations = "Boon can only be transferred during the full moon of each month. "
            };
            context.Boons.AddOrUpdate(testBoon, secondBoon);
        }
    }
}