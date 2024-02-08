using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Dueño;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DueñoRepository : IDueñoRepository
    {
        private readonly ApplicationDbContext _context;

        public DueñoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dueño?> Create(Dueño dueñoModel)
        {
            await _context.AddAsync(dueñoModel);
            await _context.SaveChangesAsync();
            return dueñoModel;
        }

        public async Task<Dueño?> GetById(int mascotaId, int id)
        {
            var dueño = await _context.Dueño.FirstOrDefaultAsync(d =>
                d.MascotaId == mascotaId && d.Id == id
            );
            return dueño;
        }

        public Task<Dueño?> Update(int id, CreateDueñoDto createDueñoDto)
        {
            throw new NotImplementedException();
        }
    }
}
