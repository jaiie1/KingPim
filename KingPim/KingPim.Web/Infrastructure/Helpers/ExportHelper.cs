using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System.Collections.Generic;

namespace KingPim.Web.Infrastructure.Helpers
{
    public class ExportHelper
    {
        public static List<CategoryViewModel> GetCategoriesToXml(IEnumerable<Category> allCategories)
        {
            var catVmList = new List<CategoryViewModel>();

            foreach (var cat in allCategories)
            {
                catVmList.Add(
                    new CategoryViewModel
                    {
                        Id = cat.Id,
                        Name = cat.Name,
                        Published = cat.Published,
                        SubCategories = GetSubCategoriesToXml(cat.SubCategories)
                    });
            }
            return catVmList;
        }

        private static List<SubCategoryViewModel> GetSubCategoriesToXml(List<SubCategory> allSubCategories)
        {
            var subCatVmList = new List<SubCategoryViewModel>();

            foreach (var subCat in allSubCategories)
            {
                subCatVmList.Add(
                    new SubCategoryViewModel
                    {
                        Id = subCat.Id,
                        Name = subCat.Name,
                        Published = subCat.Published                        
                    });
            }
            return subCatVmList;
        }

        public static List<SubCategoryViewModel> GetSubCategoriesToXml(IEnumerable<SubCategory> allSubCategories)
        {
            var subCatVmList = new List<SubCategoryViewModel>();

            foreach (var subCat in allSubCategories)
            {
                subCatVmList.Add(
                    new SubCategoryViewModel
                    {
                        Id = subCat.Id,
                        Name = subCat.Name,
                        Published = subCat.Published,
                        Products = GetProductsToXml(subCat.Products)
                    });
            }
            return subCatVmList;
        }

        private static List<ProductViewModel> GetProductsToXml(List<Product> allProducts)
        {
            var prodVmList = new List<ProductViewModel>();

            foreach (var prod in allProducts)
            {
                prodVmList.Add(
                    new ProductViewModel
                    {
                        Id = prod.Id,
                        Name = prod.Name,
                        Published = prod.Published
                    });
            }
            return prodVmList;
        }

        public static List<ProductViewModel> GetProductsToXml(IEnumerable<Product> allProducts)
        {
            var prodVmList = new List<ProductViewModel>();

            foreach (var prod in allProducts)
            {
                prodVmList.Add(
                    new ProductViewModel
                    {
                        Id = prod.Id,
                        Name = prod.Name,
                        Published = prod.Published
                    });
            }
            return prodVmList;
        }
    }
}
