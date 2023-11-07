using Business;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioBusiness.ValidarCredenciales(txtDni.Text, txtPassword.Text))
                {
                    Int64 dni = Convert.ToInt32(txtDni.Text);

                    usuarioBusiness.GetUsuario(dni);

                    FormHome usuarioHome = new FormHome();

                    this.Hide();

                    usuarioHome.ShowDialog();

                    this.Close();


                }
                else
                    MessageBox.Show("Dni o contraseña incorrecta por favor verifique sus datos", "AVISO");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO");
            }
        }
    }
}
