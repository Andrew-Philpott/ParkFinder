using ParksApi.Helpers;
using ParksApi.Contracts;
using ParksApi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ParksApi.ServiceExtensions
{
  public static class ServiceExtensions
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

    public static void ConfigureJwt(this IServiceCollection services)
    {

    }
  }
}
