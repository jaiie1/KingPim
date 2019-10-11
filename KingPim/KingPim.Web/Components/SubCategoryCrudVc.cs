using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class SubCategoryCrudVc : ViewComponent
    {
        private ISubCategory subCatRepo;

        public SubCategoryCrudVc(ISubCategory subCatRepository)
        {
            subCatRepo = subCatRepository;
        }

        public IViewComponentResult Invoke(SubCategoryViewModel vm)
        {
            var subCatVm = new SubCategoryViewModel();

            return View(vm);
        }
    }
}
