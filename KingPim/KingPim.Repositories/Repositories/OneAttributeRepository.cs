using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingPim.Repositories.Repositories
{
    public class OneAttributeRepository : IOneAttribute
    {
        private ApplicationDbContext _ctx;

        public OneAttributeRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(OneAttributeViewModel vm)
        {
            if (vm.Id == 0)
            {
                var newAttr = new OneAttribute
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    Type = vm.Type,
                    AttributeGroupId = vm.AttributeGroupId,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                };
                _ctx.OneAttributes.Add(newAttr);
            }
            _ctx.SaveChanges();
        }

        public void Update(OneAttributeViewModel vm)
        {
            var ctxOneAttr = _ctx.OneAttributes.FirstOrDefault(a => a.Id.Equals(vm.Id));

            if (ctxOneAttr != null)
            {
                ctxOneAttr.Name = vm.Name;
                ctxOneAttr.Description = vm.Description;
                ctxOneAttr.Type = vm.Type;
                ctxOneAttr.UpdatedDate = DateTime.Now;
            }
            _ctx.SaveChanges();
        }

        public OneAttribute Delete(int id)
        {
            var ctxOneAttr = _ctx.OneAttributes.FirstOrDefault(a => a.Id.Equals(id));

            if (ctxOneAttr != null)
            {
                _ctx.OneAttributes.Remove(ctxOneAttr);
                _ctx.SaveChanges();
            }
            return ctxOneAttr;
        }

        public OneAttribute Get(int id)
        {
            return _ctx.OneAttributes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<OneAttribute> GetAll()
        {
            return _ctx.OneAttributes;
        }
    }
}