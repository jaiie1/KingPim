using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KingPim.Web.Components
{
    public class ProductDetailsVc : ViewComponent
    {
        private IProduct prodRepo;
        private ISubCategory subCatRepo;
        private IAttributeGroup attrGroupRepo;
        private IOneAttribute OneAttributeRepo;

        public ProductDetailsVc(IProduct prodRepository, ISubCategory subCatRepository, IAttributeGroup attrGroupRepository, IOneAttribute oneAttrRepository)
        {
            prodRepo = prodRepository;
            subCatRepo = subCatRepository;
            attrGroupRepo = attrGroupRepository;
            OneAttributeRepo = oneAttrRepository;
        }

        public IViewComponentResult Invoke(int id)
        {
            if (id == 0)
            {
                var prodDetailsVm = new ProductDetailsViewModel()
                {
                    Product = prodRepo.Get(id),
                    AttributeGroup = attrGroupRepo.Get(id),
                    OneAttribute = OneAttributeRepo.Get(id)
                };

                return View(prodDetailsVm);
            }
            else
            {
                var prod = prodRepo.Get(id);
                var prodSub = subCatRepo.Get(prod.Id);
                var attrGroup = attrGroupRepo.Get(prodSub.Id);

                return View();
            }
        }
    }
}
