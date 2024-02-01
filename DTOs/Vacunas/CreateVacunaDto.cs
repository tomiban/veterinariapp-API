using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Vacunas
{
    public class CreateVacunaDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "La longitud máxima del nombre es 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Completada' es obligatorio.")]
        public bool Completada { get; set; }

        [Required(ErrorMessage = "El campo cantidad de dosis es obligatorio.")]
        [Range(1, 99, ErrorMessage = "La cantidad de dosis aplicables debe estar entre 1 y 99.")]
        public int CantidadDosis { get; set; }
    }
}
