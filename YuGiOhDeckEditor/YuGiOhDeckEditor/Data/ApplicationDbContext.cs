using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YuGiOhDeckEditor.Entities;

namespace YuGiOhDeckEditor.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Replace this with your actual database connection string
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YuGiOhDeckEditorDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False", 
                    b => b.MigrationsAssembly("YuGiOhDeckEditor"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships, keys, and constraints here

            // Example: Configure the UserDecks table relationships
            modelBuilder.Entity<UserDecks>()
                .HasOne<User>() // Specify the User entity
                .WithMany() // A User can have many Decks
                .HasForeignKey(ud => ud.UserId) // Foreign key on UserDecks
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if the User is deleted

            modelBuilder.Entity<UserDecks>()
                .HasOne<DeckInfo>() // Specify the Deck entity
                .WithMany() // A Deck can belong to many Users
                .HasForeignKey(ud => ud.DeckId) // Foreign key on UserDecks
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if the Deck is deleted

            // Example: Configure the DeckCard table relationships
            modelBuilder.Entity<DeckCard>()
                .HasOne<DeckInfo>() // Specify the DeckInfo entity
                .WithMany() // A deck can contain many cards
                .HasForeignKey(dc => dc.DeckId) // Foreign key on DeckCard
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DeckCard>()
                .HasOne<CardsInfo>() // Specify the CardsInfo entity
                .WithMany() // A card can belong to many decks
                .HasForeignKey(dc => dc.CardId) // Foreign key on DeckCard
                .OnDelete(DeleteBehavior.Cascade);

            // Set up unique constraints, defaults, etc.
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique(); // Ensure emails are unique in the Users table

            modelBuilder.Entity<CardsInfo>()
                .HasIndex(c => c.Name)
                .IsUnique(); // Ensure card names are unique

            // Further configurations can be added as needed, such as relationships for BanList and other tables.
        }

        public DbSet<CardsInfo> CardsInfo { get; set; } // Example entity
        public DbSet<DeckInfo> DeckInfo { get; set; } // Example entity
        public DbSet<BanList> BanList { get; set; } // Example entity
        public DbSet<UserDecks> UserDecks { get; set; } // Example entity
        public DbSet<CardType> CardType { get; set; } // Example entity
        public DbSet<DeckCard> DeckCard { get; set; } // Example entity
    }
}
