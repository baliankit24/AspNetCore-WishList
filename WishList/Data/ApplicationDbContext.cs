using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
}