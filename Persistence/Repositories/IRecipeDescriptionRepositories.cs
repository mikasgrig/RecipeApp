using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IRecipeDescriptionRepositories
    {
        Task<IEnumerable<T>> GetAll<T>();
        Task<int> Add(RecipeDescription item);
        Task<int> Edit(RecipeDescription itiem);
        Task<int> Delete(int id);
        Task<int> DeleteAll();

    }
}
