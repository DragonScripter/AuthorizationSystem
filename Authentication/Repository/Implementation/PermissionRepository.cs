using Authentication.Data;
using Authentication.Model;
using Authentication.Repository.Inteface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Repository.Implementation
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PermissionEF> CreatePerm(PermissionEF permission)
        {
            await _context.permissions.AddAsync(permission);
            await _context.SaveChangesAsync();
            return permission;
        }


        public async Task<IEnumerable<PermissionEF>> GetAllPermissionAsync()
        {
            return await _context.permissions.ToListAsync();
        }

        public async Task<bool> PermExistAsync(string perm)
        {
            return await _context.permissions.AnyAsync(p => p.Name == perm);
        }

    }
}
