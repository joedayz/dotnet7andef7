using Microsoft.EntityFrameworkCore;

namespace EF7First.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Data Source=192.168.1.14;Database=dotnet7testdb;User ID=sa;Password=JoeDayz2023$;TrustServerCertificate=true");
    }
    
    public DbSet<WeatherForecast> Forecasts { get; set; }
}