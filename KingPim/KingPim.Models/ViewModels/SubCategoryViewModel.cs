using KingPim.Models.Models;
using System.Collections.Generic;

namespace KingPim.Models.ViewModels
{
    public class SubCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Published { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public List<int> AttributeGroupId {get; set;}
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
        public IEnumerable<AttributeGroup> AttributeGroups { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public double Version { get; set; }
        public string ModifiedByUser { get; set; }
    }
}
