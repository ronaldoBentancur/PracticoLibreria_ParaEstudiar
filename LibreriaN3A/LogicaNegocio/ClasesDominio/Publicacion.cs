using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.ClasesDominio
{
    public abstract class Publicacion : IValidable
    {
        public int Id { get; set; }
        public decimal Precio { get; set; }
        public Tema Tema { get; set; }
        public int CantPaginas { get; set; }
        public DateTime FechaPublicacion { get; set; }

        public void Validar()
        {
            //PENDIENTE VALIDACIONES
        }
    }
}
