using Microsoft.Extensions.DependencyInjection;
using Patent.Application.Interfaces;
using Patent.Application.Services;

namespace Patent.Application
{
    public static class DepedencyInjetion
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPatentService, PatentService>();
            return services;
        }
    }
}
