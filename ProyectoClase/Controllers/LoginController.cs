using CapaDatos;
using Modelo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoClase.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logeo(UsuarioModel datosUsuario)
        {
            var resultado = new JObject();

            CD_Usuario user = new CD_Usuario();
            if (user.ChecarUsuario(datosUsuario).sNombre != null)
            {
                Session["usuario"] = user;
                resultado["Exito"] = true;

            }
                
            else
                resultado["Advertencia"] = true;
            return Content(resultado.ToString());
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Abandon();
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

    }
}
