using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public class PermissionEF
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<RolePermissionEF> rolePermissions { get; set; } = new List<RolePermissionEF>();
    }
}
