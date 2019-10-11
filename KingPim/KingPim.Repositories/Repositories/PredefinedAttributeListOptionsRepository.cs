using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using System.Collections.Generic;

namespace KingPim.Repositories.Repositories
{
    public class PredefinedOneAttributeListOptionsRepository : IPredefinedOneAttributeListOptions
    {
        private ApplicationDbContext _ctx;

        public PredefinedOneAttributeListOptionsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<PredefinedAttrListOptions> GetAllOptions()
        {
            return _ctx.PredefinedAttrListOptions;
        }

        public void CreateOptionToPredefinedList(ProductViewModel vm)
        {
            if (vm.Id == 0)
            {
                var newOptionToPredef = new PredefinedAttrListOptions
                {
                    OneAttributeId = vm.OneAttributeId,
                    Name = vm.Name
                };
                _ctx.PredefinedAttrListOptions.Add(newOptionToPredef);
            }
            _ctx.SaveChanges();
        }

        public void UpdateProductOneAttributeValue(ProductViewModel vm)
        {
        }

        public void AddOptionIfNotExists(ProductViewModel vm)
        {
            if (vm.Id == 0)
            {
                var newValueIfNotExists = new ProductOneAttributeValue
                {
                    OneAttributeId = vm.OneAttributeId,
                    ProductId = vm.ProductId,
                    Value = vm.Name
                };
                _ctx.ProductOneAttributeValues.Add(newValueIfNotExists);

                var newOptionIfNotExists = new PredefinedAttrListOptions
                {
                    OneAttributeId = vm.OneAttributeId,
                    Name = vm.Name
                };
                _ctx.PredefinedAttrListOptions.Add(newOptionIfNotExists);
            }
            _ctx.SaveChanges();
        }
    }
}