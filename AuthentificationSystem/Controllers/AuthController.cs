﻿using Authentication.Model;
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

        public AuthController(UserManager<AppUser> userManager) 
        {
            _userManager = userManager;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel) 
        {
            if (ModelState.IsValid) 
            {
                var user = new AppUser
                {
                    Name = registerModel.Name,
                    UserName = registerModel.Username,
                    Email = registerModel.Email,
                };
                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded) 
                {
                    await _userManager.AddToRoleAsync(user, "Guest");

                    return Ok(new { Message = "User registered successfully." });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
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
