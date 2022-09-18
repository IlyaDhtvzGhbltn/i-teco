using CRMManager.Web.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CRMManager.Web.Infrastructure;
using CRMManager.Web.Services.Interface;
using CRMManager.Web.Services;

namespace CRMManager.Web.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection serviceCollection, IConfiguration config) 
        {
            IFactory<CRMManagerDbContext> factory = CreateFactoryDBContext(config);
            serviceCollection.AddSingleton<IContactsService>(new ContactsService(factory));
        }


        public static void AddDbContext(this IServiceCollection serviceCollection, IConfiguration config)
        {
            serviceCollection.AddDbContext<CRMManagerDbContext>(options =>
                options.UseSqlServer(config[AppSettings.ConnectionString]));

            serviceCollection.AddSingleton<IFactory<CRMManagerDbContext>>(CreateFactoryDBContext(config));
        }

        private static IFactory<CRMManagerDbContext> CreateFactoryDBContext(IConfiguration configuration)
        {
            return new DbFactory<CRMManagerDbContext>(() =>
            {
                var optBuilder = new DbContextOptionsBuilder<CRMManagerDbContext>();
                optBuilder.UseSqlServer(configuration[AppSettings.ConnectionString]);
                optBuilder.EnableSensitiveDataLogging();
                return new CRMManagerDbContext(optBuilder.Options);
            });
        }
    }
}
