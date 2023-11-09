using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BD.Data.Entidades
{
    public class Reserva
    {
        //Clave primaria
        [Key]
        public int ReservaId { get; set; }

        #region Atributos

        public string InventarioId { get; set; }//
        public string PrestatarioId { get; set; }//
        public string MaterialId { get; set; }//
        public int Curso { get; set; }//
        public int FechaEntrega { get; set; }
        public int HoraEntrega { get; set; }
        public int FechaDevolucion { get; set; }
        public int HoraDevolucion { get; set; }
        public bool Estado { get; set; }
        public bool Devuelto { get; set; }
        public string Observacion { get; set; }
        #endregion

        //Clave Foranea:Id_prestamo
    }
}
