using Terrasense.Api.Endpoints;
using Microsoft.OpenApi.Models;
using Terrasense.Infrastructure.Extensions;
using Terrasense.Api.Exceptions;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/terrasense.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
  Log.Information("Starting web host");
  var builder = WebApplication.CreateBuilder(args);

  builder.Host.UseSerilog();
  builder.Services.AddInfrastructureServices(builder.Configuration);
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen(c =>
  {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
      Title = "Test API",
      Version = "v1",
      Description = "A simple example ASP.NET Core Web API for managing sensor readings.",
    });

  });

  builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
  builder.Services.AddProblemDetails();

  var app = builder.Build();

  app.UseExceptionHandler();
  // Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }

  app.MapTerrasenseEndpoints();
  app.Run();
}
catch (Exception ex)
{
  Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
  Log.CloseAndFlush();
}
