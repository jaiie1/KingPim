using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class AttributeGroupCrudVc : ViewComponent
    {
        private IAttributeGroup attrGroupRepo;

        public AttributeGroupCrudVc(IAttributeGroup attrGroupRepository)
        {
            attrGroupRepo = attrGroupRepository;
        }

        public IViewComponentResult Invoke(AttributeGroupViewModel vm)
        {
            var attrGroupVm = new AttributeGroupViewModel();

            return View(vm);
        }
    }
}
