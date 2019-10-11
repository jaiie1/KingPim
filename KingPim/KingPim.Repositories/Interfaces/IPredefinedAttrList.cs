using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Interfaces
{
    public interface IPredefinedAttrList
    {
        IEnumerable<PredefinedAttrList> GetAllLists();
    }
}
