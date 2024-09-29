using Authentication.Data;
using Authentication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    public class UnitTester
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<RoleEF> _roleManager;
        private readonly AppDbContext _context;

        public UnitTester(UserManager<AppUser> userManager, RoleManager<RoleEF> roleManager, AppDbContext context)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DataDB;Trusted_Connection=True")
                .Options;

            //matching fixture data
        }

        [Fact]
        public async Task AssignRoletoUser()
        {
            
            var user = new AppUser
            {
                UserName = "testuser",
                Email = "testuser@example.com",
                Name = "Test User"
            };
            var password = "Password123!";

           
            var result = await _userManager.CreateAsync(user, password);
            Assert.True(result.Succeeded, "User creation failed: " + string.Join(", ", result.Errors));

            
            var addToRoleResult = await _userManager.AddToRoleAsync(user, "Guest");
            Assert.True(addToRoleResult.Succeeded, "Role assignment failed: " + string.Join(", ", addToRoleResult.Errors));

          
            var isInRole = await _userManager.IsInRoleAsync(user, "Guest");
            Assert.True(isInRole, "User should be in the role but is not.");
        }
    }
}
