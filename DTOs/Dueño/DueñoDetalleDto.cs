using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Mascotas;

namespace api.DTOs.Dueño
{
    public class DueñoDetalleDto : DueñoDto
    {
        public List<MascotaDto> Mascotas { get; set; } = [];
    }
}
