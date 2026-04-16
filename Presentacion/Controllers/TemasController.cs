using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using Excepciones;
using LogicaNegocio.ClasesDominio;
using LogicaNegocio.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentacion.Models;

namespace Presentacion.Controllers
{
    public class TemasController : Controller
    {
        public IAltaTema CUAlta { get; set; }
        public IBajaTema CUBaja { get; set; }
        public IListadoTemas CUListado { get; set; }
        public IModificarTema CUModificar { get; set; }
        public IBuscarTemaId CUBuscarId { get; set; }

        public TemasController(IAltaTema cuAlta, IBajaTema cuBaja, IListadoTemas cuListado,
                                IModificarTema cuModificar, IBuscarTemaId cuBuscarId)
        {
            CUAlta = cuAlta;
            CUBaja = cuBaja;
            CUModificar = cuModificar;
            CUListado = cuListado;
            CUBuscarId = cuBuscarId;
        }

        // GET: TemasController
        public ActionResult Index()
        {            
            IEnumerable<TemaDTO> temas = CUListado.ObtenerListado();

            return View(temas);
        }

        // GET: TemasController/Details/5
        public ActionResult Details(int id)
        {            
            TemaDTO tema = CUBuscarId.Buscar(id);
            if (tema == null) ViewBag.Error = "El tema con id " + id + " no existe";
            return View(tema);
        }

        // GET: TemasController/Create
        public ActionResult Create() // SÓLO ADMINISTRADORES
        {
            string rol = HttpContext.Session.GetString("rol");
            if (string.IsNullOrEmpty(rol) || rol != "administrador")
            {
                return RedirectToAction("Login", "Usuarios");
            }
            return View();
        }

        // POST: TemasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TemaDTO dto)
        {
            try
            {                  
                CUAlta.EjecutarAlta(dto);
                return RedirectToAction(nameof(Index));
            }
            catch(DatosInvalidosException ex)
            {
                ViewBag.Error = ex.Message;
            }
            catch(Exception ex) 
            {
                //LOGUEAR EL ERROR
                ViewBag.Error = "Ocurrió un porblema, no se pudo realizar el alta";                
            }

            return View();
        }

        // GET: TemasController/Edit/5
        public ActionResult Edit(int id) // ADMINISTRADORES O GERENTES
        {
            string rol = HttpContext.Session.GetString("rol");
            if (string.IsNullOrEmpty(rol))
            {
                return RedirectToAction("Login", "Usuarios");
            }
            TemaDTO tema = CUBuscarId.Buscar(id);
            if (tema == null) ViewBag.Error = "El tema con id " + id + " no existe";            
            return View(tema);
        }

        // POST: TemasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TemaDTO dto)
        {
            try
            {                
                CUModificar.EjecutarModificacion(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) when (ex is DatosInvalidosException || ex is OperacionInvalidaException) 
            {
                ViewBag.Error = ex.Message;
            }            
            catch (Exception ex)
            {
                //LOGUEAR EL ERROR
                ViewBag.Error = "Ocurrió un porblema, no se pudo realizar la modificación";
            }

            return View();
        }

        // GET: TemasController/Delete/5
        public ActionResult Delete(int id) // SÓLO ADMINISTRADORES
        {
            string rol = HttpContext.Session.GetString("rol");
            if (string.IsNullOrEmpty(rol) || rol != "administrador")
            {
                return RedirectToAction("Login", "Usuarios");
            }
            TemaDTO aBorrar = CUBuscarId.Buscar(id);
            if (aBorrar == null) ViewBag.Error = "El tema con id " + id + " no existe";
            return View(aBorrar);
        }

        // POST: TemasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {                
                CUBaja.EjecutarBaja(id);
                return RedirectToAction(nameof(Index));
            }
            catch (OperacionInvalidaException ex)
            {
                ViewBag.Error = ex.Message;
            }
            catch (Exception ex)
            {
                //LOGUEAR EL ERROR
                ViewBag.Error = "Ocurrió un porblema, no se pudo realizar la baja";
            }

            return View();
        }
    }
}
