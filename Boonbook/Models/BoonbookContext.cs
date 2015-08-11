using System.Data.Entity;
using Boonbook.Models.Boons;
using Boonbook.Models.Characters;
using Boonbook.Models.Users;

namespace Boonbook.Models
{
    public class BoonbookContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public BoonbookContext() : base("name=BoonbookContext")
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Sect> Sects { get; set; }
        public DbSet<SocialClass> SocialClasses { get; set; }
        public DbSet<BoonLevel> BoonLevels { get; set; }
        public DbSet<Boon> Boons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Boon relationships.
            modelBuilder.Entity<Boon>().HasRequired(b => b.Creditor).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Boon>().HasRequired(b => b.Debtor).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Boon>().HasRequired(b => b.Registrar).WithMany().WillCascadeOnDelete(false);

        }
    }
}