using NutcacheTest.Common.Config;
using NutcacheTest.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using NutcacheTest.Repository.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace NutcacheTest.Repository.Context;

public class DataContext : DbContext, IDataContext
{
    private readonly IConfig _config;

    public DataContext(IConfig config) {
        _config = config;
    }

    [AllowNull]
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options){
        options.UseLazyLoadingProxies();
        options.UseMySQL(_config.GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> Commit()
    {
        return await SaveChangesAsync();
    }
}
