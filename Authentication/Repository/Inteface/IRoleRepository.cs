using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Repository.Inteface
{
    public interface IRoleRepository
    {
        Task<RoleEF> CreateRole(RoleEF role);
        Task<RoleEF?> GetRoleByIdAsync(int id);
        Task<IEnumerable<RoleEF>> GetAllRolesAsync();
        Task<bool> RoleExistAsync(string rolename);
        Task<IEnumerable<string>> GetAllPermissionAsync();


    }
}
