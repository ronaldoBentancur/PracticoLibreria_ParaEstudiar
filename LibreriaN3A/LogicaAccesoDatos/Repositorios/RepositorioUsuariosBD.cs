using LogicaAccesoDatos.EF;
using LogicaAccesoDatos.Migrations;
using LogicaNegocio.ClasesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuariosBD : IRepositorioUsuarios
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioUsuariosBD(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Usuario nuevo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string password)
        {
            Usuario buscado = null;

            buscado = Contexto.Usuarios
                        .Include(usuario => usuario.Rol)
                        .Where(usuario => usuario.Email == email && usuario.Password == password)
                        .SingleOrDefault();
           
            return buscado;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
