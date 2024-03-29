//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace final_prog3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Nomina
    {
        [Key]
        public int id { get; set; }

        [Range(2019, 2100, ErrorMessage = "Ingrese un año valido")]
        public int Año { get; set; }

        [Range(1, 12, ErrorMessage = "Ingrese un mes valido")]
        public int Mes { get; set; }

        [Required(ErrorMessage = "No hay un monto exacto para exportar")]
        public decimal MontoTotal { get; set; }
    }
}

