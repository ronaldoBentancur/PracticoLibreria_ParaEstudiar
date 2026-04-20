using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.ClasesDominio
{   
    public class Rol
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Display(Name = "Rol")]
        public string Nombre { get; set; }        
    }
}
