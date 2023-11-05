using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoDao
    {
        public List<ProductoEntity> GetAllProductos()
        {
            try
            {
                using(ContextDb context =  new ContextDb())
                {
                    List<Producto> productosDb =  context.Producto.ToList();

                    return productosDb.Select(producto => new ProductoEntity(producto.ID_PRODUCTO, producto.DESCRIPCION, Convert.ToDouble(producto.PRECIO))).ToList();
                }
            }
            catch 
            {
                throw;
            }
        }

        public void AltaProducto(ProductoEntity nuevoProducto)
        {
            try
            {
                using(ContextDb context = new ContextDb())
                {
                    Producto productoDb = new Producto{
                        DESCRIPCION = nuevoProducto.Descripcion,
                        PRECIO = Convert.ToDecimal(nuevoProducto.Precio)
                    };

                    context.Producto.Add(productoDb);

                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }


        public void BajaProducto(int id)
        {
            try
            {
                using (ContextDb context = new ContextDb())
                {
                    Producto productoDb = context.Producto.Where(producto => producto.ID_PRODUCTO == id).Select(producto => producto).FirstOrDefault();

                    context.Producto.Remove(productoDb);

                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarPrecio(ProductoEntity productoActualizado)
        {
            try
            {
                using (ContextDb context = new ContextDb())
                {
                    Producto productoDb = context.Producto.FirstOrDefault(producto => producto.ID_PRODUCTO == productoActualizado.Id);

                    productoDb.PRECIO = Convert.ToDecimal(productoActualizado.Precio);

                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }


        internal static ProductoEntity GetProducto(int id)
        {
            try
            {
                using (ContextDb context = new ContextDb())
                {   
                    ProductoEntity productoEntity = context.Producto.Where(p => p.ID_PRODUCTO == id).Select(p => new ProductoEntity(p.ID_PRODUCTO, p.DESCRIPCION, Convert.ToDouble(p.PRECIO))).FirstOrDefault();

                    return productoEntity;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool ExisteProducto(int id)
        {
            using(ContextDb context = new ContextDb())
            {
                if(context.Producto.Where(p => p.ID_PRODUCTO == id).Count() == 1) return true;

                    return false;
            }
        }

    }
}
