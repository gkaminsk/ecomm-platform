using ProductService.Api.DataAccessLayer.Repositories;
using ProductService.Api.DataAccessLayer.Repositories.Abstractions;
using ProductService.Api.Infrastructure.Services.Abstractions;
using SharedLibrary.ExceptionHandlers;

namespace ProductService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, Infrastructure.Services.ProductService>();

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

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
