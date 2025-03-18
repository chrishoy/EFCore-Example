namespace EFCoreExample.Data;

using EFCoreExample.Data.Configurations;
using EFCoreExample.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration()); // Register the configuration

        base.OnModelCreating(modelBuilder); // Ensure base configurations are applied
    }
}
