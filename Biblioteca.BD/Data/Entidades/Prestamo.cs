using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteca.BD.Data.Entidades.Inventario;

namespace Biblioteca.BD.Data.Entidades
{
    public class Prestamo
    {
        //Clave primaria
        [Key]
        public int PrestamoId { get; set; }

        #region Atributos
        [Required]
        public string Prestatario { get; set; }//
        [Required]
        public  string Material { get; set; }//
        [Required]
        public int Cantidad { get; set; }//
        [Required]
        public int Curso { get; set; }//

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Entrega")]
        public DateTime FechaEntrega { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Devolución")]
        public DateTime FechaDevolucion { get; set; }

        [DataType(DataType.Time)]
        
        [Display(Name = "Hora de Entrega")]
        public DateTime HoraEntrega { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hora de Devolución")]
        public DateTime HoraDevolucion { get; set; }

        
        //public enum EstadoOptions
        //{
          //  [Display(Name = "Alta")]
          //  Alta,

          //  [Display(Name = "Baja")]
          //  Baja

        //}

        //public EstadoOptions Estado { get; set; }
        public bool Devuelto { get; set; }

        public string Observacion { get; set; }
        #endregion

        //Clave foranea-Realaciones
        //public string Id_Inventario { get; set; }
        public int InventarioId { get; set; }
        public Inventario Inventario { get; set; }
    }
}
