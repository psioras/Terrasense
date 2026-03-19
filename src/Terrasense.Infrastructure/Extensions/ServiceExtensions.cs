using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Terrasense.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Terrasense.Infrastructure.Interfaces;
using Terrasense.Infrastructure.Services;

namespace Terrasense.Infrastructure.Extensions;

public static class ServiceExtensions
{
  public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
  {
    // Register the database context with the dependency injection container
    services.AddDbContext<TerrasenseContext>(options =>
      options.UseNpgsql(configuration.GetConnectionString("TerrasenseDb")));

    services.AddScoped<ITerrasenseService, TerrasenseService>();
  }
}

