using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ParksApi.Models
{
    public class ParksApiContextFactory : IDesignTimeDbContextFactory<ParksApiContext>
    {

        ParksApiContext IDesignTimeDbContextFactory<ParksApiContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var builder = new DbContextOptionsBuilder<ParksApiContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new ParksApiContext(builder.Options);
        }
    }
}