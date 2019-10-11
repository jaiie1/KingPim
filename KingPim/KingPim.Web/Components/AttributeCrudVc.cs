using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class AttributeCrudVc : ViewComponent
    {
        private readonly IOneAttribute oneAttrRepo;

        public AttributeCrudVc(IOneAttribute oneAttrRepository)
        {
            oneAttrRepo = oneAttrRepository;
        }

        public IViewComponentResult Invoke(OneAttributeViewModel vm)
        {
            var oneAttrVm = new OneAttributeViewModel();

            return View(vm);
        }
    }
}
