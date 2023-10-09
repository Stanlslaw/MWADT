using System.Data.Common;
using lab8.Models;
using Microsoft.EntityFrameworkCore;

namespace lab8.Data;

public class PhoneDictionaryDbContext:DbContext
{
    public DbSet<PhoneRecord> PhoneRecords { get; set; }

    public PhoneDictionaryDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PhoneRecord>().HasData(
            new PhoneRecord[]
            {
                new PhoneRecord(){Id = Guid.NewGuid(),Name = "Stas",PhoneNumber = "+375295200444"}
            }
        );

    }
}