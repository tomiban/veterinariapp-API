using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Dueño
{
    public class CreateDueñoDto
    {
        public string Nombre { get; set; } = String.Empty;
        public string? Domicilio { get; set; }
        public string? Telefono { get; set; }
    }
}
