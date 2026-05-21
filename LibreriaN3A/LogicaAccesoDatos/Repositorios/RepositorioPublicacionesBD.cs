using LogicaAccesoDatos.EF;
using LogicaNegocio.ClasesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioPublicacionesBD : IRepositorio<Publicacion>
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPublicacionesBD(LibreriaContext ctx)
        {
            Contexto = ctx;
        }


        public void Add(Publicacion nueva)
        {
            nueva.Validar();
            //OTRAS VALIDACIONES

            //ESTO ES PARA QUE EF NO INTENTE DAR DE ALTA TAMBIÉN EL TEMA DE LA PUBLICACIÓN NUEVA
            Contexto.Entry(nueva.Tema).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

            Contexto.Publicaciones.Add(nueva);
            Contexto.SaveChanges();            
        }

        public IEnumerable<Publicacion> FindAll()
        {
            IEnumerable<Publicacion> publicaciones = new List<Publicacion>();
            publicaciones = publicaciones
                            .Concat(Contexto.Libros.Include(lib => lib.Tema).ToList())
                            .Concat(Contexto.Revistas.Include(rev => rev.Tema).ToList());
            return publicaciones;
        }


        public Publicacion FindById(int id)
        {
            Publicacion pub = Contexto.Libros.Include(lib => lib.Tema).Where(lib => lib.Id == id).SingleOrDefault();

            if (pub == null )
            {
                pub = Contexto.Revistas.Include(rev => rev.Tema).Where(lib => lib.Id == id).SingleOrDefault(); ;
            }

            return pub;
        }


        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Publicacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
