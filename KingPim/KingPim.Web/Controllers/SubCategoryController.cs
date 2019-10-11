using KingPim.Models.ViewModels;
using KingPim.Repositories;
using KingPim.Repositories.Interfaces;
using KingPim.Web.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class SubCategoryController : Controller
    {
        private ISubCategory subCatrepo;
        private ICategory catRepo;
        private IAttributeGroup attrGroupRepo;

        public SubCategoryController(ISubCategory subCatRepository, ICategory catRepository, IAttributeGroup attrGroupRepository)
        {
            subCatrepo = subCatRepository;
            catRepo = catRepository;
            attrGroupRepo = attrGroupRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.EntityType = "SubCategory";

            var subCatVm = new SubCategoryViewModel
            {
                SubCategories = subCatrepo.GetAll(),
                Categories = catRepo.GetAll(),
                AttributeGroups = attrGroupRepo.GetAll()
            };

            return View(subCatVm);
        }

        [HttpPost]
        public IActionResult Add(SubCategoryViewModel vm)
        {
            subCatrepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(subCatrepo.Get(id));
        }

        [HttpPost]
        public IActionResult Update(SubCategoryViewModel vm)
        {
            subCatrepo.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Publish(SubCategoryViewModel vm)
        {
            subCatrepo.Publish(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deletedSubCategory = subCatrepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetAllSubCategoriesToJson(int id)
        {
            var allSubCategories = subCatrepo.GetAll();
            var getSubCategories = ExportHelper.GetSubCategoriesToXml(allSubCategories);
            var selSubCategory = getSubCategories.FirstOrDefault(sc => sc.Id.Equals(id));

            if (id == 0)
            {
                var subCatJson = JsonConvert.SerializeObject(getSubCategories);
                var subCatBytes = Encoding.UTF8.GetBytes(subCatJson);
                return File(subCatBytes, "application/octet-stream", "jsonsubcategories.json");
            }
            else
            {
                var selSubCatJson = JsonConvert.SerializeObject(selSubCategory);
                var subCatBytes = Encoding.UTF8.GetBytes(selSubCatJson);
                return File(subCatBytes, "application/octet-stream", "subcategoryid_" + id + ".json");
            }
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetAllSubCategoriesToXml(int id)
        {
            // Gets all the subcategories:
            var allSubCategories = subCatrepo.GetAll();
            // Sends us to the XmlHelper method:
            var getSubCategoriesToXml = ExportHelper.GetSubCategoriesToXml(allSubCategories);
            var specificSubCategory = getSubCategoriesToXml.FirstOrDefault(sc => sc.Id.Equals(id));

            if (id == 0)
            {
                return Ok(getSubCategoriesToXml);
            }
            else
            {
                return Ok(specificSubCategory);
            }
        }
    }
}