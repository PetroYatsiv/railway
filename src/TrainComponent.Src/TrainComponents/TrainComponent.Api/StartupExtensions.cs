using Microsoft.AspNetCore.Builder;
using TrainComponent.Application;
using TrainComponent.Persistence;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace TrainComponent.Api
{
    public static class StartupExtensions
    {
       public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("open", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                               "TrainComponent.Api v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("open");
            app.MapControllers();

            return app;
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "TrainComponent.Api", 
                    Version = "v1" 
                });
            });
        }
    }
}
