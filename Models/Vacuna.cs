using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace api.Models
{
    public class Vacuna
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public bool Completada { get; set; }
        public int MascotaId { get; set; }
        // Relación uno a muchos con Dosis
        public Mascota? Mascota { get; set; }
        public List<Dosis> Dosificaciones { get; set; } = new List<Dosis>();

        // Puedes agregar otras propiedades relacionadas con la vacuna
    }
}
