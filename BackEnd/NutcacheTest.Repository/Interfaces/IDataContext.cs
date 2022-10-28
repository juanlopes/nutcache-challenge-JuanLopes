using Microsoft.EntityFrameworkCore;
using NutcacheTest.Entities.Entity;

namespace NutcacheTest.Repository.Interfaces;

public interface IDataContext {
    public DbSet<User> Users { get; set; }
    public Task<int> Commit();
}