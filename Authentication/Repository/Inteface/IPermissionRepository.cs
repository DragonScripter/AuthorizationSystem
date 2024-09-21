using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Repository.Inteface
{
    public interface IPermissionRepository
    {
        Task<PermissionEF> CreatePerm(PermissionEF permission);
        Task<IEnumerable<PermissionEF>> GetAllPermissionAsync();
        Task<bool> PermExistAsync(string perm);
    }
}
