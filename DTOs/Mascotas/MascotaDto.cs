using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Vacunas;

namespace api.DTOs.Mascotas
{
    public class MascotaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public string Raza { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
        public int Edad { get; set; }
        public float Peso { get; set; }
        public List<VacunaDto> Vacunas { get; set; } = [];
    }
}