using KingPim.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KingPim.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AttributeGroup> AttributeGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OneAttribute> OneAttributes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOneAttributeValue> ProductOneAttributeValues { get; set; }
        public DbSet<SubCategoryAttributeGroup> SubCategoryAttributeGroups { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<PredefinedAttrList> PredefinedAttrLists { get; set; }
        public DbSet<PredefinedAttrListOptions> PredefinedAttrListOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.SetNull;
            }

            base.OnModelCreating(modelbuilder);
        }
    }
}
