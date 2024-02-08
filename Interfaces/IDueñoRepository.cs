using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Dueño;
using api.Models;

namespace api.Interfaces
{
    public interface IDueñoRepository
    {
        Task<Dueño?> GetById(int mascotaId, int id);
        Task<Dueño?> Create(Dueño dueño);
        Task<Dueño?> Update(int id, CreateDueñoDto createDueñoDto);
    }
}
