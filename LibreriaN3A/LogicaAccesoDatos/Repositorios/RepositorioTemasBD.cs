using Excepciones;
using LogicaAccesoDatos.EF;
using LogicaNegocio.ClasesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioTemasBD : IRepositorioTemas
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioTemasBD(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Tema nuevo)
        {
            if (nuevo == null) throw new DatosInvalidosException("No se proveen datos para el alta del tema");

            nuevo.Validar();

            Contexto.Temas.Add(nuevo);
            Contexto.SaveChanges();            
        }

        public IEnumerable<Tema> FindAll()
        {
            return Contexto.Temas.ToList();
        }

        public Tema FindById(int id)
        {
            return Contexto.Temas.Find(id);
        }

        public void Remove(int id)
        {
            Tema aBorrar = FindById(id);

            if (aBorrar == null) throw new OperacionInvalidaException("No existe el tema con id " + id);

            Contexto.Temas.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        public IEnumerable<Tema> TemasContienenTexto(string texto)
        {
            var temas = Contexto.Temas
                        .Where(tema => tema.Nombre.Valor.Contains(texto))
                        .ToList();

            return temas;
        }

        public void Update(Tema obj)
        {
            if (obj == null) throw new DatosInvalidosException("No se proveen datos para la modificación");
            obj.Validar();

            //Tema aModificar = FindById(obj.Id);

            //ALTERNATIVA AL FIND SIN RASTREO
            var aModificar = Contexto.Temas
                             .AsNoTracking()
                             .Where(t => t.Id == obj.Id)
                             .SingleOrDefault();                                  


            if (aModificar == null) throw new OperacionInvalidaException("No existe el tema a modificar");

            //ESTO LO HACEMOS SI USAMOS FIND
            //Contexto.Entry(aModificar).State = EntityState.Detached;

            Contexto.Temas.Update(obj);            
            Contexto.SaveChanges();
        }       
    }
}
