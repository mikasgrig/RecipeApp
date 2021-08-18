using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistence.Repositories
{
    public class RecipeDescriptionRepositories : IRecipeDescriptionRepositories
    {
        private readonly ISqlClient _sqlClient;
        private readonly string TableName;
        public RecipeDescriptionRepositories(ISqlClient sqlClient)
        {
            _sqlClient = sqlClient;
            TableName = "recipedescription";
        }
        public Task<int> Add(RecipeDescription item)
        {
            var sql = $"INSERT INTO {TableName} (Description)  VALUES  (@Description)";
            return _sqlClient.ExecuteAsync(sql, item);
        }

        public Task<int> Delete(int id)
        {
            var sql = $"DELETE FROM {TableName} WHERE idRecipe = @id";
            return _sqlClient.ExecuteAsync(sql, new { id });
        }

        public Task<int> DeleteAll()
        {
           
            var sql = "ALTER TABLE `recipes`.`recipedescription` AUTO_INCREMENT = 1 ";
            _sqlClient.ExecuteAsync(sql);
            sql = $"DELETE FROM {TableName}";
            return _sqlClient.ExecuteAsync(sql);
            
        }

        public Task<int> Edit(RecipeDescription itiem)
        {
            var sql = $"UPDATE {TableName} SET Description = @Description WHERE IdRecipe = @IdRecipe";
            var parametr = new { itiem.Description, itiem.IdRecipe };
            return _sqlClient.ExecuteAsync(sql, parametr);
        }

        public Task<IEnumerable<T>> GetAll<T>()
        {
            var sql = $"SELECT * FROM {TableName}";
            return _sqlClient.QueryAsync<T>(sql);
        }
    }
}
