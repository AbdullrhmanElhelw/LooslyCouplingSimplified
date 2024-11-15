using LooslyCouplingSimplified.Models;
using Microsoft.EntityFrameworkCore;

namespace LooslyCouplingSimplified.Data;

public interface IApplicationDbContext : IDisposable
{
    DbSet<Department> Departments { get; set; }
    DbSet<Employee?> Employees { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}