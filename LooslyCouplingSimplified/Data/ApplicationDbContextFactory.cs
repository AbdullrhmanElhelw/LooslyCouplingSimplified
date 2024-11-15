using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LooslyCouplingSimplified.Data;
 
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{

    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        
        var options = new DbContextOptions<ApplicationDbContext>();
        
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>(options)
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        
        return new ApplicationDbContext(builder.Options);
        
    }
}