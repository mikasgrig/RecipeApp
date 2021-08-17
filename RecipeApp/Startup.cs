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
            AddSql(services);
            services.AddSingleton<IRecipeDescriptionRepositories, RecipeDescriptionRepositories>();
            services.AddSingleton<IRecipesRepositories, RecipesRepositories>();
            services.AddSingleton<IRecipeService, RecipeService>();
            services.AddSingleton<RecipeApp>();
            
            return services.BuildServiceProvider();
        }
        public IServiceCollection AddSql(IServiceCollection service)
        {

            var connectionStringBuilder = new MySqlConnectionStringBuilder();
            connectionStringBuilder.Server = "Localhost";
            connectionStringBuilder.Port = 3306;
            connectionStringBuilder.UserID = "testas";
            connectionStringBuilder.Password = "Testas2020;";
            connectionStringBuilder.Database = "recipes";
            var connectionString = connectionStringBuilder.GetConnectionString(true);
            var sqlclient = new SqlClient(connectionString);

            service.AddTransient<ISqlClient>(_ => new SqlClient(connectionString));
            return service;
        }
    }
}
