using Authentication.Data;
using Authentication.Model;
using AuthentificationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthentificationSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<RoleEF> _roleManager;
        private readonly AppDbContext _context;

        public AuthController(UserManager<AppUser> userManager, RoleManager<RoleEF> roleManager, AppDbContext appDbContext) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = appDbContext;
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
                await _userManager.AddToRoleAsync(user, "Contributor");
                return Ok(new { Message = "User registered successfully." });
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
    
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Content content) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            content.AuthorId = int.Parse(userID!);

            var user = await _userManager.FindByIdAsync(userID!);
            if (user == null) 
            {
                return NotFound("User not found.");
            }
            var userRole = await _userManager.GetRolesAsync(user);
            if (userRole.Contains("Contributor"))
            {
                
                content.isPublished = false; 
            }
            else if (userRole.Contains("Author"))
            {
                content.isPublished = true; 
            }
            else
            {
                return Forbid(); 
            }


            _context.contents.Add(content);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContentById), new { id = content.Id }, content);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContentById(int id)
        {
           
            var content = await _context.contents.FindAsync(id);

            if (content == null)
            {
                return NotFound(); 
            }

            return Ok(content); 
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
