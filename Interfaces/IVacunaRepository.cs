using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Vacunas;
using api.Models;

namespace api.Interfaces
{
    public interface IVacunaRepository
    {
        Task<List<Vacuna>> GetAllByMascotaId(int mascotaId);
        Task<Vacuna?> GetVacunaByMascotaId(int mascotaId, int id);
        Task<Vacuna?> CreateVacunaByMascota(int mascotaId, Vacuna vacuna);
        Task<Vacuna?> UpdateVacunaByMascota(int mascotaId, int id, UpdateVacunaDto vacunaDto);
        Task<Vacuna?> DeleteVacunaByMascotaId(int mascotaId, int id);
        Task<bool> UpdateVacunaCompletada(int vacunaId);
    }
}
