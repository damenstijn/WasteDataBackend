using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WasteData.App.Interfaces;
using WasteData.Infra.Database;
using WasteData.Infra.Services;

namespace WasteData.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWasteDataContext>(provider => provider.GetService<WasteDataContext>());

            services.AddDbContext<WasteDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(WasteDataContext).Assembly.FullName)));
            services.AddTransient<ISqlConnectionFactory>(p => new SqlConnectionFactory(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IHttpService, HttpService>();


            return services;
        }
    }
}
