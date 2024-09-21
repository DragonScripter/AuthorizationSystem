using Authentication.Data;
using Authentication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<AppUser?> GetAuthorByNameAsync(string name) 
        {
            return await _userManager.FindByNameAsync(name);
        }

        public async Task<bool> CreateAuthorAsync(AppUser Author) 
        {
            var user = await _userManager.CreateAsync(Author, Author.Password);
            return user.Succeeded;
        }

        public async Task<IEnumerable<AppUser>> GetAllAuthors() 
        {
            return await _userManager.Users.ToListAsync();
        }

        //Author permissions

        public async Task<bool> CreateContentAsync(Content content) 
        {
            if (content == null || string.IsNullOrEmpty(content.Title) || string.IsNullOrEmpty(content.Body))
            {
                return false;
            }

            await _context.contents.AddAsync(content);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> GetContentByIdAsync(int contentId) 
        {
            var content = await _context.contents.FindAsync(contentId);
            return content != null;
        }

    }
}
