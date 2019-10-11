using KingPim.Models.Models;
using System.Collections.Generic;

namespace KingPim.Repositories.Interfaces
{
    public interface IProductOneAttributeValues
    {
        IEnumerable<ProductOneAttributeValue> GetAll();
    }
}
