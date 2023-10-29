using HavaNurum.Modeller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HavaNurum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KimlikDenetimiController : ControllerBase
    {
        private readonly JwtAyarlari _jwtAyarlari;
        public KimlikDenetimiController(JwtAyarlari jwtAyarlari)
        {
            this._jwtAyarlari = jwtAyarlari;
        }

        [HttpPost("Giris")]
        public IActionResult Giris([FromBody] ApiKullanicisi apiKullaniciBilgileri)
        {
            var apiKullanicisi = KimlikDenetimiYap(apiKullaniciBilgileri);
            if (apiKullanicisi == null)
            {
                return NotFound("Kullanici bulunamadi");
            }
            var token = TokenOlustur(apiKullanicisi);
            return Ok(token);
        }

        private string TokenOlustur(ApiKullanicisi apiKullanicisi)
        {
            if (_jwtAyarlari.Key == null)
            {
                throw new Exception("Jwt Key error");
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAyarlari.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var clainDizisi = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, apiKullanicisi.KullaniciAdi!),
                new Claim(ClaimTypes.Role, apiKullanicisi.Rol)
            };
            var token = new JwtSecurityToken(_jwtAyarlari.Issuer,
                _jwtAyarlari.Audience,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private ApiKullanicisi? KimlikDenetimiYap(ApiKullanicisi apiKullaniciBilgileri)
        {
            List<ApiKullanicisi> Kullanicilar = ApiKullanicilari.Kullanicilar.ToList();
            ApiKullanicisi apiKullanicisi = Kullanicilar.First(x => x.KullaniciAdi?.ToLower() == apiKullaniciBilgileri.KullaniciAdi
            && x.Sifre == apiKullaniciBilgileri.Sifre);
            return apiKullanicisi;
        }

    }
}
