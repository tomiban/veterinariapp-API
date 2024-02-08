using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Mascotas
{
    public class CreateMascotaDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "La longitud máxima del nombre es 50 caracteres.")]
        public string Nombre { get; set; } = String.Empty;

        [StringLength(50, ErrorMessage = "La longitud máxima de la especie es 50 caracteres.")]
        public string? Especie { get; set; }

        [Required(ErrorMessage = "La raza es obligatoria.")]
        [StringLength(50, ErrorMessage = "La longitud máxima de la raza es 50 caracteres.")]
        public string Raza { get; set; } = String.Empty;

        [Required(ErrorMessage = "El sexo (Macho / Hembra) es obligatorio.")]
        [Column(TypeName = "nvarchar(10)")] // Especifica el tipo de columna en la base de datos
        [EnumDataType(typeof(Sexo))] // Indica a Entity Framework cómo debe tratar este enum
        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "El color es obligatorio.")]
        [StringLength(50, ErrorMessage = "La longitud máxima del color es 50 caracteres.")]
        public string Color { get; set; } = String.Empty;

        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(0, 99, ErrorMessage = "La edad debe estar entre 0 y 99.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El peso es obligatorio.")]
        [Range(0.1, 1000, ErrorMessage = "El peso debe estar entre 0.1 y 1000.")]
        public float Peso { get; set; }
    }
}
