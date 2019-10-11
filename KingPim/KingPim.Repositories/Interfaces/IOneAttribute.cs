using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System.Collections.Generic;

namespace KingPim.Repositories.Interfaces
{
    public interface IOneAttribute
    {
        IEnumerable<OneAttribute> GetAll();
        OneAttribute Get(int id);
        void Add(OneAttributeViewModel newOneAttribute);
        void Update(OneAttributeViewModel updateOneAttribute);
        OneAttribute Delete(int id);
    }
}
