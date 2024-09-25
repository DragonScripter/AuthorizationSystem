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


        public virtual RoleEF? RoleEF { get; set; }
        public virtual PermissionEF? PermissionEF { get; set; }

    }
}
