using Authentication.Data;
using Authentication.Model;
using Authentication.Repository.Inteface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Repository.Implementation
{
    public class ContributorRepository : IContributorRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<RoleEF> _roleManager;
        private readonly AppDbContext _context;

        public ContributorRepository(UserManager<AppUser> userManager, RoleManager<RoleEF> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<bool>userAuthAsync(string name, string password) 
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user == null) 
            {
                return false;
            }

            var key = await _userManager.CheckPasswordAsync(user, password);
            return true;
        }

        public async Task<AppUser?> GetContributorByNameAsync(string name) 
        {
            return await _userManager.FindByNameAsync(name);
        }

        public async Task<bool> CreateContributorAsync(AppUser Contributor) 
        {
            var user = await _userManager.CreateAsync(Contributor, Contributor.Password);
            return user.Succeeded;
        }

        public async Task<IEnumerable<AppUser>> GetAllContributors() 
        {
            return await _userManager.Users.ToListAsync();
        }

        //contributor perms
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
        public async Task<IEnumerable<Content>> GetAllContentAsync() 
        {
            return await _context.contents.ToListAsync();
        }
        //public async Task<bool> hasPermissionAsync(string Id, string perm) 
        //{
        //    var contributor = await _userManager.FindByIdAsync(Id);
        //    if (contributor == null) 
        //    {
        //        return false;
        //    }

        //    var roles = await _userManager.GetRolesAsync(contributor);


        //    foreach (var role in roles) 
        //    {
        //        //creating the claims for roles and permission
        //    }
        //}



    }
}
