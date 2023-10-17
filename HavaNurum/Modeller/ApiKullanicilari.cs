namespace HavaNurum.Modeller
{
    public class ApiKullanicilari
    {
        public static List<ApiKullanicisi> Kullanicilar = new()
        {
            new ApiKullanicisi { Id = 1, KullaniciAdi = "sinan", Sifre = "123456", Rol = "Yonetici"},
            new ApiKullanicisi { Id = 2, KullaniciAdi = "ily", Sifre = "123456", Rol = "StandartKullanici"}
        };
    }
}
