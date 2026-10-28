using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Dueño> Dueño { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<Dosis> Dosis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // La columna es varchar(10): el enum tiene que viajar como texto, no como entero.
            modelBuilder
                .Entity<Mascota>()
                .Property(mascota => mascota.Sexo)
                .HasConversion<string>()
                .HasMaxLength(10);

            // PostgreSQL solo acepta UTC en timestamp with time zone: normalizamos lo que
            // llega del cliente (que puede venir sin zona) al escribir y al leer.
            modelBuilder
                .Entity<Dosis>()
                .Property(dosis => dosis.FechaAplicacion)
                .HasConversion(
                    fecha => fecha.Kind == DateTimeKind.Utc ? fecha : fecha.ToUniversalTime(),
                    fecha => DateTime.SpecifyKind(fecha, DateTimeKind.Utc)
                );

            modelBuilder
                .Entity<Dosis>()
                .Property(dosis => dosis.FechaProximaAplicacion)
                .HasConversion(
                    fecha => fecha.Kind == DateTimeKind.Utc ? fecha : fecha.ToUniversalTime(),
                    fecha => DateTime.SpecifyKind(fecha, DateTimeKind.Utc)
                );
        }
    }
}
