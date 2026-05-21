using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.ClasesDominio
{    
    public class Revista : Publicacion
    {
        public int Anio { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }

        public void Validar()
        {
            base.Validar();
            //PENDIENTE OTRAS VALIDACIONES
        }
    }
}
