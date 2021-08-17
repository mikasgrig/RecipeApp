﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IRecipeService
    {
        public Task<IEnumerable<RecipeJoin>> GetAllAsync();
        public void Create(RecipeJoin note);
        public Task EditAsync(int id, string name, string description, int timeSpan);
        public void DeleteById(int id);
        public void ClearAll();
        public Task<IEnumerable<RecipeJoin>> OrderAndShort(string type, string form);
    }
}
