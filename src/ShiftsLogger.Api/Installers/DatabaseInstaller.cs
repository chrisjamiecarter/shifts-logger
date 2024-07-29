using Microsoft.EntityFrameworkCore;
using ShiftsLogger.Data.Services;
using ShiftsLogger.Data.Contexts;

namespace ShiftsLogger.Api.Installers;

public class DatabaseInstaller : IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(connectionString));
                
        builder.Services.AddScoped<IShiftService, ShiftService>();
    }
}
