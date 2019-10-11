using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingPim.Models.Models
{
    public class Category : ReadOnlyOneAttribute
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
