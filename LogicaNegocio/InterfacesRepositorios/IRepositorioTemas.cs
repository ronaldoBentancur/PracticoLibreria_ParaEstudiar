using LogicaNegocio.ClasesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioTemas : IRepositorio<Tema>
    {
        IEnumerable<Tema> TemasContienenTexto(string texto);
    }
}
