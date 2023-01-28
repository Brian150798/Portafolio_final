using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistroUsuario user = new RegistroUsuario();
            user.FormClosed += (s, args) => this.Close();
            user.Show();
        }

        private void BtnMesa_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantenedorMesa mesa = new MantenedorMesa();
            mesa.FormClosed += (s, args) => this.Close();
            mesa.Show();
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            this.Hide();
            MantenedorProducto bodega = new MantenedorProducto();
            bodega.FormClosed += (s, args) => this.Close();
            bodega.Show();
        }

        private void BtnPedido_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pedido pedido = new Pedido();
            pedido.FormClosed += (s, args) => this.Close();
            pedido.Show();
        }
    }
}
