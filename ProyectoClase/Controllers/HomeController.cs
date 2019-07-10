using CapaDatos;
using Modelo;
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
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AgregarP()
        {
            ViewBag.Message = "Your agregarP page.";

            return View();
        }
        public ActionResult VentaP()
        {
            ViewBag.Message = "Your ventaP page.";

            return View();
        }
        public ActionResult AgregarU()
        {
            ViewBag.Message = "Your agregarU page.";

            return View();
        }
        public ActionResult AgregarUnside()
        {
            ViewBag.Message = "Your agregarU page.";

            return View();
        }



    }
}