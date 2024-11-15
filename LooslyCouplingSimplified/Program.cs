using LooslyCouplingSimplified.Data;
using LooslyCouplingSimplified.Dtos.Employees;
using LooslyCouplingSimplified.Repositories;
using LooslyCouplingSimplified.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Unity;

public class Program
{
    static async Task Main(string[] args)
    {
        var container = new UnityContainer();
        RegisterTypes(container);

        var employeeService = container.Resolve<IEmployeeService>();
        
        var employees = await employeeService.GetEmployeesAsync();
        foreach (var e in employees)
        {
            Console.WriteLine($"Employee: {e.Name}");
        }
        
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        container.RegisterFactory<DbContextOptions<ApplicationDbContext>>(c =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return optionsBuilder.Options;
        });

        container.RegisterType<IApplicationDbContext, ApplicationDbContext>();
        container.RegisterType<IEmployeeService, EmployeeService>();
        container.RegisterType<IEmployeeRepository, EmployeeRepository>();

    }
}