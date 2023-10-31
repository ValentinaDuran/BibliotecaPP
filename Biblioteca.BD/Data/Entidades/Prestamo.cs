﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteca.BD.Data.Entidades.Inventario;
using static Biblioteca.BD.Data.Entidades.Prestatario;
using static Biblioteca.BD.Data.Entidades.Prestatario;

namespace Biblioteca.BD.Data.Entidades
{
    public class Prestamo
    {
        //Clave primaria
        [Key]
        public int PrestamoId { get; set; }

        #region Atributos
 
        [Required]
        public  string Material { get; set; }//
        [Required]
        public int Cantidad { get; set; }//

        public bool Activo { get; set; } = true;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Entrega")]
        public DateTime FechaEntrega { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Devolución")]
        public DateTime FechaDevolucion { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hora de Entrega")]
        public TimeSpan HoraEntrega { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hora de Devolución")]
        public TimeSpan HoraDevolucion { get; set; }

        public bool Devuelto { get; set; }

        public string Observacion { get; set; }
        #endregion

        #region Claves Foraneas
        //Clave foranea-Realaciones
        //Relacion con Inventario
        public int InventarioId { get; set; }
        public Inventario Inventario { get; set; }

        //Relacion con Prestatario
        public int PrestatarioId { get; set; }
        public Prestatario? Prestatario { get; set; }
        //Relacion con Tipo
        [ForeignKey("TipoId")]
        public Tipo? Tipo { get; set; }

        //Relacion con Curso
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        #endregion


    }
}
