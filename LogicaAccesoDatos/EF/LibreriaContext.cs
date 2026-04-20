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
        public DbSet<Rol> Roles { get; set; }

        // Ingrediente 3: Configurar la conexión a la BD (Por ahora de esta manera)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb; Initial Catalog=N3A_DW_2026_1; Integrated Security=true;");

            base.OnConfiguring(optionsBuilder);
        }

        // Ingrediente 4 (opcional):
        // Cofigurar los mapeos a tablas no convencionales de forma pesonalizada (Fluent API)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tema>().ToTable("Subjects"); //EQUIVALE A LA DATA ANNOTATION TABLE
            modelBuilder.Entity<Rol>().ToTable("TiposUsuarios");
            modelBuilder.Entity<Usuario>().HasOne("Rol").WithMany(); // EF YA LO ENTIENDE ASÍ (INNECESARIO)


            base.OnModelCreating(modelBuilder);
        }
    }
}
