using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public string Raza { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
        public int Edad { get; set; }
        public float Peso { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Vacuna> Vacunas { get; set; } = new List<Vacuna>();
    }
}

