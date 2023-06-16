using System.Reflection;
using BasketService.Contracts;
using BasketService.Services;

namespace BasketService
{
    public static class AppServicesConfiguration
    {
        public static void RegisterAllServices(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            // Redis
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = "basket-redis:6379";
                opt.InstanceName = typeof(AppServicesConfiguration).Assembly.GetName().Name;
            });
            // Custom
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IBasketRepository, BasketRepository>();
        }
    }
}
