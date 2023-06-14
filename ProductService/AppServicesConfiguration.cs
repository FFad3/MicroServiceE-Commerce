using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProductService.Contracts;
using ProductService.Data;

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
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void RegisterDbContext(this IServiceCollection services, IWebHostEnvironment env, IConfiguration conf)
        {
            //Configure db context
            if (env.IsProduction())
            {
                Console.WriteLine("--> Using SqlServer Db");
                services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(conf.GetConnectionString("ProductDbConn"))
                );
            }
            else
            {
                Console.WriteLine("--> Using InMem Db");
                services.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase("InMemProductDb")
                );
            }
        }
    }
}