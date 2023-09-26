using Microsoft.EntityFrameworkCore;

namespace Phonebook.Models.Dict;

public class PhoneBookDb:DbContext
{
    public DbSet<PhoneBookRaw> PhoneBookRaws { get; set; } = null;

    public PhoneBookDb(DbContextOptions<PhoneBookDb> options) : base(options)
    {
        Database.EnsureCreated();
    }
}