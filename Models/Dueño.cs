using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Dueño
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public string? Domicilio { get; set; } = String.Empty;
        public string? Telefono { get; set; } = String.Empty;

        // Un dueño puede traer varias mascotas a la veterinaria.
        public List<Mascota> Mascotas { get; set; } = new List<Mascota>();
    }
}
