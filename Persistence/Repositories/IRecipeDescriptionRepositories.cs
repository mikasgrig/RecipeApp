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
        void Add(RecipeDescription item);
        void Edit(RecipeDescription itiem);
        void Delete(int id);
        void DeleteAll();

    }
}
