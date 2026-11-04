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
                Telefono = dueño.Telefono,
                CantidadMascotas = dueño.Mascotas.Count
            };
        }

        public static DueñoDetalleDto ToDueñoDetalleDto(this Dueño dueño)
        {
            return new DueñoDetalleDto
            {
                Id = dueño.Id,
                Nombre = dueño.Nombre,
                Domicilio = dueño.Domicilio,
                Telefono = dueño.Telefono,
                CantidadMascotas = dueño.Mascotas.Count,
                Mascotas = dueño.Mascotas.OrderBy(m => m.Nombre).Select(m => m.ToMascotaDto()).ToList()
            };
        }

        public static Dueño FromDtoToDueño(this CreateDueñoDto dueñoDto)
        {
            return new Dueño
            {
                Nombre = dueñoDto.Nombre.Trim(),
                Telefono = dueñoDto.Telefono?.Trim(),
                Domicilio = dueñoDto.Domicilio?.Trim()
            };
        }
    }
}
