// AppDbContextFactory.cs - Basit versiyon
using HepsiApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HepsiApi.Persistence.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
  public AppDbContext CreateDbContext(string[] args)
  {
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

    IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "Presentation", "HepsiApi.WEBAPI"))
        .AddJsonFile("appsettings.json", optional: false)
        .AddJsonFile($"appsettings.{env}.json", optional: true)
        .Build();

    // Here we create the DbContextOptionsBuilder manually.        
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

    // Build connection string. This requires that you have a connectionstring in the appsettings.json
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    optionsBuilder.UseSqlServer(connectionString);

    // Create our DbContext.
    return new AppDbContext(optionsBuilder.Options);
  }
}