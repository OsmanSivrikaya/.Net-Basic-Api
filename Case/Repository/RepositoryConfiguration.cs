using Case.Repository.Interface;

namespace Case.Repository
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection SetRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IDemandRepository, DemandRepository>();
            return services;
        }
    }
}
