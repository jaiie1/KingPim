using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.Models
{
    public class PredefinedAttrListOptions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual int? OneAttributeId { get; set; }
        public virtual OneAttribute OneAttributes { get; set; }
    }
}
