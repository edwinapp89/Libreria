//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibreriaBD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RESENIAS
    {
        public int id { get; set; }

        [StringLength(1000)]
        public string resenia { get; set; }
        public string comentario { get; set; }
        public int calificacion { get; set; }
        public int idLibro { get; set; }
        public int idUsuario { get; set; }
    
        public virtual LIBROS LIBROS { get; set; }
        public virtual USUARIOS USUARIOS { get; set; }
    }
}