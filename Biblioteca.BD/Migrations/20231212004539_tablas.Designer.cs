﻿// <auto-generated />
using System;
using Biblioteca.BD.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteca.BD.Migrations
{
    [DbContext(typeof(BDContext))]
<<<<<<<< HEAD:Biblioteca.BD/Migrations/20231212004539_tablas.Designer.cs
    [Migration("20231212004539_tablas")]
    partial class tablas
========
    [Migration("20231212031226_BDFINAL")]
    partial class BDFINAL
>>>>>>>> 08ee70d4d7794ced6b531639dc58c1d047df3133:Biblioteca.BD/Migrations/20231212031226_BDFINAL.Designer.cs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biblioteca.BD.Data.Entidades.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CursoId"));

                    b.Property<string>("Año")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Turno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CursoId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Biblioteca.BD.Data.Entidades.Inventario", b =>
                {
                    b.Property<int>("InventarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventarioId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("AutorMarca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Pasar")
                        .HasColumnType("bit");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.Property<string>("TituloNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InventarioId");

                    b.HasIndex("TipoId");

                    b.ToTable("Inventarios");
                });

            modelBuilder.Entity("Biblioteca.BD.Data.Entidades.Prestamo", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrestamoId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<bool>("EsDeudor")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaDevolucion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("HoraDevolucion")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraEntrega")
                        .HasColumnType("time");

                    b.Property<int>("InventarioId")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrestatarioId")
                        .HasColumnType("int");

                    b.HasKey("PrestamoId");

                    b.HasIndex("CursoId");

                    b.HasIndex("InventarioId");

                    b.HasIndex("PrestatarioId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("Biblioteca.BD.Data.Entidades.Prestatario", b =>
                {
                    b.Property<int>("PrestatarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrestatarioId"));

                    b.Property<string>("NombreApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrestatarioId");

                    b.ToTable("Prestatarios");
                });

            modelBuilder.Entity("Biblioteca.BD.Data.Entidades.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDevolucion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("HoraDevolucion")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraEntrega")
                        .HasColumnType("time");

                    b.Property<int>("InventarioId")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Pasar")
                        .HasColumnType("bit");

                    b.Property<int>("PrestatarioId")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.HasIndex("CursoId");

                    b.HasIndex("InventarioId");

                    b.HasIndex("PrestatarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Biblioteca.BD.Data.Entidades.Tipo", b =>
                {
                    b.Property<int>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoId"));

                    b.Property<string>("TipoMat")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TipoId");

                    b.ToTable("Tipos");
                });

            modelBuilder.Entity("Biblioteca.BD.Data.Entidades.Inventario", b =>
                {
                    b.HasOne("Biblioteca.BD.Data.Entidades.Tipo", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("Biblioteca.BD.Data.Entidades.Prestamo", b =>
                {
                    b.HasOne("Biblioteca.BD.Data.Entidades.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.BD.Data.Entidades.Inventario", "Inventario")
                        .WithMany()
                        .HasForeignKey("InventarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.BD.Data.Entidades.Prestatario", "Prestatario")
                        .WithMany()
                        .HasForeignKey("PrestatarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Inventario");

                    b.Navigation("Prestatario");
                });

            modelBuilder.Entity("Biblioteca.BD.Data.Entidades.Reserva", b =>
                {
                    b.HasOne("Biblioteca.BD.Data.Entidades.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.BD.Data.Entidades.Inventario", "Inventario")
                        .WithMany()
                        .HasForeignKey("InventarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.BD.Data.Entidades.Prestatario", "Prestatario")
                        .WithMany()
                        .HasForeignKey("PrestatarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Inventario");

                    b.Navigation("Prestatario");
                });
#pragma warning restore 612, 618
        }
    }
}
