using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business
{
    public class PedidoBusiness
    {
        private PedidoDao pedidoDao = new PedidoDao();

        public void AltaPedido(PedidoEntity nuevoPedido)
        {
            if (nuevoPedido.Items.Count == 0) throw new Exception("No se puede dar de alta un pedido vacio");

            nuevoPedido.AsignarFecha(DateTime.Now);

            using(TransactionScope trx = new TransactionScope())
            {
                nuevoPedido = pedidoDao.AltaPedido(nuevoPedido);

                pedidoDao.AgregarItemsAlPedido(nuevoPedido);

                trx.Complete();
            }
        }


        public List<PedidoEntity> GetAllPedidos(UsuarioEntity usuario)
        {
            return pedidoDao.GetAllPedidos(usuario);
        }

    }
}
