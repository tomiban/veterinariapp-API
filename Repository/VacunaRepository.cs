using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Vacunas;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class VacunaRepository : IVacunaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMascotaRepository _mascotaRepo;

        public VacunaRepository(ApplicationDbContext context, IMascotaRepository mascotaRepo)
        {
            _context = context;
            _mascotaRepo = mascotaRepo;
        }

        public async Task<Vacuna?> CreateVacunaByMascota(int mascotaId, Vacuna vacuna)
        {
            // Asigna el MascotaId a la nueva vacuna
            var mascota = await _mascotaRepo.GetById(mascotaId);

            if (mascota == null)
            {
                return null;
            }

            vacuna.MascotaId = mascotaId;
            // Agrega la nueva vacuna al contexto
            _context.Vacunas.Add(vacuna);

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();
            return vacuna;
        }

        public async Task<Vacuna?> DeleteVacunaByMascotaId(int mascotaId, int id)
        {
            var vacuna = await _context
                .Vacunas.Where(v => v.MascotaId == mascotaId && v.Id == id)
                .SingleOrDefaultAsync();

            if (vacuna == null)
            {
                return null;
            }
            _context.Vacunas.Remove(vacuna);
            await _context.SaveChangesAsync();
            return vacuna;
        }

        public async Task<List<Vacuna>> GetAllByMascotaId(int mascotaId)
        {
            var vacunas = await _context
                .Vacunas.Where(v => v.MascotaId == mascotaId)
                .Include(v => v.Dosificaciones)
                .ToListAsync();

            return vacunas;
        }

        public async Task<Vacuna?> GetVacunaByMascotaId(int mascotaId, int id)
        {
            var vacuna = await _context
                .Vacunas.Include(v => v.Dosificaciones)
                .FirstOrDefaultAsync(v => v.MascotaId == mascotaId && v.Id == id);

            return vacuna;
        }

        public async Task<Vacuna?> UpdateVacunaByMascota(
            int mascotaId,
            int id,
            UpdateVacunaDto vacunaDto
        )
        {
            var vacunaModel = await _context
                .Vacunas.Include(v => v.Dosificaciones)
                .FirstOrDefaultAsync(v => v.MascotaId == mascotaId && v.Id == id);

            if (vacunaModel == null)
            {
                return null;
            }

            vacunaModel.Nombre = vacunaDto.Nombre;
            vacunaModel.Completada = vacunaDto.Completada;
            vacunaModel.CantidadDosis = vacunaDto.CantidadDosis;

            // Actualiza las dosis
            if (vacunaDto.Dosificaciones != null)
            {
                foreach (var dosisDto in vacunaDto.Dosificaciones)
                {
                    if (dosisDto.Id == 0)
                    {
                        // Nueva dosis, crea una nueva instancia
                        var nuevaDosis = new Dosis
                        {
                            FechaAplicacion = dosisDto.FechaAplicacion,
                            FechaProximaAplicacion = dosisDto.FechaProximaAplicacion,
                            VacunaId = vacunaModel.Id
                        };
                        _context.Dosis.Add(nuevaDosis); // Agrega la nueva dosis al contexto
                    }
                    else
                    {
                        // Actualiza una dosis existente
                        var dosisExistente = await _context.Dosis.FirstOrDefaultAsync(d =>
                            d.Id == dosisDto.Id && d.VacunaId == vacunaModel.Id
                        );

                        if (dosisExistente != null)
                        {
                            dosisExistente.FechaAplicacion = dosisDto.FechaAplicacion;
                            dosisExistente.FechaProximaAplicacion = dosisDto.FechaProximaAplicacion;
                            _context.Dosis.Update(dosisExistente); // Marca la dosis como modificada en el contexto
                        }
                    }
                }
            }

            await _context.SaveChangesAsync();

            return vacunaModel;
        }

        public async Task<bool> UpdateVacunaCompletada(int vacunaId)
        {
            var vacunaModel = await _context.Vacunas.FindAsync(vacunaId);

            if (vacunaModel == null)
                return false;

            var dosisAplicadas = await _context.Dosis.CountAsync(d => d.VacunaId == vacunaId);

            // Actualizar el estado de completado si la cantidad de dosis aplicadas es igual a la cantidad de dosis
            vacunaModel.Completada = dosisAplicadas >= vacunaModel.CantidadDosis;

            await _context.SaveChangesAsync();

            return vacunaModel.Completada;
        }
    }
}
