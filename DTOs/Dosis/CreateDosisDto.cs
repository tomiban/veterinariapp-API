using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Dosis
{
    public class CreateDosisDto
    {
        [Required(ErrorMessage = "La fecha de aplicación es obligatoria.")]
        [DataType(DataType.DateTime, ErrorMessage = "El formato de fecha no es válido.")]
        public DateTime FechaAplicacion { get; set; }

        [Required(ErrorMessage = "La fecha de aplicación es obligatoria.")]
        [DataType(DataType.DateTime, ErrorMessage = "El formato de fecha no es válido.")]
        public DateTime FechaProximaAplicacion { get; set; }
    }
}
