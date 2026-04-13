using LogicaNegocio.ClasesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioTemasBD : IRepositorioTemas
    {
        public void Add(Tema nuevo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tema> FindAll()
        {
            throw new NotImplementedException();
        }

        public Tema FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tema> TemasContienenTexto(string texto)
        {
            throw new NotImplementedException();
        }

        public void Update(Tema obj)
        {
            throw new NotImplementedException();
        }
    }
}
