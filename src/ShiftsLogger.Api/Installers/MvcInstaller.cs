using Microsoft.OpenApi.Models;

namespace ShiftsLogger.Api.Installers;

public class MvcInstaller : IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        // -------------------------------------------------------------------------------------
        // MVC.
        // -------------------------------------------------------------------------------------

        builder.Services.AddControllers();

        // -------------------------------------------------------------------------------------
        // Swagger.
        // -------------------------------------------------------------------------------------

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Shifts Logger",
                Version = "v1"
            });
        });
    }
}
