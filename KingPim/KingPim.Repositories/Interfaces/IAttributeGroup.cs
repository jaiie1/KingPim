using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System.Collections.Generic;

namespace KingPim.Repositories.Interfaces
{
    public interface IAttributeGroup
    {
        IEnumerable<AttributeGroup> GetAll();
        AttributeGroup Get(int id);
        void Add(AttributeGroupViewModel newAttributeGroup);
        void Update(AttributeGroupViewModel updateAttributeGroup);
        void Publish(AttributeGroupViewModel publishAttributeGroup);
        AttributeGroup Delete(int id);
    }
}
