using CasosUso.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class CUBajaTema : IBajaTema
    {
        public IRepositorioTemas Repo { get; set; }

        public CUBajaTema(IRepositorioTemas repo)
        {
            Repo = repo;
        }
        public void EjecutarBaja(int id)
        {            
            Repo.Remove(id);
        }
    }
}
