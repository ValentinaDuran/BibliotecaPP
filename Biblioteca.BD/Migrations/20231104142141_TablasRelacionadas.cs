﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.BD.Migrations
{
    /// <inheritdoc />
    public partial class TablasRelacionadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "Deudores",
                columns: table => new
                {
                    DeudorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Inventario = table.Column<int>(type: "int", nullable: false),
                    Prestatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Curso = table.Column<int>(type: "int", nullable: false),
                    FechaEntrega = table.Column<int>(type: "int", nullable: false),
                    HoraEntrega = table.Column<int>(type: "int", nullable: false),
                    FechaDevolucion = table.Column<int>(type: "int", nullable: false),
                    HoraDevolucion = table.Column<int>(type: "int", nullable: false),
                    Devuelto = table.Column<bool>(type: "bit", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudores", x => x.DeudorId);
                });

            migrationBuilder.CreateTable(
                name: "MaterialesMalEstado",
                columns: table => new
                {
                    MaterialMalEstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TituloNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutorMarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialesMalEstado", x => x.MaterialMalEstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Prestatarios",
                columns: table => new
                {
                    PrestatarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreApellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestatarios", x => x.PrestatarioId);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventarioId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrestatarioId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Curso = table.Column<int>(type: "int", nullable: false),
                    FechaEntrega = table.Column<int>(type: "int", nullable: false),
                    HoraEntrega = table.Column<int>(type: "int", nullable: false),
                    FechaDevolucion = table.Column<int>(type: "int", nullable: false),
                    HoraDevolucion = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Devuelto = table.Column<bool>(type: "bit", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMat = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    InventarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    TituloNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutorMarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.InventarioId);
                    table.ForeignKey(
                        name: "FK_Inventarios_Tipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipos",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "date", nullable: false),
                    DevolucionReal = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "date", nullable: false),
                    HoraEntrega = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraDevolucion = table.Column<TimeSpan>(type: "time", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventarioId = table.Column<int>(type: "int", nullable: false),
                    PrestatarioId = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Inventarios_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventarios",
                        principalColumn: "InventarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Prestatarios_PrestatarioId",
                        column: x => x.PrestatarioId,
                        principalTable: "Prestatarios",
                        principalColumn: "PrestatarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Tipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipos",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_TipoId",
                table: "Inventarios",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_CursoId",
                table: "Prestamos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_InventarioId",
                table: "Prestamos",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_PrestatarioId",
                table: "Prestamos",
                column: "PrestatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_TipoId",
                table: "Prestamos",
                column: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deudores");

            migrationBuilder.DropTable(
                name: "MaterialesMalEstado");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "Prestatarios");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}