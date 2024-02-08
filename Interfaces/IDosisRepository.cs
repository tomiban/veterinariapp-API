using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Dosis;
using api.Models;

namespace api.Interfaces
{
    public interface IDosisRepository
    {
        Task<List<Dosis>> GetAllDosis(int vacunaId);
        Task<Dosis?> GetDosisById(int dosisId);
        Task<Dosis?> CreateDosis(int mascotaId, int DosisId, Dosis dosis);
        Task<Dosis?> UpdateDosis(int id, int DosisId, CreateDosisDto dosisDto);
        Task<Dosis?> DeleteDosis(int mascotaId, int vacunaId, int id);
    }
}
