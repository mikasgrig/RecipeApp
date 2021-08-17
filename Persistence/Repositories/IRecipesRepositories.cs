using Persistence.Models;
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
        void Add(Recipe item);
        void Edit(Recipe itiem);
        void Delete(int id);
        void DeleteAll();
        public Task<IEnumerable<T>> OrderAndShort<T>(string type, string shortCustomer);
    }
}
