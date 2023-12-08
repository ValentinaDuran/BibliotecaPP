﻿using Biblioteca.BD.Data.Entidades;
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
            //Model de prestamo
            modelBuilder.Entity<Prestamo>()
                .Property(p => p.FechaEntrega)
                .HasColumnType("date");
            modelBuilder.Entity<Prestamo>()
                .Property(p => p.FechaDevolucion)
                .HasColumnType("date");

        
            modelBuilder.Entity<Prestamo>()
                .Property(p => p.HoraEntrega)
                .HasColumnType("time");

            modelBuilder.Entity<Prestamo>()
                .Property(p => p.HoraDevolucion)
                .HasColumnType("time");
            modelBuilder.Entity<Prestamo>()
                .Property(p => p.DevolucionReal)
                .HasColumnType("datetime");

            //modelBuilder.Entity<Prestamo>()
            //    .HasOne(p => p.Tipo)
            //    .WithMany()
            //    .HasForeignKey(p => p.TipoId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //Model de reservas
            modelBuilder.Entity<Reserva>()
                .Property(p => p.FechaEntrega)
                .HasColumnType("date");
            modelBuilder.Entity<Reserva>()
                .Property(p => p.FechaDevolucion)
                .HasColumnType("date");

        
            modelBuilder.Entity<Reserva>()
                .Property(p => p.HoraEntrega)
                .HasColumnType("time");

            modelBuilder.Entity<Reserva>()
                .Property(p => p.HoraDevolucion)
                .HasColumnType("time");
            modelBuilder.Entity<Reserva>()
                .Property(p => p.DevolucionReal)
                .HasColumnType("datetime");

            //modelBuilder.Entity<Reserva>()
            //    .HasOne(p => p.Tipo)
            //    .WithMany()
            //    .HasForeignKey(p => p.TipoId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //Model de deudor
            modelBuilder.Entity<Deudor>()
                .HasOne(d => d.Prestamo)
                .WithMany()
                .HasForeignKey(d => d.PrestamoId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Deudor>()
                .HasOne(d => d.Reserva)
                .WithMany()
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.Restrict);
         
        
            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Tipo)               // Un inventario tiene un solo Tipo
                .WithMany()                        // Un Tipo puede estar relacionado con muchos Inventarios
                .HasForeignKey(i => i.TipoId)      // Clave foránea en Inventario
                .IsRequired();                     // TipoId es requerido en Inventario





        }


    }
    
}
