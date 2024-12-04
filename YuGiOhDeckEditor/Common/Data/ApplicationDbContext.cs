using Common.Entities;
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
                optionsBuilder.UseSqlServer(
           "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YuGiOhDeckEditorDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False",
           b => b.MigrationsAssembly("YuGiOhDeckEditor"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships, keys, and constraints here

            // Other configurations
            modelBuilder.Entity<DeckCard>()
                .HasOne<DeckInfo>()
                .WithMany()
                .HasForeignKey(dc => dc.DeckId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DeckCard>()
                .HasOne<CardsInfo>()
                .WithMany()
                .HasForeignKey(dc => dc.CardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AddCardViewModel>().HasNoKey();

            modelBuilder.Entity<CardsInfo>()
                .HasIndex(c => c.Name)
                .IsUnique(); // Ensure card names are unique

            modelBuilder.Entity<AddCardViewModel>().HasNoKey();


            // Further configurations can be added as needed, such as relationships for BanList and other tables.
        }

        public DbSet<CardsInfo> CardsInfo { get; set; } // Example entity
        public DbSet<DeckInfo> DeckInfo { get; set; } // Example entity
        public DbSet<BanList> BanList { get; set; } // Example entit
        public DbSet<CardType> CardType { get; set; } // Example entity
        public DbSet<DeckCard> DeckCard { get; set; } // Example entity
        public DbSet<AddCardViewModel> AddCardViewModel { get; set; } // Example entity
    }
}
