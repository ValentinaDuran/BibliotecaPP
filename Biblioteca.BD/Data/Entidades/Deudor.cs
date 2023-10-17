using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BD.Data.Entidades
{
    public class Deudor
    {
        //Clave primaria
        [Key]
        public string DeudorId { get; set; }

        #region Atributos
       
        public int Id_Inventario { get; set; }
 
        public string Prestatario { get; set; }
        
     
        public string Material { get; set; }
        
       
        public int Curso { get; set; }
        
      
        public int FechaEntrega { get; set; }
        
       
        public int HoraEntrega { get; set; }
        
       
        public int FechaDevolucion { get; set; }
        
        
        public int HoraDevolucion { get; set; }

       
        public bool Devuelto { get; set; }
        public string Observacion { get; set; }
        #endregion

        //Clave foranea
        //public int Id_prestamo { get; set; }
    }
}
