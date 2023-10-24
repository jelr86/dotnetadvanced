using System;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Catalog.Service.Infra.Database;
using Catalog.Service.App.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Catalog.Service.Infra
{
	public static class DependencyInjection
	{
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            
            services.AddDbContext<CatalogDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlite(connectionString);
            });

            services.AddScoped<ICatalogDbContext>(provider => provider.GetRequiredService<CatalogDbContext>());

            services.AddScoped<CatalogDbContextInitialiser>();
                        
            return services;
        }
    }
}

