using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BD.Data.Entidades
{
    public class Curso
    {
        //Clave primaria
        [Key]
        public int CursoId { get; set; }

        #region Atributos

        public enum TipoNivel
        {
            Secundario,
            Terciario
            
        }

        [EnumDataType(typeof(TipoNivel), ErrorMessage = "Campo obligatorio.")]
        public string Nivel { get; set; }

        public enum TipoAño
        {
            [Display(Name = "1ro")]
            Primero = 1,
            [Display(Name = "2do")]
            Segundo,
            [Display(Name = "3ro")]
            Tercero,
            [Display(Name = "4to")]
            Cuarto,
            [Display(Name = "5to")]
            Quinto,
            [Display(Name = "6to")]
            Sexto

        }

        public string Año { get; set; }

        public enum TipoTurno
        {
            Mañana,
            Tarde,
            Noche

        }

        public string Turno { get; set; }
        //public string Turno { get; set; } //manana, tarde y noche

        public enum TipoDivision
        {
            A,
            B,
            C

        }

        public string Division { get; set; }

        #endregion
    }
}
