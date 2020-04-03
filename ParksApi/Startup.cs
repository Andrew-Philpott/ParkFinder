using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParksApi.Repository;
using ParksApi.Contracts;
using ParksApi.Models;

namespace ParksApi
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
  }
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.ConfigureRepositoryWrapper();
      services.ConfigureMySqlContext(Configuration);
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseStaticFiles();

      app.UseCors("CorsPolicy");

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
