using LogicaNegocio.ClasesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EF
{
    // Ingrediente 1: Clase que hereda de DbContext
    public class LibreriaContext : DbContext 
    {
        // Ingrediente 2: Tantos DbSets como entidades quiero que EF maneje (mapee) 
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Ingrediente 3: Configurar la conexión a la BD
    }
}
