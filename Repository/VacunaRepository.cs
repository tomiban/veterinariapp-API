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
            CreateVacunaDto vacunaDto
        )
        {
            var vacunaModel = await _context
                .Vacunas.Where(v => v.MascotaId == mascotaId && v.Id == id)
                .SingleOrDefaultAsync();

            if (vacunaModel == null)
            {
                return null;
            }

            vacunaModel.Nombre = vacunaDto.Nombre;
            vacunaModel.Completada = vacunaDto.Completada;

            await _context.SaveChangesAsync();

            return vacunaModel;
        }
    }
}
