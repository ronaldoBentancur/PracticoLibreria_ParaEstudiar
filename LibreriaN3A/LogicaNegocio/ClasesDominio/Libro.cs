using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.ClasesDominio
{
   
    public class Libro : Publicacion
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }

        public void Validar()
        {
            base.Validar();
            //PENDIENTE OTRAS VALIDACIONES
        }
    }
}
