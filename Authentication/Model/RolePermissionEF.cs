using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public class RolePermissionEF
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }


        public RoleEF Role { get; set; }
        public PermissionEF Permission { get; set; }
    }
}
