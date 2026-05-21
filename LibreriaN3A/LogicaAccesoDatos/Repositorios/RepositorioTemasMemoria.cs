using Excepciones;
using LogicaNegocio.ClasesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.Repositorios
{
    //Add, Remove, Update, FindAll, FindById
    public class RepositorioTemasMemoria : IRepositorioTemas
    {
        private static List<Tema> temas = new List<Tema>();
        private static int ultIdTema = 0;

        public void Add(Tema nuevo)
        {
            if (nuevo == null) throw new DatosInvalidosException("No se proveen datos para el alta del tema");

            nuevo.Validar();
            
            ultIdTema++;
            nuevo.Id = ultIdTema;

            temas.Add(nuevo);
        }

        public void Remove(int id)
        {
            Tema aBorrar = FindById(id);

            if (aBorrar == null) throw new OperacionInvalidaException("No existe el tema con id " + id);

            //DEBERÍAMOS CONTROLAR OTRAS COSAS, Ej. NO LO PUEDO BORRAR SI ESTÁ EN USO, ETC.

            temas.Remove(aBorrar);
        }

        public Tema FindById(int id)
        {
            Tema buscado = null;

            foreach (Tema tema in temas) {
                if (tema.Id == id)
                {
                    buscado = tema;
                    break;
                }
            }

            return buscado;
        }

        public IEnumerable<Tema> FindAll()
        {
            return temas;
        }

        public void Update(Tema tema)
        {
            if (tema == null) throw new DatosInvalidosException("No se proveen datos para la modificación");
            tema.Validar();
            Tema aModificar = FindById(tema.Id);
            if (aModificar == null) throw new OperacionInvalidaException("No existe el tema a modificar");
            aModificar.Nombre = tema.Nombre;
            aModificar.Descripcion = tema.Descripcion;
        }

        public IEnumerable<Tema> TemasContienenTexto(string texto)
        {
            List<Tema> temas_contienen = new List<Tema>();

            foreach(Tema tema in temas)
            {
                if (tema.Nombre.Valor.Contains(texto))
                {
                    temas_contienen.Add(tema);
                }
            }

            return temas_contienen;
        }
    }
}
