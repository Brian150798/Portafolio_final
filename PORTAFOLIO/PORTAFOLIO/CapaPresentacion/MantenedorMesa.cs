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
    public partial class MantenedorMesa : Form
    {
        public MantenedorMesa()
        {
            InitializeComponent();
        }
        CNMesa objMesa = new CNMesa();
        string Operacion = "Insertar";
        string idmesa;

        private void MantenedorMesa_Load(object sender, EventArgs e)
        {
            ListarDisponible();            
        }
        public void ListarDisponible()
        {
            CNMesa objMesa = new CNMesa();
            cmbDisponible.DataSource = objMesa.MostrarDisponible();
            cmbDisponible.DisplayMember = "nombreDisponible";
            cmbDisponible.ValueMember = "idDisponible";
        }
        private void ListarMesa()
        {
            CNMesa objMesa = new CNMesa();
            GridViewMesa.DataSource = objMesa.MostrarMesa();
        }
        private void LimpiarFormulario() 
        {
            txtNumero.Clear();
            txtUbicacion.Clear();
            txtDescripcion.Clear();
            cmbDisponible.Text = ("");
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                objMesa.InsertarMesa(txtNumero.Text, txtUbicacion.Text, txtDescripcion.Text, Convert.ToInt32(cmbDisponible.SelectedValue));
                MessageBox.Show("Mesa guardada correctamente");
            }
            else if (Operacion == "Editar") 
            {
                objMesa.EditarMesa(txtNumero.Text, txtUbicacion.Text, txtDescripcion.Text, Convert.ToInt32(cmbDisponible.SelectedValue), Convert.ToInt32(idmesa));
                Operacion = "Insertar";
                MessageBox.Show("Mesa editada correctamente");
            }
            ListarMesa();
            LimpiarFormulario();
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (GridViewMesa.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                txtNumero.Text = GridViewMesa.CurrentRow.Cells["NUMEROMESA"].Value.ToString();
                txtUbicacion.Text = GridViewMesa.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = GridViewMesa.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                cmbDisponible.Text = GridViewMesa.CurrentRow.Cells[4].Value.ToString();
                idmesa = GridViewMesa.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione la fila a editar");
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (GridViewMesa.SelectedRows.Count > 0)
            {
                idmesa = GridViewMesa.CurrentRow.Cells["ID"].Value.ToString();
                objMesa.EliminarMesa(Convert.ToInt32(idmesa));
                MessageBox.Show("Eliminado correctamente");
                ListarMesa();
            }
            else
                MessageBox.Show("Seleccione la fila a eliminar");
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrador adm = new Administrador();
            adm.FormClosed += (s, args) => this.Close();
            adm.Show();
        }
    }
}
