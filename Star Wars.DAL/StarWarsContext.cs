using Star_Wars.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Wars.DAL
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext() : base("StarWars_DB")
        {
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Character>()
                .HasMany(p => p.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("CharacterID");
                    m.MapRightKey("FriendID");
                    m.ToTable("Friend");
                });
        }
    }
}
