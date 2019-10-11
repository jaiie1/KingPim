using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingPim.Repositories.Repositories
{
    public class ProductRepository : IProduct
    {
        private ApplicationDbContext _ctx;

        public ProductRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(ProductViewModel vm)
        {
            if (vm.Id == 0)
            {
                var newProduct = new Product
                {
                    Name = vm.Name,
                    SubCategoryId = vm.SubCategoryId,
                    Description = vm.Description,
                    Price = vm.Price,
                    SubCategory = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                    Version = 1,
                    ModifiedByUser = vm.ModifiedByUser
                };
                _ctx.Products.Add(newProduct);
            }
            _ctx.SaveChanges();
        }

        public void Update(ProductViewModel vm)
        {
            var ctxProduct = _ctx.Products.FirstOrDefault(p => p.Id.Equals(vm.Id));
            if (ctxProduct != null)
            {
                ctxProduct.Name = vm.Name;
                ctxProduct.Description = vm.Description;
                ctxProduct.Price = vm.Price;
                ctxProduct.SubCategoryId = vm.SubCategoryId;
                ctxProduct.UpdatedDate = DateTime.Now;
                ctxProduct.Version++;
                ctxProduct.ModifiedByUser = vm.ModifiedByUser;
            }
            _ctx.SaveChanges();
        }

        public void AddProductOneAttributeValue(ProductViewModel vm)
        {
            if (vm.Id == 0)
            {
                var listrow = _ctx.ProductOneAttributeValues.FirstOrDefault(x => x.OneAttributeId.Equals(vm.OneAttributeId) && x.ProductId.Equals(vm.ProductId));
                if (listrow == null)
                {
                    var productOneAttributevalue = new ProductOneAttributeValue
                    {
                        Value = vm.Value,
                        OneAttributeId = vm.OneAttributeId,
                        ProductId = vm.ProductId
                    };
                    _ctx.ProductOneAttributeValues.Add(productOneAttributevalue);
                }
                else
                {
                    _ctx.ProductOneAttributeValues.Remove(listrow);
                    _ctx.SaveChanges();
                    var newProdAttrVal = new ProductOneAttributeValue
                    {
                        Value = vm.Value,
                        OneAttributeId = vm.OneAttributeId,
                        ProductId = vm.ProductId
                    };
                    _ctx.ProductOneAttributeValues.Add(newProdAttrVal);
                }
            }
            _ctx.SaveChanges();
        }

        public void UpdateProductOneAttributeValue(ProductViewModel vm)
        {
            var ctxProductOneAttributeValue = _ctx.ProductOneAttributeValues.FirstOrDefault(pav => pav.Id.Equals(vm.Id));
            if (ctxProductOneAttributeValue != null)
            {
                ctxProductOneAttributeValue.Value = vm.Value;
                ctxProductOneAttributeValue.ProductId = vm.ProductId;
                ctxProductOneAttributeValue.OneAttributeId = vm.OneAttributeId;
            }
            _ctx.SaveChanges();
        }

        public Product Delete(int id)
        {
            var ctxProduct = _ctx.Products.FirstOrDefault(p => p.Id.Equals(id));

            if (ctxProduct != null)
            {
                _ctx.Products.Remove(ctxProduct);
                _ctx.SaveChanges();
            }
            return ctxProduct;
        }

        public Product Get(int id)
        {
            return _ctx.Products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _ctx.Products;
        }

        public void GetSubCategories(ProductViewModel vm)
        {
            var prodVm = new ProductViewModel
            {
                Id = vm.Id,
                Name = vm.Name,
                SubCategoryId = vm.SubCategoryId
            };
        }

        public void Publish(ProductViewModel vm)
        {
            var ctxProduct = _ctx.Products.FirstOrDefault(p => p.Id.Equals(vm.Id));
            if (ctxProduct != null)
            {
                // The products subcategory.
                var ctxSubcategory = _ctx.SubCategories.FirstOrDefault(s => s.Id.Equals(ctxProduct.SubCategoryId));             
               
                if (!ctxProduct.Published)
                {
                    ctxProduct.Published = true;
                    ctxSubcategory.Published = true;
                    
                }
                else
                {
                    ctxProduct.Published = false;
                    // If all the subcategory products have false (unpublished) for all products, then the subcategory needs to also be false (unpublished).
                    if (ctxSubcategory.Products.Count(p => p.Published) == 0)
                    {
                        ctxSubcategory.Published = false;
                    }                    
                }
                _ctx.SaveChanges();
            }
        }
    }
}