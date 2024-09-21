using Authentication.Data;
using Authentication.Model;
using Authentication.Repository.Inteface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Repository.Implementation
{
    public class EditorRepository : IEditorRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<RoleEF> _roleManager;
        private readonly AppDbContext _context;

        public EditorRepository(UserManager<AppUser> userManager, RoleManager<RoleEF> roleManager, AppDbContext context)
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

        public async Task<AppUser> GetEditorByNameAsync(string name) 
        {
            return await _userManager.FindByNameAsync(name);
        }

        public async Task<bool> CreateEditorAsync(AppUser Editor) 
        {
            var user = await _userManager.CreateAsync(Editor, Editor.Password);
            return user.Succeeded;
        }

        public async Task<IEnumerable<AppUser>> GetAllEditor() 
        {
            return await _userManager.Users.ToListAsync();
        }

        //Editor permissions

        public async Task<bool> UpdateContent(Content content) 
        {
            _context.contents.Update(content);

            var result = await _context.SaveChangesAsync();
            return true;
            //remove bool it does not need to return anything
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

        public async Task<bool> hasPermissionAsync(string userID, string perm) 
        {
            var Editor = await _userManager.FindByIdAsync(userID);

            if (Editor == null) 
            {
                return false;
            }

            var role = await _userManager.GetRolesAsync(Editor);

            if (role == null) 
            {
                throw new Exception("Role not found");
            }

            foreach (var roleNames in role) 
            {
                var roles = await _roleManager.FindByNameAsync(roleNames);

                if (roles == null)
                {
                    throw new Exception($"{roleNames} not found");
                }

                var claims = await _roleManager.GetClaimsAsync(roles);

                if (claims.Any(c => c.Type == "Permission" && c.Value == perm)) 
                {
                    return true;
                }

            }

            return false;

        }
    }
}
