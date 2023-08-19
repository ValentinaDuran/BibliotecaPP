﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BD.Data.Entidades
{
    public class Inventario
    {
        //Clave primaria
        [Key]
        public int InventarioId { get; set; } 

        #region Atributos


        public enum TipoMaterial
        {
            Libro,
            Mapa,
            ÚtilGeometría,
            Computadora,
            Proyector,
            Revista,
            Ludoteca,
            InstrumentoMusical
        }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string TituloNombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string AutorMarca { get; set; }

        [Required(ErrorMessage = "Campo obligatorio") ]
        public string Observacion { get; set; }
        #endregion

        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }


        //Clave foranea:Id_Prestamo

    }
}
