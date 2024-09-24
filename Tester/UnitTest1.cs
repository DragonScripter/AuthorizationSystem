using Authentication;
using Authentication.Data;
using Authentication.Model;
using Authentication.Service.Implementation;
using Authentication.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
namespace Tester
{
    public class UnitTest1
    {
        private readonly AppDbContext _context;
        private readonly UserService _userService;
        private readonly Mock<UserManager<AppUser>> _userManager;
        private readonly Mock<RoleManager<RoleEF>> _roleManager;

        public UnitTest1() 
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

            _context = new AppDbContext(options);

           
            var userStoreMock = new Mock<IUserStore<AppUser>>();
            _userManager = new Mock<UserManager<AppUser>>(
                userStoreMock.Object,
                null, null, null, null, null, null, null, null);

            var roleStoreMock = new Mock<IRoleStore<RoleEF>>();
            _roleManager = new Mock<RoleManager<RoleEF>>(
                roleStoreMock.Object,
                null, null, null, null);

            
            _userService = new UserService(_userManager.Object, _roleManager.Object, _context);
        }

        [Fact]
        public async void CreateAccountAsync()
        {
            var user = new AppUser { Id = 1, Name = "testUser", Email = "test@example.com" };

            _userManager.Setup(AU => AU.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

            await _userService.CreateUserAsync(user, "password123");

            _userManager.Verify(AU => AU.CreateAsync(user, "password123"), Times.Once);

        }
    }
}