using KingPim.Models.Models;
using System.Collections.Generic;

namespace KingPim.Models.ViewModels
{
    public class AttributeGroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        public int OneAttributeId { get; set; }
        public int AttributeGroupId { get; set; }
        public int SubCategoryId { get; set; }
        public IEnumerable<OneAttribute> OneAttributes { get; set; }
        public IEnumerable<AttributeGroup> AttributeGroups { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
