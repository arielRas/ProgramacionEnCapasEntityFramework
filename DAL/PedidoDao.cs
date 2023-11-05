using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PedidoDao
    {   
        public PedidoEntity AltaPedido(PedidoEntity nuevoPedido)
        {
            try
            {
                using (ContextDb context = new ContextDb())
                {
                    Pedido pedidoDb = new Pedido{
                        DNI_CLIENTE = nuevoPedido.DniCliente,
                        FECHA = nuevoPedido.Fecha,
                    };

                    context.Pedido.Add(pedidoDb);

                    context.SaveChanges();

                    int nuevoId = context.Database.SqlQuery<int>("SELECT SCOPE_IDENTITY()").SingleOrDefault();

                    nuevoPedido.AsignarId(nuevoId);

                    return nuevoPedido;
                }
            }
            catch
            {
                throw;
            }
        }

        public void AgregarItemsAlPedido(PedidoEntity pedidos)
        {
            try
            {
                using (ContextDb context = new ContextDb())
                {
                    foreach (var item in pedidos.Items)
                    {
                        Producto_Pedido itemDb = new Producto_Pedido
                        {
                            ID_PEDIDO = item.IdPedido,
                            ID_PRODUCTO = item.Producto.Id,
                            CANTIDAD = item.Cantidad,
                            SUBTOTAL = Convert.ToDecimal(item.Subtotal)
                        };

                        context.Producto_Pedido.Add(itemDb);
                    }

                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }


        public List<PedidoEntity> GetAllPedidos(UsuarioEntity usuario)
        {
            try
            {
                using(ContextDb context = new ContextDb())
                {
                    List<Pedido> pedidosDb = context.Pedido.Where(pedido => pedido.DNI_CLIENTE == usuario.Dni).Select(pedido => pedido).ToList();

                    List<PedidoEntity> pedidosEntity = pedidosDb.Select(pedido => new PedidoEntity(
                            pedido.ID_PEDIDO,
                            Convert.ToInt64(pedido.DNI_CLIENTE),
                            Convert.ToDateTime(pedido.FECHA),
                            this.GetItems(pedido.ID_PEDIDO))
                    ).ToList();

                    return pedidosEntity;
                }
            }
            catch
            {
                throw;
            }
        }


        private List<ItemEntity> GetItems(int idPedido)
        {
            try
            {
                using (ContextDb context = new ContextDb())
                {
                    List<Producto_Pedido> itemsDb = context.Producto_Pedido.Where(item => item.ID_PEDIDO == idPedido).ToList();

                    List<ItemEntity> items = itemsDb.Select(item => new ItemEntity(
                            item.ID_PEDIDO,
                            ProductoDao.GetProducto(item.ID_PRODUCTO),
                            Convert.ToInt32(item.CANTIDAD),
                            Convert.ToDouble(item.SUBTOTAL)
                            )).ToList();

                    return items;
                }
            }
            catch
            {
                throw;
            }
        }
        
    }
}
