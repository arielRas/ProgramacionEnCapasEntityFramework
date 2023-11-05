using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PedidoEntity
    {
        //CONSTRUCTOR

        public PedidoEntity(Int64 dniCliente)
        {
            this.dniCliente = dniCliente;
        }

        public PedidoEntity(int idPedido, Int64 dniCliente, DateTime fecha, List<ItemEntity> items)
        {
            this.idPedido = idPedido;
            this.dniCliente = dniCliente;
            this.fecha = fecha;
            this.items = items;
        }

        //ATRIBUTOS
        private int idPedido;
        private Int64 dniCliente;
        private DateTime fecha;
        private List<ItemEntity> items = new List<ItemEntity>();


        //PROPIEDADES
        public int IdPedido { get => idPedido; }
        public long DniCliente { get => dniCliente; }
        public DateTime Fecha { get => fecha; }
        public double Total { get => GetTotal(); }
        public List<ItemEntity> Items { get => items; }


        //METODOS

        public void AsignarId(int id)
        {
            this.idPedido = id;
        }

        public void AsignarFecha(DateTime fecha)
        {
            this.fecha = fecha;
        }

        private double GetTotal()
        {
            if (Items.Count > 0) return this.Items.Select(item => item.Subtotal).Sum();

            else return 0;
        }

        public void AgregarItem(ItemEntity nuevoItem)
        {
            if (!this.Items.Contains(nuevoItem)) Items.Add(nuevoItem);

            else throw new Exception("Ud ya seleccionado este producto, por favor seleccione otro");
        }

        public void RemoverItem()
        {
            this.items.RemoveAt(-1);
        }
    }
}
