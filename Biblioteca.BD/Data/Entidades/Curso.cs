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
        public TipoNivel Nivel { get; set; }

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

        [EnumDataType(typeof(TipoAño), ErrorMessage = "Campo obligatorio")]
        public TipoAño Año { get; set; }



        public enum TipoTurno
        {
            Mañana,
            Tarde,
            Noche

        }

        [EnumDataType(typeof(TipoTurno), ErrorMessage = "Campo obligatorio.")]
        public TipoTurno Turno { get; set; }
        //public string Turno { get; set; } //manana, tarde y noche

        public enum TipoDivision
        {
            A,
            B,
            C

        }

        [EnumDataType(typeof(TipoDivision), ErrorMessage = "Campo obligatorio.")]
        public TipoDivision Division { get; set; }
        //public string Division { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]

        public  string Prestatario { get; set; }
        #endregion
        //Clave foranea: id_prestatario

    }
}
