using Microsoft.EntityFrameworkCore;

namespace Little_Conqueror.Services;

public class DataContext : DbContext
{
    #region DBSETS
    
    #endregion
    
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}