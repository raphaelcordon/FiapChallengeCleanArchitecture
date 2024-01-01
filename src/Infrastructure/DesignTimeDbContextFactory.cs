using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var applicationProjectPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../Application"));

        var configuration = new ConfigurationBuilder()
            .SetBasePath(applicationProjectPath)
            .AddJsonFile("appsettings.json", false)
            .Build();

        var connectionString = configuration.GetConnectionString("SQLiteConnection");

        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseSqlite(connectionString);

        return new DatabaseContext(optionsBuilder.Options);
    }
}