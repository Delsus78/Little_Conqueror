using Little_Conqueror.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Little_Conqueror.Services;

public class DataContext : DbContext
{
    #region DBSETS
    public DbSet<City> Cities { get; set; }
    public DbSet<Player> Players { get; set; }
    #endregion
    
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}