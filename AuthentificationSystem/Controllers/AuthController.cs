using Authentication.Model;
using AuthentificationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthentificationSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<RoleEF> _roleManager;

        public AuthController(UserManager<AppUser> userManager, RoleManager<RoleEF> roleManager) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user == null) 
            {
                return NotFound("Not Found");
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginModel.Password);
            if (!passwordCheck) 
            {
                return Unauthorized("Invalid login attempt");
            }

            return Ok("Login sucess");

        }
        [HttpPost("registration")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel) 
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); 
                }
                return BadRequest(ModelState);
            }
            var user = new AppUser
            {
                Name = registerModel.name,
                UserName = registerModel.username,
                Email = registerModel.email,
            };
            var result = await _userManager.CreateAsync(user, registerModel.password);
            if (result.Succeeded) 
            {
                await _userManager.AddToRoleAsync(user, "Guest");
                return Ok(new { Message = "User registered successfully." });
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
    
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
