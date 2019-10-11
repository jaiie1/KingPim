using System.Threading.Tasks;

namespace KingPim.Data
{
    public interface IUserRoleSeed
    {
        Task<bool> CreateUserRoleIfEmpty();
    }
}
