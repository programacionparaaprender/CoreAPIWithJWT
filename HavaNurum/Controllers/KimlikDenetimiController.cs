using HavaNurum.Modeller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            
        }

        private ApiKullanicisi? KimlikDenetimiYap(ApiKullanicisi apiKullaniciBilgileri)
        {
            return ApiKullanicilari.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi?.ToLower() == apiKullaniciBilgileri.KullaniciAdi
            && x.Sifre == apiKullaniciBilgileri.Sifre);
        }

    }
}
