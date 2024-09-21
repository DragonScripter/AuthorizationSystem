using Authentication.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service
{
    public class RoleService
    {
        RoleManager<RoleEF> _roleManager;

        public RoleService(RoleManager<RoleEF> roleManager) 
        {
            _roleManager = roleManager;
        }
    }
}
