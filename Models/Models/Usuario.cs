using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Models.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [StringLength(32)]
        [Required]
        public string Email { get; set; }

        [StringLength(32)]
        [Required]
        public string Password { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Usuario> mapeoAutor)
            {
                mapeoAutor.HasKey(x => x.UsuarioId);
                mapeoAutor.Property(x => x.Email).HasColumnName("Email");
                mapeoAutor.ToTable("Usuario");
                //mapeoAutor.HasOne(x => x.Autor);
            }
        }
    }
}
