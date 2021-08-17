using System;
using System.Collections.Generic;
using Contract;
using MySql.Data.MySqlClient;
using Persistence;
using Persistence.Models;
using Microsoft.Extensions.DependencyInjection;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            var startapProvaider = startup.ConfigureServices();
            var recipeApp = startapProvaider.GetService<RecipeApp>();
            recipeApp.Start();
        }
    }
}
