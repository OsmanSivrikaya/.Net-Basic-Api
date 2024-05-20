using Case.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Case.Configuration
{
    public static class DatabaseStartup
    {
        public static IServiceCollection AddDatabaseModule(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionString, options => options.EnableRetryOnFailure()));
            return services;
        }
    }
}
