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
        Task<List<Dueño>> GetAll(string? busqueda);
        Task<Dueño?> GetById(int id);
        Task<bool> Exists(int id);
        Task<Dueño> Create(Dueño dueño);
        Task<Dueño?> Update(int id, CreateDueñoDto dueñoDto);
        Task<Dueño?> Delete(int id);
    }
}
