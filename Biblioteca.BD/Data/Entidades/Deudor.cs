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
        public int DeudorId { get; set; }

        public bool EsDeudor { get; set; }
        //Clave foranea
        public int PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; }

        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
    }
}