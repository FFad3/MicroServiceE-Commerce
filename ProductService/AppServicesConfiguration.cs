using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProductService.Contracts;
using ProductService.Data;
using ProductService.Services;
using Serilog;

namespace ProductService
{
    public static class AppServicesConfiguration
    {
        public static void RegisterAllServices(this IServiceCollection services, IWebHostEnvironment env, IConfiguration conf)
        {
            // Add services to the container.
            services.RegisterDbContext(env, conf);
            services.AddControllers();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddSingleton<IMessageProducer, MessageProducer>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void RegisterDbContext(this IServiceCollection services, IWebHostEnvironment env, IConfiguration conf)
        {
            var logger = Log.ForContext(typeof(AppServicesConfiguration));
            //Configure db context
            if (env.IsProduction())
            {
                logger.Information("service starts as Production => use sqlserver");
                services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(conf.GetConnectionString("ProductDbConn"))
                );
            }
            else
            {
                logger.Information("service starts as Production => use in memory database");
                services.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase("InMemProductDb")
                );
            }
        }
    }
}