using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Productos
    {
        public ProductosModel ChecarProducto(ProductosModel prod)
        {
            using (var contexto = new BDProyectoMVCEntities())
            {
                int iExiste = contexto.Productos.Where(p => p.CveProducto == prod.iCveProducto).Count();
                if(iExiste > 0)
                {
                   prod = contexto.Productos.Where(p => p.CveProducto == prod.iCveProducto).Select(producto => new ProductosModel()
                    {
                       sNombre = producto.Nombre,
                       DPrecioCompra = producto.PrecioCompra,
                       dPrecioVenta = producto.PrecioVenta,
                       iStock = producto.Stock

                    }).FirstOrDefault();
                }
                return prod;
            }
        }

        public List<ProductosModel> ListaProductos()
        {
            
            using (var contexto = new BDProyectoMVCEntities())

                return contexto.Productos.Select(producto => new ProductosModel()
                {
                    iCveProducto = producto.CveProducto,
                    sNombre = producto.Nombre,
                    DPrecioCompra = producto.PrecioCompra,
                    dPrecioVenta = producto.PrecioVenta,
                    iStock = producto.Stock

                }).ToList();

        }
    }
}
