using LogicaNegocio.ClasesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario()
            {
                Id = 1,
                Nombre = "Pedro",
                Email = "pedro@pedro.com",
                Password = "pedro1234",
                Rol = new Rol() { Id = 1, Nombre = "administrador" }
            },
            new Usuario()
            {
                Id = 2,
                Nombre = "Ana",
                Email = "ana@ana.com",
                Password = "ana1234",
                Rol = new Rol() { Id = 2, Nombre = "gerente" }
            }
        };

        public void Add(Usuario nuevo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return usuarios;
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string password)
        {
            foreach (Usuario usu in usuarios)
            {
                if (usu.Email == email && usu.Password == password) return usu;
            }

            return null;
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
