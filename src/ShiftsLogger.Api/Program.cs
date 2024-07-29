using Microsoft.EntityFrameworkCore;
using ShiftsLogger.Api.Configurations;
using ShiftsLogger.Api.Installers;
using ShiftsLogger.Data.Contexts;

namespace ShiftsLogger.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.InstallServicesInAssembly();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            var swaggerOptions = new Configurations.SwaggerOptions();
            builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(options =>
            {
                options.RouteTemplate = swaggerOptions.JsonRoute;
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
                options.RoutePrefix = string.Empty;
            });
        }

        //app.UseAuthorization();

        app.MapControllers();

        // Perform any database migrations.
        using (var serviceScope = app.Services.CreateScope())
        {
            var databaseContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();

            await databaseContext.Database.MigrateAsync();
        }
        
        app.Run();
    }
}
