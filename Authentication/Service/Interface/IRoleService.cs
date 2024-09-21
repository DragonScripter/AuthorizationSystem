using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.Interface
{
    public interface IRoleService
    {
        Task<bool> addClaimToRoleAsync(string role, string claim, string type);
        Task<bool> PutClaimsToRoleAsync();
    }
}
