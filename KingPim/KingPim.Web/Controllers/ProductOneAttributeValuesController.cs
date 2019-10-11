using KingPim.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace KingPim.Web.Controllers
{
    [Authorize]
    public class ProductOneOneAttributeValuesController : Controller
    {
        private IProductOneAttributeValues prodOneAttrValRepo;

        public ProductOneOneAttributeValuesController(IProductOneAttributeValues prodOneAttrValRepository)
        {
            prodOneAttrValRepo = prodOneAttrValRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var prodAttrOneGroup = prodOneAttrValRepo.GetAll();
            return View(prodAttrOneGroup);
        }
    }
}
