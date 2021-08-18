using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            return services
                .AddSql()
                .AddReposotories();
                
        }
        private static IServiceCollection AddReposotories(this IServiceCollection services)
        {
            return services
            .AddSingleton<IRecipesRepositories, RecipesRepositories>()
            .AddSingleton<IRecipeDescriptionRepositories, RecipeDescriptionRepositories>();

        }

        private static IServiceCollection AddSql(this IServiceCollection service)
        {
            var connectionStringBuilder = new MySqlConnectionStringBuilder();
            connectionStringBuilder.Server = "Localhost";
            connectionStringBuilder.Port = 3306;
            connectionStringBuilder.UserID = "testas";
            connectionStringBuilder.Password = "Testas2020;";
            connectionStringBuilder.Database = "recipes";
            var connectionString = connectionStringBuilder.GetConnectionString(true);
            var sqlclient = new SqlClient(connectionString);
            return service.AddTransient<ISqlClient>(_ => new SqlClient(connectionString)); ;
        }
    }
}
