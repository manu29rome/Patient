using Microsoft.Extensions.DependencyInjection;
using Patent.Application.Interfaces;
using Patent.Infrastructure.Repositories;

namespace Patent.Infrastructure
{
    public static class DepedencyInjetion
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPatentRepository, PatentRepository>();
            return services;
        }
    }
}
