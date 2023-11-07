using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }        
        //public UsuarioEntity usuario = new UsuarioEntity(11111111, "Test", "test", "1100223344", "Calle falsa 123", "CABA", "test@test.com");//USUARIO DE PRUEBA

        private PedidoBusiness pedidoBusiness = new PedidoBusiness();

        private ProductoBusiness productoBusiness = new ProductoBusiness();

        private void ActualizarListaProducto() //ACTUALIZA LISTA DE PRODUCTOS EN LOS COMBOBOX
        {
            List<ProductoEntity> productos = productoBusiness.GetAllProductos();

            txtBoxProducto.Items.Clear();

            txtBoxProducto.DataSource = productos.ToList();            

            txtBoxProducto.DisplayMember = "Descripcion";

            txtBoxProducto.SelectedIndex = -1;

            txtBoxProducto2.Items.Clear();

            txtBoxProducto2.DataSource = productos.ToList();            

            txtBoxProducto2.DisplayMember = "Descripcion";

            txtBoxProducto2.SelectedIndex = -1;
        }

        private void btnGenerarPedido_Click(object sender, EventArgs e)
        {
            
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            ActualizarListaProducto();
        }
    }
}
