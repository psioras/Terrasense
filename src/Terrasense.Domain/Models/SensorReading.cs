namespace Terrasense.Domain.Models;

public class SensorReading
{
  public int Id { get; set; }
  public DateTime Timestamp { get; set; }
  public string SensorId { get; set; }
  public double Temperature { get; set; }
  public double Humidity { get; set; }
}
