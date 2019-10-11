using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System.Collections.Generic;

namespace KingPim.Repositories.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        void Add(ProductViewModel newProduct);
        void Update(ProductViewModel updateProduct);
        void Publish(ProductViewModel publishProduct);
        Product Delete(int id);
        void AddProductOneAttributeValue(ProductViewModel addOneAttributeValueProduct);
        void UpdateProductOneAttributeValue(ProductViewModel updateOneAttributeValueProduct);
    }
}
