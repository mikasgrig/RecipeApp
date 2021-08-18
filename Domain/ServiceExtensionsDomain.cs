using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class ServiceExtensionsDomain
    {
        
      public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services
                .AddService();
             

        }
        private static IServiceCollection AddService(this IServiceCollection services)
        {
            return services
                .AddSingleton<IRecipeService, RecipeService>();
        }
    }
}
