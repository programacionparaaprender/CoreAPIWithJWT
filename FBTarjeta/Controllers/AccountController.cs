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
using System.Text;
using System.Threading.Tasks;

namespace FBTarjeta.Controllers
{


    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {

        // Same key configured in startup to validte the JWT tokens
        private readonly UsuarioService _tarjetaCreditoService;

        private IConfiguration _config;

        public AccountController(IConfiguration config, UsuarioService noticiaService)
        {
            _config = config;
            this._tarjetaCreditoService = noticiaService;
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
            var secret = _config.GetSection("JwtConfig").GetSection("secret").Value;
            var key = Encoding.Default.GetBytes(secret);
            SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(key);
            const string JWTAuthScheme = "JWTAuthScheme";


            SigningCredentials SigningCreds = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();


            if (!ValidateLogin(creds))
            {
                return Json(new
                {
                    error = "Login failed"
                });
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, creds.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                //Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);

            return Json(new
            {
                //token = token, 
                token = _tokenHandler.WriteToken(token),
                name = creds.Email,
                email = creds.Email,
                role = "User"
            });
        }

        private bool ValidateLogin(Usuario creds)
        {
            Usuario resultado = new Usuario();
            try
            {
                resultado = _tarjetaCreditoService.findEmailAndPassword(creds);
                if (resultado != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
