using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Dosis;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DosisRepository : IDosisRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IVacunaRepository _vacunaRepository;

        public DosisRepository(ApplicationDbContext context, IVacunaRepository vacunaRepository)
        {
            _context = context;
            _vacunaRepository = vacunaRepository;
        }

        public async Task<Dosis?> CreateDosis(int mascotaId, int vacunaId, Dosis dosis)
        {
            var vacunaModel = await _vacunaRepository.GetVacunaByMascotaId(mascotaId, vacunaId);

            if (vacunaModel == null)
            {
                return null;
            }

            dosis.VacunaId = vacunaId;
            _context.Dosis.Add(dosis);

          
            await _context.SaveChangesAsync();

            await _vacunaRepository.UpdateVacunaCompletada(vacunaId);

            return dosis;
        }

        public async Task<Dosis?> DeleteDosis(int mascotaId, int vacunaId, int id)
        {
            var isMascota = await _context.Mascotas.FindAsync(mascotaId);

            if (isMascota == null)
                return null;

            var dosis = await _context
                .Dosis.Where(d => d.VacunaId == vacunaId && d.Id == id)
                .SingleOrDefaultAsync();

            if (dosis == null)
            {
                return null;
            }

            _context.Dosis.Remove(dosis);


            await _context.SaveChangesAsync();
             await _vacunaRepository.UpdateVacunaCompletada(vacunaId);
            return dosis;
        }

        public async Task<List<Dosis>> GetAllDosis(int vacunaId)
        {
            var dosis = await _context.Dosis.Where(d => d.VacunaId == vacunaId).ToListAsync();

            return dosis;
        }

        public async Task<Dosis?> GetDosisById(int id)
        {
            var dosis = await _context.Dosis.FirstOrDefaultAsync(d => d.Id == id);
            return dosis;
        }

        public Task<Dosis?> UpdateDosis(int id, int DosisId, CreateDosisDto dosisDto)
        {
            throw new NotImplementedException();
        }
    }
}
