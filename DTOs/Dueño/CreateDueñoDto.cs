using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Dueño
{
    public class CreateDueñoDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "La longitud máxima del nombre es 100 caracteres.")]
        public string Nombre { get; set; } = String.Empty;

        [StringLength(150, ErrorMessage = "La longitud máxima del domicilio es 150 caracteres.")]
        public string? Domicilio { get; set; }

        [StringLength(30, ErrorMessage = "La longitud máxima del teléfono es 30 caracteres.")]
        public string? Telefono { get; set; }
    }
}
