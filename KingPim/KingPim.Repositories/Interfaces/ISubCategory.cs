using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System.Collections.Generic;

namespace KingPim.Repositories.Interfaces
{
    public interface ISubCategory
    {
        IEnumerable<SubCategory> GetAll();
        SubCategory Get(int id);
        void Add(SubCategoryViewModel newSubCategory);
        void Update(SubCategoryViewModel updateSubCategory);
        void Publish(SubCategoryViewModel publishSubCategory);
        SubCategory Delete(int id);
    }
}
