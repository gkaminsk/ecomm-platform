using SharedLibrary.ExceptionHandlers;

namespace eComm.Platform.EventProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.AddHealthChecks();


            var app = builder.Build();

            app.UseHttpsRedirection();
            app.MapHealthChecks("health");

            app.MapGet("", (HttpContext httpContext) =>
            {
                var result = new
                {
                    Service = typeof(Program).Assembly.GetName().Name,
                    @Version = typeof(Program).Assembly.GetName()?.Version?.ToString(),
                    Date = $"{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss")} UTC",
                };

                return result;
            })
            .WithOpenApi();

            app.UseExceptionHandler();

            app.Run();
        }
    }
}
