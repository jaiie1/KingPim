using KingPim.Data;

namespace KingPim.Repositories.Repositories
{
    public class SubcategoryAttributeGroupViewModelRepository
    {
        private  ApplicationDbContext _ctx;
        public SubcategoryAttributeGroupViewModelRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
    }
}
