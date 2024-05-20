using Case.Services.Interface;

namespace Case.Services
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection SetServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IDemandService, DemandService>();
            return services;
        }
    }
}
