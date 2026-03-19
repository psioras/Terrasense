using Terrasense.Domain.Models;

namespace Terrasense.Infrastructure.Interfaces;

public interface ITerrasenseService
{
  Task<SensorReading> AddReadingAsync(SensorReading reading);
  Task<IEnumerable<SensorReading>> GetReadingsAsync(string? sensorId, DateTime? from = null, DateTime? to = null);
}
