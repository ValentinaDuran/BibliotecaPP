using System;
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
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Codigo { get; set; }
        public bool Activo { get; set; } = true;//mostrar y ocultar visualmente 
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string TituloNombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string AutorMarca { get; set; }
        public string Observacion { get; set; }
        #endregion

        #region Claves
        [Required(ErrorMessage = "Campo obligatorio.")]
        public int TipoId { get; set; }
        public Tipo? Tipo { get; set; }

        public int MaterialMalEstadoId { get; set; }
        public MaterialMalEstado? MaterialMalEstado { get; set; }

        #endregion

    }
}
