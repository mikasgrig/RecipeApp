using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RecipeJoin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public DateTime DateCreated { get; set; }
        public int IdRecipeDescription { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}  Name: {Name} Description: {Description} Time To Complete: {TimeSpan} Crate: {DateCreated}";
        }
    }
}
