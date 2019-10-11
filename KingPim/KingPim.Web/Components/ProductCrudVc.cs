using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class ProductCrudVc : ViewComponent
    {
        private IProduct prodRepo;

        public ProductCrudVc(IProduct prodRepository)
        {
            prodRepo = prodRepository;
        }

        public IViewComponentResult Invoke(ProductViewModel vm)
        {
            var prodVm = new ProductViewModel();

            return View(vm);
        }
    }
}
