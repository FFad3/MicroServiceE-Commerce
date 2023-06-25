﻿using System.Reflection;
using ECommerce.Common.MassTransit;
using ECommerce.Common.Settings;
using Microsoft.EntityFrameworkCore;
using ProductService.Contracts;
using ProductService.Data;
using Serilog;

namespace ProductService
{
    public static class AppServicesConfiguration
    {
        public static void RegisterAllServices(this IServiceCollection services, IConfiguration conf)
        {
            // Add services to the container.
            services.RegisterDbContext(conf);
            services.AddControllers();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMassTransientWithRabbitMq();
        }

        private static void RegisterDbContext(this IServiceCollection services, IConfiguration conf)
        {
            var dbSettings = conf.GetSection(nameof(DbContextSettings)).Get<DbContextSettings>()
                ?? throw new ArgumentNullException(nameof(DbContextSettings));

            var logger = Log.ForContext(typeof(AppServicesConfiguration));
            //Configure db context
            if (dbSettings.UseInMemoryDB)
            {
                logger.Information("service starts as Production => use in memory database");
                services.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase(dbSettings.InMemoryDBName)
                );
            }
            else
            {
                logger.Information("service starts as Production => use sqlserver");
                services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(conf.GetConnectionString("dbConnection"))
                );
            }
        }
    }
}