using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductoEntity
    {
        //CONSTRUCTOR
        public ProductoEntity(string descripcion, double precio)
        {
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public ProductoEntity(int id, string descripcion, double precio)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        //ATRIBUTOS
        private int id;
        private string descripcion;
        private double precio;


        //PROPIEDADES PUBLICAS
        public int Id { get => id; }
        public string Descripcion { get => descripcion; }
        public double Precio { get => precio; }


        //METODOS
        public void ActualizarPrecio(double nuevoPrecio)
        {
            this.precio = nuevoPrecio;
        }
    }
}
