using Authentication.Model;
using Authentication.Service.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.Implementation
{
    public class RoleService : IRoleService
    {
        RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> addClaimToRoleAsync(string roles, string claimType, string value)
        {
            var role = await _roleManager.FindByNameAsync(roles);
            if (role == null) 
            {
                throw new Exception("Role not found");
            }

            var claim = await _roleManager.GetClaimsAsync(role);

            if (!claim.Any(c => c.Type != claimType && c.Value != value)) 
            {
                var claims = new Claim(claimType, value);
                var result = await _roleManager.AddClaimAsync(role, claims);

                return result.Succeeded;
            }

            return false;
        }

        public async Task <IEnumerable<Claim>> CheckPermForRolesAsync(string roles, string claimType, string Value)
        {
            var role = await _roleManager.FindByNameAsync(roles);

            if (role == null) 
            {
                throw new Exception("Role not found");
            }

            return await _roleManager.GetClaimsAsync(role);
            
        }

        public async Task<bool> GetClaimsForRolesAsync(string roles)
        {
            var role = await _roleManager.FindByNameAsync(roles);

            if (role == null) 
            {
                throw new Exception("Role not found");
            }

            var claim = await _roleManager.GetClaimsAsync(role);
            // need to add the interface arguments for this
        }
    }
}
