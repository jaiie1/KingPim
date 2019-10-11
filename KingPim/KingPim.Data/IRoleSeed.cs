using System.Threading.Tasks;

namespace KingPim.Data
{
    public interface IRoleSeed
    {
        Task<bool> CreateRoleIfEmpty();
    }
}
