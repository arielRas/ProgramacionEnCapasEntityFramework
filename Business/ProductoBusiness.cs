using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductoBusiness
    {
        private ProductoDao productoDao = new ProductoDao();

        public List<ProductoEntity> GetAllProductos()
        {
            return productoDao.GetAllProductos();
        }


        public void AltaProducto(ProductoEntity nuevoProducto)
        {
            if (nuevoProducto.Precio <= 0) throw new Exception("El precio del producto no puede ser cero o menor que cero");

            if(nuevoProducto.Descripcion == string.Empty) throw new Exception("El campo descripcion no puede estar vacio");

            productoDao.AltaProducto(nuevoProducto);
        }

        public void BajaProducto(int idProducto)
        {
            if (!productoDao.ExisteProducto(idProducto)) throw new Exception("El Producto seleccionado no existe");

            productoDao.BajaProducto(idProducto);
        }


        public void ActualizarPrecio(ProductoEntity productoActualizado)
        {
            if (productoActualizado.Precio <= 0) throw new Exception("El precio del producto no puede ser cero");

            productoDao.ActualizarPrecio(productoActualizado);
        }

    }
}
