using GetechnologiesMx.Api.Middleware;
using GetechnologiesMx.Application;
using GetechnologiesMx.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GetechnologiesMx.Api {
    public static class StartupExtensions {

        public static WebApplication ConfigureServices(this WebApplicationBuilder builder) {

            //Configure services
            builder.Services.AddSwagger();
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddHealthChecks();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app) {

            //middleware for Swagger and SwaggerUI
            //enable endpoint swagger.json which is a machine-readable json file
            //OpenAPI specification that can be used for other apps
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GetechnologiesMx API");
                });
            }

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCustomExceptionHandler();
            app.MapHealthChecks("/health");
            return app;
        }

        //Support for swagger
        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GetechnologiesMx API",

                });
               
            });
        }


        public static async Task MigrateDatabaseAsync(this WebApplication app)
        {

            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<GetechnologiesMxDbContext>();
                if (context != null)
                {
                    //await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = app.Logger;
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}
