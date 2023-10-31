using Biblioteca.BD.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BD.Data.Entidades
{
    public class BDContext : DbContext
    {
        public DbSet <Curso> Cursos { get; set; }
        public DbSet<Deudor> Deudores { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<MaterialMalEstado> MaterialesMalEstado { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Prestatario> Prestatarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        public BDContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prestamo>()
                .Property(p => p.FechaEntrega)
                .HasColumnType("date");
        }
        


    }


}
