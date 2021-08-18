using Domain.Models;
using Persistence.Models;
using Persistence.Models.WriteModels;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipesRepositories _recipesRepositories;
        private readonly IRecipeDescriptionRepositories _recipesDescriptRepositories;
       public RecipeService(IRecipesRepositories recipesRepositories, IRecipeDescriptionRepositories recipesDescriptRepositories)
        {
            _recipesRepositories = recipesRepositories;
            _recipesDescriptRepositories = recipesDescriptRepositories;
        }
        public void ClearAll()
        {
            _recipesRepositories.DeleteAll();
            _recipesDescriptRepositories.DeleteAll();
        }

        public Task<int> Create(RecipeJoin recipe)
        {
            var recipeDescript = new RecipeDescription
            {
                Description = recipe.Description
            };
            var recipenew = new RecipeWriteModels
            {
                Name = recipe.Name,
                Difficulty = recipe.Difficulty,
                DateCreated = recipe.DateCreated,
                TimeSpan = recipe.TimeSpan
            };
            _recipesDescriptRepositories.Add(recipeDescript);
            
            return _recipesRepositories.Add(recipenew);

        }

        public void DeleteById(int id)
        {
            _recipesRepositories.Delete(id);
            _recipesDescriptRepositories.Delete(id);
        }

        public async Task EditAsync(int id, string name, string description, int timeSpan)
        {
            var allrecipe = await GetAllAsync();
            RecipeWriteModels newrecipe = new RecipeWriteModels();
            RecipeDescription newrecipeDescription = new RecipeDescription();
            foreach (var item in allrecipe)
            {
                if (item.Id == id)
                {
                    newrecipe = new RecipeWriteModels
                    {
                        Id = item.Id,
                        DateCreated = item.DateCreated,
                        Difficulty = item.Difficulty,
                        Name = name,
                        TimeSpan = new TimeSpan(00, timeSpan, 00)
                    };
                    newrecipeDescription = new RecipeDescription
                    {
                        IdRecipe = id,
                        Description = description
                    };
                }
            }
            _recipesRepositories.Edit(newrecipe);
            _recipesDescriptRepositories.Edit(newrecipeDescription);


        }

        public Task<IEnumerable<RecipeJoin>> GetAllAsync()
        {
            
            return _recipesRepositories.GetAll<RecipeJoin>();
        }
        public Task<IEnumerable<RecipeJoin>> OrderAndShort(string type, string form)
        {
            return _recipesRepositories.OrderAndShort<RecipeJoin>(type, form);
        }
    }
}
