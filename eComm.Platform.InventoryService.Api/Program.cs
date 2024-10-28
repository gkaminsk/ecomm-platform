using InventoryService.Api.Infrastructure.Repositories;
using InventoryService.Api.Infrastructure.Repositories.Abstractions;
using InventoryService.Api.Infrastructure.Services.Abstractions;
using SharedLibrary.ExceptionHandlers;

namespace InventoryService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
            builder.Services.AddScoped<IInventoryService, Infrastructure.Services.InventoryService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });
            builder.Services.AddHealthChecks();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapHealthChecks("health");
            app.UseExceptionHandler();

            app.MapControllers();

            app.Run();
        }
    }
}
