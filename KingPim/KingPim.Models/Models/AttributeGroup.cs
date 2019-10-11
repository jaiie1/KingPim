using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingPim.Models.Models
{
    public class AttributeGroup : ReadOnlyOneAttribute
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<OneAttribute> OneAttributes { get; set; } 
    }
}
