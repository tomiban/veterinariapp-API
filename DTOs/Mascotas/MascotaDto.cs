using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Dueño;
using api.DTOs.Vacunas;
using api.Models;

namespace api.DTOs.Mascotas
{
    public class MascotaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public string? Especie { get; set; }
        public string Raza { get; set; } = String.Empty;

        [Column(TypeName = "nvarchar(10)")] // Especifica el tipo de columna en la base de datos
        [EnumDataType(typeof(Sexo))] // Indica a Entity Framework cómo debe tratar este enum
        public Sexo Sexo { get; set; }
        public string Color { get; set; } = String.Empty;
        public int Edad { get; set; }
        public float Peso { get; set; }
        public DueñoDto? Dueño { get; set; }
    }
}
