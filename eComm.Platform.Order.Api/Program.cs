
using SharedLibrary.ExceptionHandlers;

namespace Order.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
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
