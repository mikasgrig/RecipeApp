using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models.WriteModels
{
    public class RecipeWriteModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
