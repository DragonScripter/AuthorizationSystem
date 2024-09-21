using Authentication.Data;
using Authentication.Model;
using Authentication.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<RoleEF> _roleManager;
        private readonly AppDbContext _context;

        public UserService(UserManager<AppUser> userManager, RoleManager<RoleEF> roleManager, AppDbContext context)
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
                return false;
            }

            var key = await _userManager.CheckPasswordAsync(user, password);
            return true;
        }

        public async Task<AppUser?> GetUserByNameAsync(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }

        public async Task<bool> CreateUserAsync(AppUser User)
        {
            var user = await _userManager.CreateAsync(User, User.Password);
            return user.Succeeded;
        }

        public async Task<IEnumerable<AppUser>> GetAllUser()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IEnumerable<Content>> GetAllContentAsync()
        {
            return await _context.contents.ToListAsync();
        }


        public async Task<bool> GetContentByIdAsync(int contentId)
        {
            var content = await _context.contents.FindAsync(contentId);
            return content != null;
        }

    }
}
