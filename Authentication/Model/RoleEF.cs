using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public class RoleEF : IdentityRole<int>
    {
        public RoleEF(string roleName) : base(roleName) { }
        public ICollection<RolePermissionEF> RolePermissions { get; set; } = new List<RolePermissionEF>();
        public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    }
}
