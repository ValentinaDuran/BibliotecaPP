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

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Inventario>()
//                .HasOne(p => p.Tipo)
//                .WithMany() 
//                .HasForeignKey(p => p.TipoId);

////            modelBuilder.Entity<Tipo>().HasData(

////new Tipo
////{
////    Id = 1,
////    TipoMat = "Libro",

////},

////new Tipo
////{
////    Id = 2,
////    TipoMat = "Mapa",

////},

////new Tipo
////{
////    Id = 3,
////    TipoMat = "UtilGeometría",

////},

////new Tipo
////{
////    Id = 4,
////    TipoMat = "Computadora",

////},

////new Tipo
////{
////    Id = 5,
////    TipoMat = "Proyector",

////},

////new Tipo
////{
////    Id = 6,
////    TipoMat = "Revista",

////},

////new Tipo
////{
////    Id = 7,
////    TipoMat = "Ludoteca",

////},

////new Tipo
////{
////    Id = 8,
////    TipoMat = "InstrumentoMusical"

////}



////               );
//       }


   }


}
