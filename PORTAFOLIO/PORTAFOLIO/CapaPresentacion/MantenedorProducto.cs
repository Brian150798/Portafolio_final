using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class MantenedorProducto : Form
    {
        public MantenedorProducto()
        {
            InitializeComponent();
        }
        CNProducto prod = new CNProducto();
        string Operacion = "Insertar";
        string idprod;
        private void Bodega_Load(object sender, EventArgs e)
        {
          
        }
        public void ListarProducto()
        {
            CNProducto prod = new CNProducto();
            GridViewProducto.DataSource = prod.MostrarProducto();
        }
        private void Limpiar()
        {
            txtNom.Clear();
            txtCan.Clear();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar") 
            {
                prod.IProducto(txtNom.Text, txtCan.Text);
                MessageBox.Show("Producto agregado con exito");
            }
            else if (Operacion == "Editar") 
            {
                prod.EProductoo(txtNom.Text, txtCan.Text, Convert.ToInt32(idprod));
                Operacion = "Insertar";
                MessageBox.Show("Producto editado correctamentamente");
            }
            ListarProducto();
            Limpiar();
        }
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (GridViewProducto.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                txtNom.Text = GridViewProducto.CurrentRow.Cells["PRODUCTO"].Value.ToString();
                txtCan.Text = GridViewProducto.CurrentRow.Cells["CANTIDAD"].Value.ToString();
                idprod = GridViewProducto.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione la fila a editar");
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GridViewProducto.SelectedRows.Count > 0)
            {
                idprod = GridViewProducto.CurrentRow.Cells["ID"].Value.ToString();
                prod.DProducto(Convert.ToInt32(idprod));
                MessageBox.Show("Producto eliminado");
                ListarProducto();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }
        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Administrador adm = new Administrador();
            adm.FormClosed += (s, args) => this.Close();
            adm.Show();
        }

    }
}
