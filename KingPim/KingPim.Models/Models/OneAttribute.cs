using System.ComponentModel.DataAnnotations.Schema;

namespace KingPim.Models.Models
{
    public class OneAttribute : ReadOnlyOneAttribute
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public virtual AttributeGroup AttributeGroup { get; set; }
        public int? AttributeGroupId { get; set; }
    }
}
