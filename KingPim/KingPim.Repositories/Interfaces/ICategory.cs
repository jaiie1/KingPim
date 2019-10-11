using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System.Collections.Generic;

namespace KingPim.Repositories
{
    public interface ICategory
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        void Add(CategoryViewModel newCategory);
        void Update(CategoryViewModel updateCategory);
        void Publish(CategoryViewModel publishCategory);
        Category Delete(int id);
    }
}
