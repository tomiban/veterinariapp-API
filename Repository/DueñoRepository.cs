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

        public async Task<List<Dueño>> GetAll(string? busqueda)
        {
            var query = _context.Dueño.Include(d => d.Mascotas).AsQueryable();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                var patron = $"%{busqueda.Trim()}%";
                query = query.Where(d =>
                    EF.Functions.ILike(d.Nombre, patron)
                    || (d.Telefono != null && EF.Functions.ILike(d.Telefono, patron))
                );
            }

            return await query.OrderBy(d => d.Nombre).ToListAsync();
        }

        public async Task<Dueño?> GetById(int id)
        {
            return await _context
                .Dueño.Include(d => d.Mascotas)
                .ThenInclude(m => m.Vacunas)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Dueño.AnyAsync(d => d.Id == id);
        }

        public async Task<Dueño> Create(Dueño dueñoModel)
        {
            await _context.AddAsync(dueñoModel);
            await _context.SaveChangesAsync();
            return dueñoModel;
        }

        public async Task<Dueño?> Update(int id, CreateDueñoDto dueñoDto)
        {
            var dueñoModel = await _context
                .Dueño.Include(d => d.Mascotas)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dueñoModel == null)
            {
                return null;
            }

            dueñoModel.Nombre = dueñoDto.Nombre.Trim();
            dueñoModel.Telefono = dueñoDto.Telefono?.Trim();
            dueñoModel.Domicilio = dueñoDto.Domicilio?.Trim();

            await _context.SaveChangesAsync();
            return dueñoModel;
        }

        public async Task<Dueño?> Delete(int id)
        {
            // Se cargan las mascotas para que EF las desvincule antes de borrar al dueño.
            var dueñoModel = await _context
                .Dueño.Include(d => d.Mascotas)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dueñoModel == null)
            {
                return null;
            }

            _context.Remove(dueñoModel);
            await _context.SaveChangesAsync();
            return dueñoModel;
        }
    }
}
