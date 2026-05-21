
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentacion.DTOs;
using Presentacion.Models;

namespace Presentacion.Controllers
{
    public class TemasController : Controller
    {
       
        // GET: TemasController
        public ActionResult Index()
        {            
            List<TemaDTO> temas = new List<TemaDTO>();

            HttpClient cliente = new HttpClient();

            Task<HttpResponseMessage> tarea1 = cliente.GetAsync("http://localhost:5174/api/temas");
            tarea1.Wait();

            HttpResponseMessage respuesta = tarea1.Result;
            HttpContent contenido = respuesta.Content;
            
            if (respuesta.IsSuccessStatusCode)
            {
                Task<List<TemaDTO>> tarea2 = contenido.ReadFromJsonAsync<List<TemaDTO>>();
                tarea2.Wait();

                temas = tarea2.Result;
            }
            else
            {
                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                ViewBag.Error = tarea2.Result;
            }

            return View(temas);
        }

        // GET: TemasController/Details/5
        public ActionResult Details(int id)
        {
            TemaDTO tema = null;

            HttpClient cliente = new HttpClient();

            var tarea1 = cliente.GetAsync("http://localhost:5174/api/temas/" + id);
            tarea1.Wait();           
            

            if (tarea1.Result.IsSuccessStatusCode)
            {
                var tarea2 = tarea1.Result.Content.ReadFromJsonAsync<TemaDTO>();
                tarea2.Wait();

                tema = tarea2.Result;
            }
            else
            {
                var tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                tarea2.Wait();

                ViewBag.Error = tarea2.Result;
            }

            return View(tema);
        }

        [HttpGet]
        // GET: TemasController/Create
        public ActionResult Create() // SÓLO ADMINISTRADORES
        {
            //string rol = HttpContext.Session.GetString("rol");
            //if (string.IsNullOrEmpty(rol) || rol != "administrador")
            //{
            //    return RedirectToAction("Login", "Usuarios");
            //}
            return View();
        }

        // POST: TemasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TemaDTO dto)
        {
            try
            {                  
                //API
                return RedirectToAction(nameof(Index));
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
            //string rol = HttpContext.Session.GetString("rol");
            //if (string.IsNullOrEmpty(rol))
            //{
            //    return RedirectToAction("Login", "Usuarios");
            //}
           //API
                        
            return View();
        }

        // POST: TemasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TemaDTO dto)
        {
            try
            {                
               //API
                return RedirectToAction(nameof(Index));
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
            //string rol = HttpContext.Session.GetString("rol");
            //if (string.IsNullOrEmpty(rol) || rol != "administrador")
            //{
            //    return RedirectToAction("Login", "Usuarios");
            //}
            //API
            
            return View();
        }

        // POST: TemasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {                
                //API
                return RedirectToAction(nameof(Index));
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
