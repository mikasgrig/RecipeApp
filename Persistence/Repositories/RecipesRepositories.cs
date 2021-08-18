using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Models.WriteModels;

namespace Persistence.Repositories
{

    public class RecipesRepositories : IRecipesRepositories
    {
        private readonly ISqlClient _sqlClient;
        private readonly string TableName;
        public RecipesRepositories(ISqlClient sqlClient)
        {
            _sqlClient = sqlClient;
            TableName = "recipes";
        }
        public Task<int> Add(RecipeWriteModels item)
        {
            var sql = $"INSERT INTO {TableName} (Name, Difficulty, TimeSpan, DateCreated)  VALUES  (@Name, @Difficulty, @TimeSpan, @DateCreated)";
            return _sqlClient.ExecuteAsync(sql, item);
        }

        public Task<int> Delete(int id)
        {
            var sql = $"DELETE FROM {TableName} WHERE id = @id";
            return _sqlClient.ExecuteAsync(sql, new { id });
        }

        public Task<int> DeleteAll()
        {
            
            var sql = "ALTER TABLE `recipes`.`recipes` AUTO_INCREMENT = 1 ";
            _sqlClient.ExecuteAsync(sql);
            sql = $"DELETE FROM {TableName}";
            return _sqlClient.ExecuteAsync(sql);
        }

        public Task<int> Edit(RecipeWriteModels itiem)
        {

            var sql = $"UPDATE {TableName} SET Name = @Name, timeSpan = @timeSpan WHERE id = @id";
            var parametr = new { itiem.Name, itiem.TimeToComplete, itiem.Id };
            return _sqlClient.ExecuteAsync(sql, parametr);
        }

        public Task<IEnumerable<T>> GetAll<T>()
        {
            var sql = @$"SELECT *
                      FROM recipes
                      INNER JOIN recipedescription ON recipes.id = recipedescription.idRecipe";
            return _sqlClient.QueryAsync<T>(sql);
        }
        public Task<IEnumerable<T>> OrderAndShort<T>(string type, string shortCustomer)
        {
            var sql = @$"SELECT *
                      FROM recipes
                      INNER JOIN recipedescription ON recipes.id = recipedescription.idRecipe
                      ORDER BY {type} {shortCustomer}";
            return _sqlClient.QueryAsync<T>(sql);
        }
    }
}
