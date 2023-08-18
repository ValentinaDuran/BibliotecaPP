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
        public string MaterialId { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string TituloNombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string AutorMarca { get; set; }
        public string Tipo { get; set; }
        public bool Estado { get; set; }
        #endregion

        //Clave foranea
        //public int Id_Inventario { get; set; }

        
    }
}
