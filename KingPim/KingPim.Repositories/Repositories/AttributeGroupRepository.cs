using KingPim.Data;
using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingPim.Repositories.Repositories
{
    public class AttributeGroupRepository : IAttributeGroup
    {
        private ApplicationDbContext _ctx;

        public AttributeGroupRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(AttributeGroupViewModel vm)
        {
            if (vm.Id == 0)
            {
                var newAttrGroup = new AttributeGroup
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    OneAttributes = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                };
                _ctx.AttributeGroups.Add(newAttrGroup);
            }
            _ctx.SaveChanges();
        }

        public void Update(AttributeGroupViewModel vm)
        {
            var ctxAttrGroup = _ctx.AttributeGroups.FirstOrDefault(attrg => attrg.Id.Equals(vm.Id));

            if (ctxAttrGroup != null)
            {
                ctxAttrGroup.Name = vm.Name;
                ctxAttrGroup.Description = vm.Description;
                ctxAttrGroup.UpdatedDate = DateTime.Now;
            }
            _ctx.SaveChanges();
        }

        public AttributeGroup Delete(int id)
        {
            var ctxAttrGroup = _ctx.AttributeGroups.FirstOrDefault(attrg => attrg.Id.Equals(id));

            if (ctxAttrGroup != null)
            {
                _ctx.AttributeGroups.Remove(ctxAttrGroup);
                _ctx.SaveChanges();
            }
            return ctxAttrGroup;
        }

        public AttributeGroup Get(int id)
        {
            return _ctx.AttributeGroups.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AttributeGroup> GetAll()
        {
            return _ctx.AttributeGroups;
        }

        public void Publish(AttributeGroupViewModel vm)
        {
            var ctxAttributeGroupViewModel = _ctx.AttributeGroups.FirstOrDefault(ag => ag.Id.Equals(vm.Id));

            if (ctxAttributeGroupViewModel != null)
            {
                ctxAttributeGroupViewModel.Id = vm.Id;
                ctxAttributeGroupViewModel.Published = vm.Published;
            }
            _ctx.SaveChanges();
        }
    }
}