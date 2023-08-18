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
        public string PrestatarioId { get; set; }

        //Atributos
        #region Atributos
        public string NombreApellido { get; set; }
        public int Curso { get; set; } //tengo un problma con curso, se pone anio y division ? entonces como quedaria los atributos de la tabla cursos?
        #endregion 

        //Clave foranea:id-curso
    }
}
