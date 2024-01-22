using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Mascotas;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.MascotaRepository
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly ApplicationDbContext _context;

        public MascotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Mascota?> Create(Mascota mascotaModel)
        {
            await _context.AddAsync(mascotaModel);
            await _context.SaveChangesAsync();
            return mascotaModel;
        }

        public async Task<Mascota?> Delete(int id)
        {
            var mascotaModel = await _context.Mascotas.FirstOrDefaultAsync(m => m.Id == id);

            if (mascotaModel == null)
            {
                return null;
            }
            
            _context.Remove(mascotaModel);
            await _context.SaveChangesAsync();
            return mascotaModel;
        }

        public async Task<List<Mascota>> GetAll()
        {
            var mascotas = await _context
                .Mascotas.Include(m => m.Vacunas)
                .ThenInclude(v => v.Dosificaciones)
                .ToListAsync();
            return mascotas;
        }

        public async Task<Mascota?> GetById(int id)
        {
            var mascota = await _context.Mascotas.Include(m => m.Vacunas).ThenInclude(d => d.Dosificaciones).FirstOrDefaultAsync(m => m.Id == id);
            return mascota;
        }

        public async Task<Mascota?> Update(int id, CreateMascotaDto mascotaDto)
        {
            var mascotaModel = await _context.Mascotas.FirstOrDefaultAsync(mascota =>
                mascota.Id == id
            );

            if (mascotaModel == null)
            {
                return null;
            }

            mascotaModel.Nombre = mascotaDto.Nombre;
            mascotaModel.Edad = mascotaDto.Edad;
            mascotaModel.Color = mascotaDto.Color;
            mascotaModel.Raza = mascotaDto.Raza;
            mascotaModel.Peso = mascotaDto.Peso;

            await _context.SaveChangesAsync();

            return mascotaModel;
        }
    }
}
