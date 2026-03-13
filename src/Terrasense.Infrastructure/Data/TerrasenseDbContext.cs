using Terrasense.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Terrasense.Infrastructure.Data;

public class TerrasenseContext(DbContextOptions<TerrasenseContext> options) : DbContext(options)
{

  // Default schema for the database context
  private const string DefaultSchema = "dbo";


  // DbSet to represent the collection of Sensor Readings in our database
  public DbSet<SensorReading> SensorReading { get; set; }

  // Constructor to configure the database context
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.HasDefaultSchema(DefaultSchema);

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(TerrasenseContext).Assembly);
  }

}
