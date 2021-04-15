using Fenicia.Application.Common.Interfaces;
using Fenicia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fenicia.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FeniciaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SQLServerConnection"),
                b => b.MigrationsAssembly(typeof(FeniciaDbContext).Assembly.FullName)));

            services.AddScoped<IFeniciaDbContext>(provider => provider.GetService<FeniciaDbContext>());

            return services;

        }
    }
}
