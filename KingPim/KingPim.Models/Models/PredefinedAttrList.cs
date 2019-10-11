using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.Models
{
    public class PredefinedAttrList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<PredefinedAttrListOptions> PredefinedAttrListOptions {get; set;}
    }
}
