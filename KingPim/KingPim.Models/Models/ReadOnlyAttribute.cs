using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingPim.Models.Models
{
    public class ReadOnlyOneAttribute
    {
        [Column(Order = 777)]
        public DateTime AddedDate { get; set; }
        [Column(Order = 888)]
        public DateTime UpdatedDate { get; set; }
        [Column(Order = 999)]
        public bool Published { get; set; }
        public double Version { get; set; }
        public string ModifiedByUser { get; set; }
    }
}
