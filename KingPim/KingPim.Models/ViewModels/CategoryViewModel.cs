using KingPim.Models.Models;
using System.Collections.Generic;

namespace KingPim.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Published { get; set; }
        public int CategoryId { get; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<SubCategoryViewModel> SubCategories { get; set; }
        public double Version { get; set; }
        public string ModifiedByUser { get; set; }
    }
}
