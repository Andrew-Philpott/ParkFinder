using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using ParksApi.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace ParksApi
{
  public class Startup
  {
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();
      services.AddControllers();

      services.ConfigureMySqlContext(_configuration);
      services.ConfigureRepositoryWrapper();
      services.AddAutoMapper(typeof(Startup));
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseStaticFiles();

      app.UseRouting();

      app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}