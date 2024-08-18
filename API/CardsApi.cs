using Cards.Models;
using CardsUsers.Models;
using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace DatabaseR
{
    public class CardsApi : DbContext
    {
        public CardsApi(DbContextOptions<CardsApi> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CardsUser> CardsUsers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Abilitie> Abilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardsUser>()
            .HasKey(cu => new { cu.UserId, cu.CardId });
            modelBuilder.Entity<CardsUser>()
            .HasOne(cu => cu.User)
            .WithMany(cu => cu.CardsUsers)
            .HasForeignKey(cu => cu.UserId);
            modelBuilder.Entity<CardsUser>()
            .HasOne(cu => cu.Card)
            .WithMany(cu => cu.CardsUsers)
            .HasForeignKey(cu => cu.CardId);
            modelBuilder.Entity<Abilitie>()
            .HasMany(a => a.Cards)
            .WithMany(a => a.abilities)
            .UsingEntity("CardsAbilities");
            
        }
    }
}
