using Domain;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Persistence;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services
                .AddPersistence()
                .AddDomain();
            services.AddSingleton<RecipeApp>();
            
            return services.BuildServiceProvider();
        }
       
    }
}
