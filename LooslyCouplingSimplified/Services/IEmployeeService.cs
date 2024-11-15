using LooslyCouplingSimplified.Dtos.Employees;

namespace LooslyCouplingSimplified.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
    
    Task<EmployeeDto> GetEmployeeAsync(int id);
    
    Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
    
    Task<EmployeeDto> UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto);
    
    Task DeleteEmployeeAsync(int id);
}