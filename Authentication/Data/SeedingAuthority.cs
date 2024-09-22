using Authentication.Model;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Authentication.Data
{
    public class SeedingAuthority
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public SeedingAuthority(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedingAsync() 
        {
            string[] roleNames = { "Admin", "Author", "Editor", "Contributor", "Guest" };
            foreach (var roleName in roleNames) 
            {
                if (!await _roleManager.RoleExistsAsync(roleName)) 
                {
                    var role = new IdentityRole(roleName);
                    await _roleManager.CreateAsync(role);
                }

            }
            await AddingRolesWithPerms("Admin", new[] {"CreateContent","ReadContent","UpdateContent","DeleteContent","PublishContent" });
            await AddingRolesWithPerms("Author", new[] { "CreateContent", "ReadContnent", "PublishContent" });
            await AddingRolesWithPerms("Editor", new[] { "UpdateContent", "ReadContent" });
            await AddingRolesWithPerms("Contributor", new[] { "CreateContent", "ReadContent" });
            await AddingRolesWithPerms("Guest", new[] {"ReadContent" });


        }
        private async Task AddingRolesWithPerms(string role, IEnumerable<String> perms) 
        {
            var roles = await _roleManager.FindByNameAsync(role);
            foreach (var perm in perms) 
            {
                await AddClaimToRoleAsync(roles, "Permission", perm);
            }
        }
        private async Task AddClaimToRoleAsync(IdentityRole roles, string claimType, string value)
        {

            var claim = await _roleManager.GetClaimsAsync(roles);

            if (!claim.Any(c => c.Type != claimType && c.Value != value))
            {
                await _roleManager.AddClaimAsync(roles, new Claim(claimType, value));
            }
        }
    }
}
