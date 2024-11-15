using LooslyCouplingSimplified.Data;
using LooslyCouplingSimplified.Dtos.Employees;
using LooslyCouplingSimplified.Models;
using LooslyCouplingSimplified.Repositories;
using Unity;

namespace LooslyCouplingSimplified.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IApplicationDbContext _applicationDbContext;
    public EmployeeService(IEmployeeRepository employeeRepository, IApplicationDbContext applicationDbContext)
    {
        _employeeRepository = employeeRepository;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
    {
        return (await _employeeRepository.GetEmployeesAsync())
            .Select(e => new EmployeeDto(e.Id, e.Name, e.DepartmentId));
    }

    public async Task<EmployeeDto> GetEmployeeAsync(int id)
    {
        var employee = await _employeeRepository.GetEmployeeAsync(id);
        return new EmployeeDto(employee.Id, employee.Name, employee.DepartmentId);
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
    {

        var employee = new Employee()
        {
            Name = createEmployeeDto.Name,
            DepartmentId = createEmployeeDto.DepartmentId
        };
        
        await _employeeRepository.AddEmployeeAsync(employee);
        await _applicationDbContext.SaveChangesAsync(new CancellationToken());
        return new EmployeeDto(employee.Id, employee.Name, employee.DepartmentId);
        
    }

    public Task<EmployeeDto> UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeAsync(int id)
    {
        throw new NotImplementedException();
    }
}