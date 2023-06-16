using ProductService.Data;
using Serilog;
using Serilog.Events;

namespace ProductService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var asmName = typeof(Program).Assembly.GetName().Name;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Assembly", asmName!)
                .WriteTo.Seq(serverUrl: "http://seq:5341")
                .WriteTo.Console()
                .CreateLogger();
            try
            {
                Log.Information("Starting web application");
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.RegisterAllServices(builder.Environment, builder.Configuration);
                
                // Set logger as SeriLog
                builder.Logging.ClearProviders();
                builder.Host.UseSerilog();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                PrepDb.PrepPopulation(app);

                app.Run();
            }
            catch (Exception ex)
            {
                // NLog: catch setup errors
                Log.Fatal(ex, "Application terminated unexpectedly");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                Log.CloseAndFlush();
            }
        }
    }
}