using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Dosis;

namespace api.DTOs.Vacunas
{
    public class VacunaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public bool Completada { get; set; }
        public List<DosisDto> Dosificaciones { get; set; } = [];
    }
}
