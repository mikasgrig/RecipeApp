using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    class RecipeApp
    {
        private readonly IRecipeService _recipeService;
        public RecipeApp(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        public async void Start()
        {
            
            Console.WriteLine("|    Your Recipes    |");
            Console.WriteLine("______________________");
            while (true)
            {
                Console.WriteLine("Choice Command:");
                Console.WriteLine("Pres 1 - Show all recipes");
                Console.WriteLine("Pres 2 - Add new recipe");
                Console.WriteLine("Pres 3 - Edit recipe");
                Console.WriteLine("Pres 4 - Delete one recipe");
                Console.WriteLine("Pres 5 - Delete all recipes");
                Console.WriteLine("Pres 6 - Exit");
                var choose = (Console.ReadLine());
                switch (choose)
                {
                    case "1":
                        Console.WriteLine("Pres 1 Order by: TimeToComplete");
                        Console.WriteLine("Pres 2 Order by: DateCreated");
                        choose = (Console.ReadLine());
                        switch (choose)
                        {
                            case "1":
                                Console.WriteLine("Pres 1 Sorting by: Ascending");
                                Console.WriteLine("Pres 2 Sorting by: Descending");
                                choose = (Console.ReadLine());
                                switch (choose)
                                {
                                    case "1":
                                        Console.WriteLine("Choose TimeTocomlete by Ascending");
                                        var allrecipes = await _recipeService.OrderAndShort("timeSpan", "ASC");
                                        foreach (var item in allrecipes)
                                        {
                                            Console.WriteLine(item.ToString());
                                        }
                                        break;
                                    case "2":
                                        Console.WriteLine("Choose TimeTocomlete by Descending");
                                        allrecipes = await _recipeService.OrderAndShort("timeSpan", "DESC");
                                        foreach (var item in allrecipes)
                                        {
                                            Console.WriteLine(item.ToString());
                                        }
                                        break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("Pres 1 Sorting by: Ascending");
                                Console.WriteLine("Pres 2 Sorting by: Descending");
                                choose = (Console.ReadLine());
                                switch (choose)
                                {
                                    case "1":
                                        Console.WriteLine("Choose DateCreated by Ascending");
                                        var allrecipes = await _recipeService.OrderAndShort("dateCreated", "ASC");
                                        foreach (var item in allrecipes)
                                        {
                                            Console.WriteLine(item.ToString());
                                        }
                                        break;
                                    case "2":
                                        Console.WriteLine("Choose DateCreated by Descending");
                                        allrecipes = await _recipeService.OrderAndShort("dateCreated", "DESC");
                                        foreach (var item in allrecipes)
                                        {
                                            Console.WriteLine(item.ToString());
                                        }
                                        break;
                                }
                                break;                        
                        }
                        break;
                    case "2":
                        Console.Write("Enter recipe Name: ");
                        var name = (Console.ReadLine());
                        Console.Write("Enter recipe Description: ");
                        var description = (Console.ReadLine());
                        Console.Write("Enter recipe Time minutes: ");
                        var timeSpan = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Choose Difficulty: ");
                        foreach (string s in Enum.GetNames(typeof(Contract.Difficulty)))
                            Console.WriteLine(s);
                        
                        
                        Console.Write("Enter Difficulty: ");
                        var difficulty = Convert.ToInt32(Console.ReadLine());
                        var recipeJoinNew = new RecipeJoin
                        {
                            Name = name,
                            Description = description,
                            Difficulty = Enum.GetName(typeof(Contract.Difficulty), difficulty),
                            TimeSpan = new TimeSpan(00, timeSpan, 00),
                            DateCreated = DateTime.Now
                        };
                        var numb = _recipeService.Create(recipeJoinNew);
                        Console.WriteLine($"irase {numb}");
                        break;
                    case "3":
                        var allrecipesl = await _recipeService.OrderAndShort("timeSpan", "ASC");
                        foreach (var item in allrecipesl)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.Write("Enter recipe Id: ");
                        var idChoose = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new recipe Name: ");
                        name = (Console.ReadLine());
                        Console.Write("Enter new recipe Description: ");
                        description = (Console.ReadLine());
                        Console.Write("Enter new recipe Time minutes: ");
                        timeSpan = Convert.ToInt32(Console.ReadLine());
                        _recipeService.EditAsync(idChoose, name, description, timeSpan);
                        break;
                    case "4":
                        var allrecipess = await _recipeService.GetAllAsync();
                        foreach (var item in allrecipess)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.Write("Enter recipe Id: ");
                        idChoose = Convert.ToInt32(Console.ReadLine());
                        _recipeService.DeleteById(idChoose);
                        break;
                    case "5":
                        _recipeService.ClearAll();
                        break;
                    case "6":
                        return;
                }
            }
            
        }
    }
}
