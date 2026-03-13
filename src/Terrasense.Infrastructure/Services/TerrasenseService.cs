using Terrasense.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Terrasense.Domain.Models;
using Terrasense.Infrastructure.Data;

namespace Terrasense.Infrastructure.Services
{
  public class TerrasenseService(TerrasenseContext context, ILogger<TerrasenseService> logger) : ITerrasenseService
  {

    public Task<SensorReading> AddReadingAsync(SensorReading reading)
    {
      logger.LogInformation("Adding new sensor reading: {@Reading}", reading);
      // Placeholder for actual implementation
      return Task.FromResult(reading);
    }

    public Task<IEnumerable<SensorReading>> GetReadingsAsync()
    {
      logger.LogInformation("Retrieving all sensor readings");
      // Placeholder for actual implementation
      return Task.FromResult(Enumerable.Empty<SensorReading>());

    }
  }
