using Microsoft.EntityFrameworkCore;
using CharacterInventoryAPI.Models;
namespace CharacterInventoryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<CharacterTitle> CharacterTitles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Backpack>()
                .HasKey(b => new { b.CharacterId, b.ItemId });

            modelBuilder.Entity<Backpack>()
                .HasOne(b => b.Character)
                .WithMany(c => c.Backpacks)
                .HasForeignKey(b => b.CharacterId);

            modelBuilder.Entity<Backpack>()
                .HasOne(b => b.Item)
                .WithMany()
                .HasForeignKey(b => b.ItemId);

            modelBuilder.Entity<CharacterTitle>()
                .HasKey(ct => new { ct.CharacterId, ct.TitleId });

            modelBuilder.Entity<CharacterTitle>()
                .HasOne(ct => ct.Character)
                .WithMany(c => c.CharacterTitles)
                .HasForeignKey(ct => ct.CharacterId);

            modelBuilder.Entity<CharacterTitle>()
                .HasOne(ct => ct.Title)
                .WithMany()
                .HasForeignKey(ct => ct.TitleId);
        }
    }
}
