using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoTemasTexto : IListadoTemasConTexto
    {
        public IRepositorioTemas Repo { get; set; }

        public CUListadoTemasTexto(IRepositorioTemas repo)
        {
            Repo = repo;
        }

        public IEnumerable<TemaDTO> ObtenerListado(string texto)
        {
            return Mappers.MapperTemas.ToListaDTO(Repo.TemasContienenTexto(texto));
        }
    }
}
