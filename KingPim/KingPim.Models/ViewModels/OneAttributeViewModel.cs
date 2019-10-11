using KingPim.Models.Models;
using System.Collections.Generic;

namespace KingPim.Models.ViewModels
{
    public class OneAttributeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int OneAttributeId { get; set; }
        public int AttributeGroupId { get; set; }
        public IEnumerable<OneAttribute> OneAttributes { get; set; }
        public IEnumerable<AttributeGroup> AttributeGroups { get; set; }

    }
}
