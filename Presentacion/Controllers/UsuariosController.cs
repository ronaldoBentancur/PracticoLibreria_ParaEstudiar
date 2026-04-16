using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    public class UsuariosController : Controller
    {
        public IListadoUsuarios CUListado { get; set; }
        public ILogin CULogin { get; set; }

        public UsuariosController(ILogin cuLogin, IListadoUsuarios cuListado)
        {
            CULogin = cuLogin;
            CUListado = cuListado;
        }
       

        public IActionResult Index()
        {
            string rol = HttpContext.Session.GetString("rol");
            if (string.IsNullOrEmpty(rol) || rol != "administrador")
            {
                return RedirectToAction("Login");
            }
            IEnumerable<ListadoUsuariosDTO> dtos = CUListado.ObtenerListado();
            return View(dtos);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(UsuarioDTO dto)
        {
            UsuarioDTO usuarioLogueado = CULogin.EjecutarLogin(dto.Email, dto.Password);
            if (usuarioLogueado == null)
            {
                ViewBag.Error = "El email o la contraseña son incorrectos";
                return View(dto);
            }
            else
            {
                HttpContext.Session.SetString("rol", usuarioLogueado.NombreRol);
                return RedirectToAction("Index", "Temas");
            }            
        }
    }
}
