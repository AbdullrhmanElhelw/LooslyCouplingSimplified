using LooslyCouplingSimplified.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LooslyCouplingSimplified.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee?>> GetEmployeesAsync();
    Task<Employee?> GetEmployeeAsync(int id);
    Task<EntityEntry<Employee?>> AddEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(Employee employee);
    Task<Employee> DeleteEmployeeAsync(int id);
}