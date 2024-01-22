using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Dosis;
using api.Models;


namespace api.Mappers
{
    public static class DosisMapper
    {
        public static DosisDto ToDosisDto(this Dosis dosis)
        {
            return new DosisDto
            {
                Id= dosis.Id,
                NumeroDosis = dosis.NumeroDosis,
                FechaAplicacion = dosis.FechaAplicacion
            };
        }
    }
}
