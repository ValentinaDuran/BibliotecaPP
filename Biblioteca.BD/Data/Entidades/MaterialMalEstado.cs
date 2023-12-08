using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BD.Data.Entidades
{
    public class MaterialMalEstado
    {
        //Clave primaria
        [Key]
        public int MaterialMalEstadoId { get; set; }


        #region Atributos
        public bool Activo { get; set; }

        #endregion


        // Clave foranea para referenciar el Inventario al que pertenece
        public ICollection<Inventario> Inventarios { get; set; }

    }
}
