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
    
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            if ((CD_Usuario)Session["usuario"]!=null)           {
                
                return View();
            }
            return RedirectToRoute(new { controller = "Login", action = "Index" });

        }
        public ActionResult GetList()
        {
            CD_Productos productos = new CD_Productos();
            List<ProductosModel> listaP = new List<ProductosModel>();
            listaP = productos.ListaProductos();
            return Json(new { data = listaP }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            if ((CD_Usuario)Session["usuario"] != null)
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

        public ActionResult Contact()
        {
            if ((CD_Usuario)Session["usuario"] != null)
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        public ActionResult AgregarP()
        {
            if ((CD_Usuario)Session["usuario"] != null)
            {
                ViewBag.Message = "Your agregarP page.";

                return View();
            }
            return RedirectToRoute(new { controller = "Login", action = "Index" });

        }
        public ActionResult VentaP()
        {
            if ((CD_Usuario)Session["usuario"] != null)
            {
                ViewBag.Message = "Your ventaP page.";

                return View();
            }

            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
        public ActionResult AgregarU()
        {
            if ((CD_Usuario)Session["usuario"] != null)
            {
                ViewBag.Message = "Your agregarU page.";
                return View();
            }
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

        [HttpPost]
        public ActionResult recibeDatos(UsuarioModel nuevoUsuario)
        {
            var resultado = new JObject();

            CD_Usuario user = new CD_Usuario();
            if (user.NuevoUsuario(nuevoUsuario) != 0)
            {                
                resultado["Exito"] = true;
            }
            else
                resultado["Advertencia"] = true;
            return Content(resultado.ToString());
        }
        [HttpPost]
        public ActionResult recibeProducto(ProductosModel nuevoProducto)
        {
            var r = new JObject();
            CD_Productos p = new CD_Productos();
            if (p.NuevoProducto(nuevoProducto) != 0)
                r["Exito"] = true;
            else
                r["Advertencia"] = true;
            return Content(r.ToString());
        }
        [HttpPost]
        public ActionResult actualizaProducto(ProductosModel producto)
        {
            var r = new JObject();
            CD_Productos p = new CD_Productos();
            if (p.ActualizarProducto(producto) == 1)
                r["Exito"] = true;
            else
                r["Advertencia"] = true;
            return Content(r.ToString());
        }
    }
       
}