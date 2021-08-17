using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Add(Recipe item)
        {
            var sql = $"INSERT INTO {TableName} (Name, Difficulty, TimeSpan, DateCreated)  VALUES  (@Name, @Difficulty, @TimeSpan, @DateCreated)";
            _sqlClient.Execute(sql, item);
        }

        public void Delete(int id)
        {
            var sql = $"DELETE FROM {TableName} WHERE id = @id";
            _sqlClient.Execute(sql, new { id });
        }

        public void DeleteAll()
        {
            var sql = $"DELETE FROM {TableName}";
            _sqlClient.Execute(sql);
            sql = "ALTER TABLE `recipes`.`recipes` AUTO_INCREMENT = 1 ";
            _sqlClient.Execute(sql);
        }

        public void Edit(Recipe itiem)
        {

            var sql = $"UPDATE {TableName} SET Name = @Name, timeSpan = @timeSpan WHERE id = @id";
            var parametr = new { itiem.Name, itiem.TimeSpan, itiem.Id };
            _sqlClient.Execute(sql, parametr);
        }

        public Task<IEnumerable<T>> GetAll<T>()
        {
            var sql = @$"SELECT *
                      FROM recipes
                      INNER JOIN recipedescription ON recipes.id = recipedescription.idRecipe";
            return _sqlClient.Query<T>(sql);
        }
        public Task<IEnumerable<T>> OrderAndShort<T>(string type, string shortCustomer)
        {
            var sql = @$"SELECT *
                      FROM recipes
                      INNER JOIN recipedescription ON recipes.id = recipedescription.idRecipe
                      ORDER BY {type} {shortCustomer}";
            return _sqlClient.Query<T>(sql);
        }
    }
}
