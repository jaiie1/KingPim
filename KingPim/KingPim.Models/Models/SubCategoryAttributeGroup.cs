
namespace KingPim.Models.Models
{
    public class SubCategoryAttributeGroup
    {
        public int Id { get; set; }
        public int? SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public int? AttributeGroupId { get; set; }
        public virtual AttributeGroup AttributeGroup { get; set; }
    }
}
