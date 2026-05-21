using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.ClasesDominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public Rol Rol { get; set; }
    }
}
