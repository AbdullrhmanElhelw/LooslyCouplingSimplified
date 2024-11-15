using LooslyCouplingSimplified.Models;
using Microsoft.EntityFrameworkCore;

namespace LooslyCouplingSimplified.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee?> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(e =>
        {
            e.HasIndex(e => e.Id);
            e.HasIndex(e => e.Code);
        });
        
        modelBuilder.Entity<Employee>(e =>
        {
            e.HasIndex(e => e.Id);
            e.HasIndex(e => e.Name);
        });
    }
}