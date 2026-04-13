using LogicaNegocio.ClasesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T>
    {
        void Add(T nuevo);
        void Remove(int id);
        void Update(T obj);
        T FindById(int id);
        IEnumerable<T> FindAll();        
        
}    
}
