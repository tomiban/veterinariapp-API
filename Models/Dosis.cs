using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Dosis
    {
        public int Id { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public DateTime FechaSiguienteAplicacion { get; set; }
        public int VacunaId { get; set; }
        public Vacuna? Vacuna { get; set; }
    }
}
