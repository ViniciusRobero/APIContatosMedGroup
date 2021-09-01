using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prova.Infrastructure.Data.Contexts;
using Prova.Infrastructure.Data.Repositories;
using Prova.Infrastructure.Data.Repositories.Interfaces;

namespace Prova.Infrastructure.IoC
{
    public static class IoCInfrastructure
    {
        private const string ConnectionStringKey = "CONNECTION_STRING";
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProvaContext>(options =>
                        options.UseLazyLoadingProxies().UseSqlServer(configuration.GetValue<string>(ConnectionStringKey)));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddScoped<IContatoRepository, ContatoRepository>();    
    }
}
