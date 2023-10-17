using LTMS.Domain.Service;
using LTMS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schm.Domain.Service;
using Schm.Infrastructure.Persistance.Repository;
using System.Reflection;


namespace Framework.DependencyConfig
{
    public class ApplicationConfig
    {
        public static ServiceProvider DoConfig(IServiceCollection services, IConfiguration configuration)
        {
            var connStr = configuration.GetConnectionString("SchmConnection");
            services.AddDbContext<SchmDbContext>(o => o.UseSqlServer(connStr));


            //uncomment below when we had repository
            services.Scan(scan => scan
                .FromAssemblies(typeof(ItemCatagoryRepository).GetTypeInfo().Assembly)
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan
                .FromAssemblies(typeof(ItemCatagoryService).GetTypeInfo().Assembly)
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

           return services.BuildServiceProvider();
        }
    }
}
