using NoaFounding.Infrastructure.ExternalServices;
using SAPP.Gateway.Contracts.Utilities.ServiceCall;

namespace SAPP.Gateway.Web
{
    public static class StartUp
    {
        public static IServiceCollection AddApiService(this IServiceCollection services)
        {
            services.AddScoped<IServiceCall, ServiceCall>();
            services.AddScoped<HttpClient>();
            return services;
        }
    }
}
