using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Data
{
    public interface IIdentitySeed
    {
        Task<bool> CreateAdminAccountIfEmpty();
    }
}
