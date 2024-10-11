using Authentication.Data;
using Authentication.Model;
using AuthentificationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthentificationSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<RoleEF> _roleManager;
        private readonly AppDbContext _context;
        private readonly ILogger<AuthController> _logger;

        public AuthController(UserManager<AppUser> userManager, RoleManager<RoleEF> roleManager, AppDbContext appDbContext, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = appDbContext;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                _logger.LogWarning("Invalid login attempt for user: {Username}", loginModel.Username);
                return Unauthorized("Invalid login attempt");
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: "Server",
                    audience: "User",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credential
                );
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), redirectUrl = "/" });

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
            _logger.LogInformation($"Number of claims: {User.Claims.Count()}");
            foreach (var claim in User.Claims)
            {
                _logger.LogInformation($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
            }
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userID))
            {
                return Unauthorized("User ID not found. Please make sure you are logged in.");
            }

            content.AuthorId = int.Parse(userID!);

            var user = await _userManager.FindByIdAsync(userID!);
            var userRole = await _userManager.GetRolesAsync(user);
            if (userRole.Contains("Contributor"))
            {

                content.isPublished = false;
            }
            else if (userRole.Contains("Author") || userRole.Contains("Admin"))
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
