using FBTarjeta.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FBTarjeta.Controllers
{


    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {

        // Same key configured in startup to validte the JWT tokens
        private static readonly SigningCredentials SigningCreds = new SigningCredentials(Startup.SecurityKey, SecurityAlgorithms.HmacSha256);
        private readonly JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

        private IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] Usuario creds)
        {
            if (!ValidateLogin(creds))
            {
                return Json(new
                {
                    error = "Login failed"
                });
            }

            //var principal = GetPrincipal(creds, Startup.CookieAuthScheme);

            //await HttpContext.SignInAsync(Startup.CookieAuthScheme, principal);
            string datos = "";

            datos = "{" + "\"name\":\"" + creds.Email
                + "\"" + "," + "\"email\":\"" + "admin"
                + "\"" + "," + "\"role\":\"" + "User" + "\"" + "}";
            return StatusCode(200, datos);
            //return Json(new
            //{
            //    name = principal.Identity.Name,
            //    email = principal.FindFirstValue(ClaimTypes.Email),
            //    role = principal.FindFirstValue(ClaimTypes.Role)
            //});
        }

        [HttpPost("logout")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return StatusCode(200);
        }

        [HttpGet("context")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public JsonResult Context()
        {
            return Json(new
            {
                name = this.User?.Identity?.Name,
                email = this.User?.FindFirstValue(ClaimTypes.Email),
                role = this.User?.FindFirstValue(ClaimTypes.Role),
            });
        }

        [HttpPost("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Token([FromBody] Usuario creds)
        {
            if (!ValidateLogin(creds))
            {
                return Json(new
                {
                    error = "Login failed"
                });
            }

            var principal = GetPrincipal(creds, Startup.JWTAuthScheme);

            
            var token = new JwtSecurityToken(
                "soSignalR",
                "soSignalR",
                principal.Claims,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: SigningCreds);
            
            //var jwt = new JwtService(_config);
            //string token = jwt.GenerateSecurityToken("fake@email.com");
            
            return Json(new
            {
                //token = token, 
                token = _tokenHandler.WriteToken(token),
                name = principal.Identity.Name,
                email = principal.FindFirstValue(ClaimTypes.Email),
                role = principal.FindFirstValue(ClaimTypes.Role)
            });
        }

        private bool ValidateLogin(Usuario creds)
        {
            // On a real project, you would use a SignInManager<ApplicationUser> to verify the identity
            // using:
            //  _signInManager.PasswordSignInAsync(user, password, lockoutOnFailure: false);
            // When using JWT you would rather
            //  _signInManager.UserManager.FindByEmailAsync(email);
            //  _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: false);

            // For this sample, all logins are successful!
            return true;
        }

        private ClaimsPrincipal GetPrincipal(Usuario creds, string authScheme)
        {
            // On a real project, you would use the SignInManager<ApplicationUser> to locate the user by its email
            // and to build its ClaimsPrincipal using:
            //  var user = await _signInManager.UserManager.FindByEmailAsync(email);
            //  var principal = await _signInManager.CreateUserPrincipalAsync(user)

            // Here we are just creating a Principal for any user, using its email and a hardcoded "User" role
            var claims = new List<Claim>
          {
              new Claim(ClaimTypes.Name, creds.Email),
              new Claim(ClaimTypes.Email, creds.Email),
              new Claim(ClaimTypes.Role, "User"),
          };
            return new ClaimsPrincipal(new ClaimsIdentity(claims, authScheme));
        }
    }
}
