using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace YuGiOhDeckEditor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } // Example entity
        public DbSet<CardsInfo> CardsInfo { get; set; } // Example entity
        public DbSet<DeckInfo> DeckInfo { get; set; } // Example entity
        public DbSet<BanList> BanList { get; set; } // Example entity
        public DbSet<UserDecks> UserDecks { get; set; } // Example entity
        public DbSet<CardType> CardType { get; set; } // Example entity
        public DbSet<DeckCard> DeckCard { get; set; } // Example entity
    }
}
