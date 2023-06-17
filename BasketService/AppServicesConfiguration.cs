using System.Reflection;
using BasketService.Contracts;
using BasketService.Services;
using Redis.OM;

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
            services.AddSingleton(new RedisConnectionProvider("http://basket-redis:6379"));
            services.AddHostedService<IndexCreationService>();

            // Custom
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IBasketRepository, BasketRepository>();
        }
    }
}
