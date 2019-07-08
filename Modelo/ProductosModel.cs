using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
     public class ProductosModel
    {
        [Display(Name = "Clave de Producto")]
        public int iCveProducto { get; set; }
        [Display(Name = "Nombre")]
        public string sNombre { get; set; }
        [Display(Name = "Precio de compra")]
        public decimal DPrecioCompra { get; set; }
        [Display(Name = "Precio de venta")]
        public decimal dPrecioVenta { get; set; }
        [Display(Name = "Stock")]
        public int iStock { get; set; }
       
    }
}
