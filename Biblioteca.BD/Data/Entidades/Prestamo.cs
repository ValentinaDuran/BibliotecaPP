﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteca.BD.Data.Entidades.Inventario;
using static Biblioteca.BD.Data.Entidades.Prestatario;
using static Biblioteca.BD.Data.Entidades.Curso;
using static Biblioteca.BD.Data.Entidades.Tipo;
using System.Reflection.Metadata.Ecma335;

namespace Biblioteca.BD.Data.Entidades
{
    public class Prestamo
    {
        //Clave primaria
        [Key]
        public int PrestamoId { get; set; }

        #region Atributos
        public bool Activo { get; set; } = true;// marca si es devuelto ocultar visualmente
        public bool EsDeudor { get; set; } //usar cuando se marca cuando se adeuda un prestamo
        [Required(ErrorMessage = "Campo obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Entrega")]
        public DateTime FechaEntrega { get; set; } = DateTime.Today;


        [Required(ErrorMessage = "Campo obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Devolución")]
        public DateTime FechaDevolucion { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Campo obligatorio.")]
        [DataType(DataType.Time)] 
        [Display(Name = "Hora de Entrega")]
        public TimeSpan HoraEntrega { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hora de Devolución")]
        public TimeSpan HoraDevolucion { get; set; }
        public string? Observacion { get; set; }
        #endregion

        #region Claves Foraneas

        //Relacion con Inventario
        [Required(ErrorMessage = "Campo obligatorio.")]
        public int InventarioId { get; set; }
        public Inventario? Inventario { get; set; }

        //Relacion con Prestatario
        [Required(ErrorMessage = "Campo obligatorio.")]
        public int PrestatarioId { get; set; } 
        public Prestatario? Prestatario { get; set; }

        //Relacion con Curso
        [Required(ErrorMessage = "Campo obligatorio.")]
        public int CursoId { get; set; }
        public Curso? Curso { get; set; }



        #endregion


    }
}
