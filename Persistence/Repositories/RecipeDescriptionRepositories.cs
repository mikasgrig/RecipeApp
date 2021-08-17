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
        public void Add(RecipeDescription item)
        {
            var sql = $"INSERT INTO {TableName} (Description)  VALUES  (@Description)";
            _sqlClient.Execute(sql, item);
        }

        public void Delete(int id)
        {
            var sql = $"DELETE FROM {TableName} WHERE idRecipe = @id";
            _sqlClient.Execute(sql, new { id });
        }

        public void DeleteAll()
        {
            var sql = $"DELETE FROM {TableName}";
            _sqlClient.Execute(sql);
            sql = "ALTER TABLE `recipes`.`recipedescription` AUTO_INCREMENT = 1 ";
            _sqlClient.Execute(sql);

        }

        public void Edit(RecipeDescription itiem)
        {
            var sql = $"UPDATE {TableName} SET Description = @Description WHERE IdRecipe = @IdRecipe";
            var parametr = new { itiem.Description, itiem.IdRecipe };
            _sqlClient.Execute(sql, parametr);
        }

        public Task<IEnumerable<T>> GetAll<T>()
        {
            var sql = $"SELECT * FROM {TableName}";
            return _sqlClient.Query<T>(sql);
        }
    }
}
