using CartService.Api.DataAccessLayer.Repositories;
using CartService.Api.DataAccessLayer.Repositories.Abstractions;
using CartService.Api.Infrastructure.Extensions;
using CartService.Api.Infrastructure.Services;
using CartService.Api.Infrastructure.Services.Abstractions;
using SharedLibrary.ExceptionHandlers;

namespace CartService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.AddMemoryCache();

            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<ICartService, Infrastructure.Services.CartService>();
            builder.Services.AddScoped<ICheckoutService, CheckoutService>();
            
            builder.Services.AddHttpClients(builder.Configuration);

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
