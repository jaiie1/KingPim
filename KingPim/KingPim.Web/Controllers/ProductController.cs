using KingPim.Models.ViewModels;
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
    public class ProductController : Controller
    {
        private IProduct prodRepo;
        private ISubCategory subCatRepo;
        private IAttributeGroup attrGrRepo;
        private IProductOneAttributeValues prodOneAttrValRepo;
        private IPredefinedAttrList predefAttrListRepo;
        private IPredefinedOneAttributeListOptions predefAttrListOptionsRepo;

        public ProductController(IProduct prodRepository, ISubCategory subCatRepository, IAttributeGroup attrGrRepository, IProductOneAttributeValues prodOneattrValRepository, IPredefinedAttrList predefAttrListRepository, IPredefinedOneAttributeListOptions predefAttrListOptionsRepository)
        {
            prodRepo = prodRepository;
            subCatRepo = subCatRepository;
            attrGrRepo = attrGrRepository;
            prodOneAttrValRepo = prodOneattrValRepository;
            predefAttrListRepo = predefAttrListRepository;
            predefAttrListOptionsRepo = predefAttrListOptionsRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.EntityType = "Product";

            var prodVm = new ProductViewModel
            {
                Products = prodRepo.GetAll(),
                SubCategories = subCatRepo.GetAll(),
                AttributeGroups = attrGrRepo.GetAll()
            };

            return View(prodVm);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel vm)
        {
            prodRepo.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(prodRepo.Get(id));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel vm)
        {
            prodRepo.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddProductOneAttributeValue(ProductViewModel vm)
        {
            prodRepo.AddProductOneAttributeValue(vm);
            return RedirectToAction(nameof(Details), new { id = vm.ProductId });
        }

        [HttpPost]
        public IActionResult UpdateProductOneAttributeValue(ProductViewModel vm)
        {
            prodRepo.UpdateProductOneAttributeValue(vm);
            return RedirectToAction(nameof(Details), new { id = vm.ProductId });
        }

        [HttpPost]
        public IActionResult CreateOptionToPredefinedList(ProductViewModel vm)
        {
            predefAttrListOptionsRepo.CreateOptionToPredefinedList(vm);
            return RedirectToAction(nameof(Details), new { id = vm.ProductId });
        }

        [HttpPost]
        public IActionResult AddOptionIfNotExists(ProductViewModel vm)
        {
            predefAttrListOptionsRepo.AddOptionIfNotExists(vm);
            return RedirectToAction(nameof(Details), new { id = vm.ProductId });
        }

        [HttpPost]
        public IActionResult Publish(ProductViewModel vm)
        {
            prodRepo.Publish(vm);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var product = prodRepo.Get(id);
            var productOneAttrValue = prodOneAttrValRepo.GetAll().Where(p => p.ProductId == id);
            var preDefAttrList = predefAttrListRepo.GetAllLists();
            var preDefAttrListOptions = predefAttrListOptionsRepo.GetAllOptions();

            var prodDetVm = new ProductViewModel
            {
                ProductId = id,
                Name = product.Name,
                Description = product.Description,
                AddedDate = product.AddedDate,
                UpdatedDate = product.UpdatedDate,
                SubCategoryAttributeGroups = subCatRepo.Get(product.SubCategoryId ?? 0).SubCategoryAttributeGroups,
                ProductOneAttributeValues = productOneAttrValue,
                PredefinedAttrLists = preDefAttrList,
                PredefinedAttrListOptions = preDefAttrListOptions
            };
            return View(prodDetVm);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deletedProduct = prodRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetAllProductsToJson(int id)
        {
            var allProducts = prodRepo.GetAll();
            var getProducts = ExportHelper.GetProductsToXml(allProducts);
            var selProduct = getProducts.FirstOrDefault(p => p.Id.Equals(id));

            if (id == 0)
            {
                var prodJson = JsonConvert.SerializeObject(getProducts);
                var prodBytes = Encoding.UTF8.GetBytes(prodJson);
                return File(prodBytes, "application/octet-stream", "jsonproducts.json");
            }
            else
            {
                var selProdJson = JsonConvert.SerializeObject(selProduct);
                var prodBytes = Encoding.UTF8.GetBytes(selProdJson);
                return File(prodBytes, "application/octet-stream", "productid_" + id + ".json");
            }
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetAllProductsToXml(int id)
        {
            // Gets all the products:
            var allProducts = prodRepo.GetAll();

            // Sends us to the XmlHelper method:
            var getProductsToXml = ExportHelper.GetProductsToXml(allProducts);
            var specificProduct = getProductsToXml.FirstOrDefault(p => p.Id.Equals(id));

            if (id == 0)
            {
                return Ok(getProductsToXml);
            }
            else
            {
                return Ok(specificProduct);
            }
        }
    }
}