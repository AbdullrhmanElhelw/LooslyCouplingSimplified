using LooslyCouplingSimplified.Data;
using LooslyCouplingSimplified.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Unity;

namespace LooslyCouplingSimplified.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    
    private readonly IApplicationDbContext _context;

    [InjectionConstructor]
    public EmployeeRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee?>> GetEmployeesAsync()=>
        await _context.Employees.ToListAsync();

    public async Task<Employee?> GetEmployeeAsync(int id)=>
        await _context.Employees.FindAsync(id); 

    public async Task<EntityEntry<Employee?>> AddEmployeeAsync(Employee employee)
    {
        return await _context.Employees.AddAsync(employee);
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        await _context.Employees
            .Where(e => e.Id == employee.Id)
            .ExecuteUpdateAsync(update => update
                .SetProperty(e => e.Name, employee.Name)
                .SetProperty(e => e.DepartmentId, employee.DepartmentId));
        return employee;
    }

    public async Task<Employee> DeleteEmployeeAsync(int id)
    {
        await _context.Employees
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();
        return new Employee();
    }
}