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

        public async Task<int> CreateAsync(RecipeJoin recipe)
        {
            var  isertDescriptionTask = _recipesDescriptRepositories.Add(new RecipeDescription
            {
                Description = recipe.Description
            });
            var isertRecipeTask = _recipesRepositories.Add(new RecipeWriteModels
            {
                Name = recipe.Name,
                Difficulty = recipe.Difficulty,
                DateCreated = recipe.DateCreated,
                TimeToComplete = recipe.TimeToComplete
            });
            await Task.WhenAll(isertRecipeTask, isertDescriptionTask);
            return await isertRecipeTask;

        }

        public void DeleteById(int id)
        {
            _recipesRepositories.Delete(id);
            _recipesDescriptRepositories.Delete(id);
        }

        public async Task<int> EditAsync(int id, string name, string description, int timeSpan)
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
                        TimeToComplete = new TimeSpan(00, timeSpan, 00)
                    };
                    newrecipeDescription = new RecipeDescription
                    {
                        IdRecipe = id,
                        Description = description
                    };
                }
            }
            var editRecipe =_recipesRepositories.Edit(newrecipe);
            var editRecipeDiscription = _recipesDescriptRepositories.Edit(newrecipeDescription);
            await Task.WhenAll(editRecipe, editRecipeDiscription);

            return await editRecipe;
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
