using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class CategoryCrudVc : ViewComponent
    {
        private ICategory catRepo;

        public CategoryCrudVc(ICategory catRepository)
        {
            catRepo = catRepository;
        }

        public IViewComponentResult Invoke()
        {
            var catVm = new CategoryViewModel();

            return View(catVm);
        }
    }
}
