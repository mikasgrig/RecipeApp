using Persistence.Models;
using Persistence.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IRecipesRepositories
    {
        Task<IEnumerable<T>> GetAll<T>();
        Task<int> Add(RecipeWriteModels item);
        Task<int> Edit(RecipeWriteModels itiem);
        Task<int> Delete(int id);
        Task<int> DeleteAll();
        Task<IEnumerable<T>> OrderAndShort<T>(string type, string shortCustomer);
    }
}
