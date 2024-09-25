using Authentication.Model;
using AuthentificationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthentificationSystem.Controllers
{
    [ApiController]
    [Route("api/[Auth]")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager) 
        {
            _userManager = userManager;
        }

        [HttpPost]
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
