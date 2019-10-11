using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class AttributeGroupController : Controller
    {
        private IAttributeGroup attrGroupRepo;
        private ISubCategory subCatRepo;
        private IOneAttribute oneAttrRepo;

        public AttributeGroupController(IAttributeGroup attrGroupRepository, ISubCategory subCatRepository, IOneAttribute oneAttrRepository)
        {
            attrGroupRepo = attrGroupRepository;
            subCatRepo = subCatRepository;
            oneAttrRepo = oneAttrRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var attrGroupVm = new AttributeGroupViewModel
            {
                AttributeGroups = attrGroupRepo.GetAll(),
                SubCategories = subCatRepo.GetAll(),
                OneAttributes = oneAttrRepo.GetAll()
            };
            return View(attrGroupVm);
        }

        [HttpPost]
        public IActionResult Add(AttributeGroupViewModel vm)
        {
            attrGroupRepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(attrGroupRepo.Get(id));
        }

        [HttpPost]
        public IActionResult Update(AttributeGroupViewModel vm)
        {
            attrGroupRepo.Update(vm);
            var url = Url.Action("Index", "AttributeGroup");
            return Json(url);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleteAttrGroup = attrGroupRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}