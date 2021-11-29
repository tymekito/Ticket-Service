using Microsoft.EntityFrameworkCore;

namespace TicketsAPI.Entities
{
    public class AppDbContext : DbContext
    {
        private readonly string connectionString = "Server=localhost\\SQLEXPRESS; Database=TicketsDb; Trusted_Connection=True";
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Ticket>()
                .Property(t => t.Name)
                .IsRequired();
            modelbuilder.Entity<Event>()
                .Property(e => e.Name)
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
