using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParksApi.Repository;
using ParksApi.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ParksApi.Helpers
{
  public static class Extensions
  {
    public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
    {
      var connectionString = config["ConnectionStrings:DefaultConnection"];
      services.AddDbContext<ParksApiContext>(o => o.UseMySql(connectionString));
    }
    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
      services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
  }
}
