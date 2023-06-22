using System.Reflection;
using ECommerce.Common.Settings;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Common.MassTransit
{
    public static class Extenstions
    {
        public static IServiceCollection AddMassTransientWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(configure =>
            {
                configure.AddConsumers(Assembly.GetEntryAssembly());

                configure.UsingRabbitMq((context, configurator) =>
                {
                    var configuration = context.GetService<IConfiguration>() ?? throw new ArgumentNullException(nameof(IConfiguration));

                    var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>()
                        ?? throw new ArgumentNullException(nameof(ServiceSettings));

                    var rabbitMQSettings = configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>()
                        ?? throw new ArgumentNullException(nameof(RabbitMQSettings));

                    configurator.Host(rabbitMQSettings.HostName);
                    configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));
                    configurator.UseMessageRetry(retryConfigurator =>
                    {
                        retryConfigurator.Interval(3, TimeSpan.FromSeconds(5));
                    });
                });
            });

            return services;
        }
    }
}