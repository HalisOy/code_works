using GraphqlDBTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlDBTest.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
    }

    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
}