using System.ComponentModel.DataAnnotations.Schema;

namespace KingPim.Models.Models
{
    public class ProductOneAttributeValue
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual OneAttribute OneAttribute { get; set; }
        public int? OneAttributeId { get; set; }
        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }
    }
}
