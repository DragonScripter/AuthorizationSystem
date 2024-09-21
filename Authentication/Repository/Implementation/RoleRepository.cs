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
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RoleEF> CreateRole(RoleEF role)
        {
            await _context.roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<RoleEF?> GetRoleByIdAsync(int id)
        {
            return await _context.roles.FindAsync(id);
            
        }

        public async Task<IEnumerable<RoleEF>> GetAllRolesAsync()
        {
            return await _context.roles.ToListAsync();
        }

        public async Task<bool> RoleExistAsync(string roleName)
        {
            return await _context.roles.AnyAsync(r => r.Name == roleName);
        }

        public async Task<IEnumerable<string>> GetAllPermissionAsync()
        {
            return await _context.permissions.Select(p => p.Name).ToListAsync();
        }
    }
}
