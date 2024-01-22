using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<Dosis> Dosis { get; set; }
    }
}