using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Dueño;
using api.Models;

namespace api.Mappers
{
    public static class DueñoMapper
    {
        public static DueñoDto ToDueñoDto(this Dueño dueño)
        {
            return new DueñoDto
            {
                Id = dueño.Id,
                Nombre = dueño.Nombre,
                Domicilio = dueño.Domicilio,
                Telefono = dueño.Telefono
            };
        }

        public static Dueño FromDtoToDueño(this CreateDueñoDto dueñoDto)
        {
            return new Dueño
            {
                Nombre = dueñoDto.Nombre,
                Telefono = dueñoDto.Telefono,
                Domicilio = dueñoDto.Domicilio
            };
        }
    }
}
