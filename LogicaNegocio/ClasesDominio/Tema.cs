using Excepciones;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.ClasesDominio
{
    public class Tema : IValidable
    {
        public int Id { get; set; }
        public NombreTema Nombre { get; set; }
        public DescripcionTema? Descripcion { get; set; }       

        public void Validar()
        {            
            if (Nombre is null) throw new DatosInvalidosException("El nombre del tema es obligatorio");
        }        
    }
}
