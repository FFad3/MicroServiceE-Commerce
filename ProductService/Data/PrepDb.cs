using Microsoft.Extensions.Configuration.UserSecrets;
using ProductService.Models;
using Serilog;

namespace ProductService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScrope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScrope.ServiceProvider.GetService<AppDbContext>();

                if (context != null)
                    SeedData(context);
            }
        }

        private static void SeedData(AppDbContext context)
        {
            var logger = Log.ForContext(typeof(PrepDb));
            if (!context.Products.Any())
            {
                var rnd = new Random();
                logger.Information("seeding data for products");

                var products = Enumerable.Range(1, 10)
                    .Select(i =>
                    new Product
                    {
                        Id = i,
                        Name = $"Product[{i}]",
                        Price = Math.Round(rnd.NextDouble() * rnd.Next(70, 100), 2)
                    });
                context.Products.AddRange(products);

                context.SaveChanges();
            }
            else
            {
                logger.Information( "no seed data already exists");
            }
        }
    }
}