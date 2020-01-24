using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MovieIndex.Models
{
  public class MovieIndexContextFactory : IDesignTimeDbContextFactory<MovieIndexContext>
  {

    MovieIndexContext IDesignTimeDbContextFactory<MovieIndexContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<MovieIndexContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new MovieIndexContext(builder.Options);
    }
  }
}