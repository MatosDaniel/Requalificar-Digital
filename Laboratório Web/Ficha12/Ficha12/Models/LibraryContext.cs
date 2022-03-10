using Microsoft.EntityFrameworkCore;

namespace Ficha12.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { set; get; }
        public DbSet<Publisher> Publishers { set; get; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=apus.uma.pt;database=library;" + "user=dotnetUMa;password=UMaDotNet");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.ISBN);
                entity.Property(e => e.Title).IsRequired();
                entity.HasOne(d => d.Publisher);
            });
        }
    }
}
