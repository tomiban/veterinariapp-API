using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Mascotas;
using api.Mappers;
using api.Models;

namespace api.Interfaces
{
    public interface IMascotaRepository
    {
        Task<List<Mascota>> GetAll();
        Task<Mascota?> GetById(int id);
        Task<Mascota?> Create(Mascota mascota);
        Task<Mascota?> Update(int id, CreateMascotaDto mascota);
        Task<Mascota?> Delete(int id);
    }
}