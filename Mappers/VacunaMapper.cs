using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Vacunas;
using api.Models;

namespace api.Mappers
{
    public static class VacunaMapper
    {
        public static VacunaDto ToVacunaDto(this Vacuna vacuna)
        {
            return new VacunaDto
            {
                Id = vacuna.Id,
                Nombre = vacuna.Nombre,
                Completada = vacuna.Completada,
                CantidadDosis = vacuna.CantidadDosis,
                Dosificaciones = vacuna.Dosificaciones.Select(d => d.ToDosisDto()).ToList()
            };
        }

        public static Vacuna FromDtoToVacuna(this CreateVacunaDto vacunaDto)
        {
            return new Vacuna
            {
                Nombre = vacunaDto.Nombre,
                Completada = vacunaDto.Completada,
                CantidadDosis = vacunaDto.CantidadDosis
            };
        }
    }
}
