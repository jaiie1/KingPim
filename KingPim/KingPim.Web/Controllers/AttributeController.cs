using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class AttributeController : Controller
    {
        private IOneAttribute AttrRepo;
        private IAttributeGroup attGroupRepo;

        public AttributeController(IOneAttribute AttrRepository, IAttributeGroup attGroupRepository)
        {
            AttrRepo = AttrRepository;
            attGroupRepo = attGroupRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var oneAttrVm = new OneAttributeViewModel
            {
                OneAttributes = AttrRepo.GetAll(),
                AttributeGroups = attGroupRepo.GetAll()
            };
            return View(oneAttrVm);
        }

        [HttpPost]
        public IActionResult Add(OneAttributeViewModel vm)
        {
            AttrRepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(AttrRepo.Get(id));
        }

        [HttpPost]
        public IActionResult Update(OneAttributeViewModel vm)
        {
            AttrRepo.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deletedOneAttr = AttrRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}