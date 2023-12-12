using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BD.Data.Entidades
{
    public class Prestatario
    {
        //Clave primaria
        [Key]
        public int PrestatarioId { get; set; }

        //Atributos
        #region Atributos
        [Required(ErrorMessage = "Campo obligatorio.")]
        [RegularExpression(@"^[A-Za-zñÑ\s]+$", ErrorMessage = "El campo NombreApellido solo puede contener letras y espacios.")]
        public string NombreApellido { get; set; }


        #endregion 

        
    }
}
