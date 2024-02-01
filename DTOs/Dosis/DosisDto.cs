using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Dosis
{
    public class DosisDto
    {
        public int Id { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public DateTime FechaSiguienteAplicacion { get; set; }
    }
}
