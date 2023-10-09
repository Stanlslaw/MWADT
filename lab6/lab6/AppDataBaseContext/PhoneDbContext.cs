using Microsoft.EntityFrameworkCore;

namespace AppDataBaseContext;

public class PhoneDbContext:DbContext
{
    public DbSet<PhoneRaw> Raws { get; set; }

    public PhoneDbContext(DbContextOptions<PhoneDbContext> options) : base(options)
    {
        if (!Database.CanConnect())
        {
            Database.EnsureCreated();

            // Seed initial data if necessary (only on first creation)
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<PhoneRaw>().HasData(new PhoneRaw[] {
                new PhoneRaw() { Id = Guid.NewGuid(), PhoneNumber = "+375333333331", Name = "Alex" }
            });

    }
}