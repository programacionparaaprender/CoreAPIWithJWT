﻿namespace HavaNurum.Modeller
{
    public class ApiKullanicisi
    {
        public int Id { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? Sifre { get; set; }
        public string Rol { get; set; }
    }
}
