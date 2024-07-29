using Microsoft.EntityFrameworkCore;
using ShiftsLogger.Data.Entities;

namespace ShiftsLogger.Data.Contexts;

public class DatabaseContext : DbContext
{
    #region Constructors

    public DatabaseContext(DbContextOptions<DatabaseContext> options) 
        : base(options)
    {
    }

    #endregion
    #region Properties

    public DbSet<Shift> Shift { get; set; } = null!;

    #endregion
}
