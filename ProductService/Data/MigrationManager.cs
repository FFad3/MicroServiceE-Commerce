using Microsoft.EntityFrameworkCore;

namespace ProductService.Data
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var db = scope.ServiceProvider.GetRequiredService<AppDbContext>())
                {
                    try
                    {
                        var migrations = db.Database.GetPendingMigrations();
                        if (migrations.Any())
                            db.Database.Migrate();

                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }
            return host;
        }
    }
}