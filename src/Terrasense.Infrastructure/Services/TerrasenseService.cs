using Terrasense.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Terrasense.Domain.Models;
using Terrasense.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Terrasense.Infrastructure.Services;

public class TerrasenseService(TerrasenseContext context, ILogger<TerrasenseService> logger) : ITerrasenseService
{

  public async Task<SensorReading> AddReadingAsync(SensorReading reading)
  {
    try
    {
      logger.LogInformation("Adding new sensor reading: {@Reading}", reading);

      reading.Timestamp = DateTime.UtcNow;
      context.SensorReading.Add(reading);
      await context.SaveChangesAsync();

      return reading;

    }
    catch (Exception ex)
    {
      logger.LogError(ex, "Error adding sensor reading: {@Reading}", reading);
      throw;
    }
  }

  public async Task<IEnumerable<SensorReading>> GetReadingsAsync(string? sensorId, DateTime? from = null, DateTime? to = null)
  {
    try
    {
      logger.LogInformation("Retrieving readings");

      var query = context.SensorReading.AsQueryable();

      if (!string.IsNullOrEmpty(sensorId))
      {
        query = query.Where(r => r.SensorId == sensorId);
      }

      if (from.HasValue)
      {
        query = query.Where(r => r.Timestamp >= from.Value);
      }

      if (to.HasValue)
      {
        query = query.Where(r => r.Timestamp <= to.Value);
      }

      var results = await query.ToListAsync();
      logger.LogInformation("Retrieved {Count} readings", results.Count);
      return results;
    }
    catch (Exception ex)
    {
      logger.LogError(ex, $"Error retrieving sensor readings with SensorId: {sensorId}, From: {from}, To: {to}");
      throw;
    }
  }
}

