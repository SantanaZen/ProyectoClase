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

        public List<ProductosModel> ListaProductosCategoria(int categoria)
        {

            using (var contexto = new BDProyectoMVCEntities())

                return contexto.Productos.Where(producto => producto.Categoria == categoria).Select(producto => new ProductosModel()
                {
                    iCveProducto = producto.CveProducto,
                    sNombre = producto.Nombre,
                    DPrecioCompra = producto.PrecioCompra,
                    dPrecioVenta = producto.PrecioVenta,
                    iStock = producto.Stock

                }).ToList();

        }

        public int NuevoProducto(ProductosModel producto)
        {
            using (var contexto = new BDProyectoMVCEntities())
            {
                var e = contexto.Productos.Where(p => p.CveProducto == producto.iCveProducto).FirstOrDefault();
                if (e != null)
                    return 0;
                var nuevoProducto = new Productos
                {
                    CveProducto = producto.iCveProducto,
                    Nombre = producto.sNombre,
                    PrecioCompra = producto.DPrecioCompra,
                    PrecioVenta = producto.dPrecioVenta,
                    Stock = producto.iStock
                };
                contexto.Productos.Add(nuevoProducto);
                contexto.SaveChanges();
            }
            return 1;
        }     
        
        public int ActualizarProducto(ProductosModel producto)
        {
            using (var contexto = new BDProyectoMVCEntities())
            {
                var p = contexto.Productos.Where(prod => prod.CveProducto == producto.iCveProducto).FirstOrDefault();

                if(p != null)
                {
                    p.Nombre = producto.sNombre;
                    p.PrecioCompra = producto.DPrecioCompra;
                    p.PrecioVenta = producto.dPrecioVenta;
                    p.Stock = producto.iStock;
                }
                contexto.SaveChanges();
            }
            return 1;

        }
    }
}
