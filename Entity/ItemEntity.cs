using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ItemEntity
    {
        //CONSTRUCTOR
        public ItemEntity(int idPedido, ProductoEntity produto, int cantidad)
        {
            this.idPedido = idPedido;
            this.producto = produto;
            this.cantidad = cantidad;
        }

        //ATRIBUTOS
        private int idPedido;
        private ProductoEntity producto;
        private int cantidad;
        private double subtotal;


        //PROPIEDADES PUBLICAS
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public ProductoEntity Producto { get => producto; set => producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Subtotal { get => GetSubtotal(); }


        //METODOS
        private double GetSubtotal()
        {
            return Producto.Precio * Cantidad;
        }
    }
}
