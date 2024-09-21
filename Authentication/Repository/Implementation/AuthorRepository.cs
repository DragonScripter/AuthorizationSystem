using Authentication.Data;
using Authentication.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Repository.Implementation
{
    public class AuthorRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<RoleEF> _roleManager;
        private readonly AppDbContext _context;

        public AuthorRepository(UserManager<AppUser> userManager, RoleManager<RoleEF> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<bool> userAuthAsync(string name, string password) 
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user == null) 
            {
                throw new Exception("User not found.");
            }

            var key = await _userManager.CheckPasswordAsync(user, password);
            return true;
        }

    }
}
