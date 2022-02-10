using Microsoft.EntityFrameworkCore;

namespace BookApi.Entities
{
    public class AppDbContext : DbContext
    {
        private readonly string connectionString = "Server=localhost\\SQLEXPRESS; Database=LibraryDb; Trusted_Connection=True";
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Book>()
                .Property(t => t.Name)
                .IsRequired();
            modelbuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(25);
            modelbuilder.Entity<User>()
                .Property(u => u.EMail)
                .IsRequired()
                .HasMaxLength(25);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
