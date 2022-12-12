using Microsoft.EntityFrameworkCore;
using SoccerPlayerAPIDotNet7.Models;

namespace SoccerPlayerAPIDotNet7.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Data Source=192.168.1.14;Database=soccerplayerdb;User ID=sa;Password=JoeDayz2023$;TrustServerCertificate=true");
    }
    
    public DbSet<SoccerPlayer> SoccerPlayers { get; set; }
}