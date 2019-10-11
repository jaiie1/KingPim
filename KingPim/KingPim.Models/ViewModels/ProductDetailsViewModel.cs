using KingPim.Models.Models;

namespace KingPim.Models.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public AttributeGroup AttributeGroupId { get; set; }
        public OneAttribute OneAttributeId { get; set; }
        public Product ProductId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }
        public OneAttribute OneAttribute { get; set; }
        public Product Product { get; set; }
    }
}
