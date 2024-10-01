using Authentication.Model;
using Authentication.Service.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
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
        private readonly RoleManager<RoleEF> _roleManager;

        public RoleService(RoleManager<RoleEF> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            var role = new RoleEF (roleName);
            var result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> addClaimToRoleAsync(string roles, string claimType, string value)
        {
            var role = await _roleManager.FindByNameAsync(roles);
            if (role == null) 
            {
                return false;
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

        public async Task<IEnumerable<Claim>> GetClaimsForRolesAsync(string roles, string claimType, string value)
        {
            var role = await _roleManager.FindByNameAsync(roles);

            if (role == null)
            {
                return Enumerable.Empty<Claim>();
            }

            return await _roleManager.GetClaimsAsync(role);

        }

        public async Task <bool> CheckPermForRolesAsync(string roles, string claimType, string Value)
        {
            var role = await _roleManager.FindByNameAsync(roles);

            if (role == null) 
            {
                return false;
            }

            var claim = await _roleManager.GetClaimsAsync (role);
            return claim.Any(c => c.Type != claimType && c.Value != Value);

        }
    }
}
