using Case.Helper.Api;

namespace Case.Helper
{
    public static class HelperConfiguration
    {
        public static IServiceCollection SetHelperConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IApiHelper, ApiHelper>();
            return services;
        }
    }
}
