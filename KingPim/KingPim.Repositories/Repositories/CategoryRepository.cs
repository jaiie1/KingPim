using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingPim.Repositories.Repositories
{
    public class CategoryRepository : ICategory
    {
        private ApplicationDbContext _ctx;
        private readonly UserManager<IdentityUser> _userManager;

        public CategoryRepository(ApplicationDbContext ctx, UserManager<IdentityUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public void Add(CategoryViewModel vm)
        {
            if (vm.Id == 0)
            {
                var newCategory = new Category
                {
                    Name = vm.Name,
                    SubCategories = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                    Version = 1,
                    ModifiedByUser = vm.ModifiedByUser
                };
                _ctx.Categories.Add(newCategory);
            }
            _ctx.SaveChanges();
        }

        public void Update(CategoryViewModel vm)
        {
            var ctxCategory = _ctx.Categories.FirstOrDefault(c => c.Id.Equals(vm.Id));

            if (ctxCategory != null)
            {
                ctxCategory.Name = vm.Name;
                ctxCategory.UpdatedDate = DateTime.Now;
                ctxCategory.Version++;
                ctxCategory.ModifiedByUser = vm.ModifiedByUser;
            }

            _ctx.SaveChanges();
        }

        public Category Delete(int id)
        {
            var ctxCategory = _ctx.Categories.FirstOrDefault(c => c.Id.Equals(id));
            if (ctxCategory != null)
            {
                _ctx.Categories.Remove(ctxCategory);
                _ctx.SaveChanges();
            }
            return ctxCategory;
        }

        public Category Get(int id)
        {
            return _ctx.Categories.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _ctx.Categories;
        }

        public void Publish(CategoryViewModel vm)
        {
            var ctxCategory = _ctx.Categories.FirstOrDefault(c => c.Id.Equals(vm.Id));

            if (ctxCategory != null)
            {
                if (!ctxCategory.Published)
                {
                    ctxCategory.Published = true;
                }
                else
                {
                    ctxCategory.Published = false;
                }
                _ctx.SaveChanges();

                var ctxSubCat = _ctx.SubCategories.Where(x => x.CategoryId.Equals(vm.Id));

                foreach (var subcat in ctxSubCat)
                {
                    if (ctxCategory.Published)
                    {
                        subcat.Published = true;
                    }
                    else
                    {
                        subcat.Published = false;
                    }
                }
                _ctx.SaveChanges();
            }
        }
    }
}