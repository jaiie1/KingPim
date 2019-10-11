using KingPim.Models.ViewModels;
using KingPim.Repositories;
using KingPim.Web.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategory catRepo;

        public CategoryController(ICategory catRepository)
        {
            catRepo = catRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.EntityType = "Category";

            var catVm = new CategoryViewModel
            {
                Categories = catRepo.GetAll(),
            };
            return View(catVm);
        }

        [HttpPost]
        public IActionResult Add(CategoryViewModel vm)
        {
            catRepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(catRepo.Get(id));
        }

        [HttpPost]
        public IActionResult Update(CategoryViewModel vm)
        {
            vm.ModifiedByUser = User.Identity.Name;
            catRepo.Update(vm);
            var url = Url.Action("Index", "Category");
            return Json(url);
        }

        [HttpPost]
        public IActionResult Publish(CategoryViewModel vm)
        {
            catRepo.Publish(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deletedCategory = catRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetAllCategoriesToJson(int id)
        {
            var allCategories = catRepo.GetAll();
            var getCategories = ExportHelper.GetCategoriesToXml(allCategories);
            var selCategory = getCategories.FirstOrDefault(c => c.Id.Equals(id));

            if (id == 0)
            {
                var catJson = JsonConvert.SerializeObject(getCategories);
                var catBytes = Encoding.UTF8.GetBytes(catJson);
                return File(catBytes, "application/octet-stream", "jsoncategories.json");
            }
            else
            {
                var selCatJson = JsonConvert.SerializeObject(selCategory);
                var catBytes = Encoding.UTF8.GetBytes(selCatJson);
                return File(catBytes, "application/octet-stream", "categoryid_" + id + ".json");
            }
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetAllCategoriesToXml(int id)
        {
            // Gets all the categories:
            var allCategories = catRepo.GetAll();

            // Sends us to the XmlHelper method:
            var getCategoriesToXml = ExportHelper.GetCategoriesToXml(allCategories);
            var specificCategory = getCategoriesToXml.FirstOrDefault(c => c.Id.Equals(id));

            if (id == 0)
            {
                return Ok(getCategoriesToXml);
            }
            else
            {
                return Ok(specificCategory);
            }
        }
    }
}