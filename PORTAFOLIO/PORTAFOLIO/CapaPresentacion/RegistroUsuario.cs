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
    public partial class RegistroUsuario : Form
    {
        CNUsuario objetoCN = new CNUsuario();
        string Operacion = "Insertar";
        string IDUsuario;
        public RegistroUsuario()
        {
            InitializeComponent();
        }
        private void RegistroUsuario_Load(object sender, EventArgs e)
        {
            ListarRol();
        }
        public void ListarRol()
        {
            CNUsuario objeto = new CNUsuario();
            cmbUser.DataSource = objeto.MostrarRol();
            cmbUser.DisplayMember = "nombreRol";
            cmbUser.ValueMember = "idRol";
        }
        private void MostrarUsuario() 
        {
            CNUsuario objeto = new CNUsuario();
            GridViewUsuario.DataSource = objeto.MostrarUsua();
        }
        private void LimpiarForm()
        {
            txtNom.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtCorreo.Clear();
            txtPas.Clear();
            cmbUser.Text = ("");
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                objetoCN.InsertarUsuario(txtNom.Text, txtAP.Text, txtAM.Text, txtCorreo.Text, txtPas.Text, Convert.ToInt32(cmbUser.SelectedValue));
                MessageBox.Show("Usuario creado correctamente");
            }
            else if (Operacion == "Editar")
            {
                objetoCN.EditarUsuario(txtNom.Text, txtAP.Text, txtAM.Text, txtCorreo.Text, txtPas.Text, Convert.ToInt32(cmbUser.SelectedValue), Convert.ToInt32(IDUsuario));
                Operacion = "Insertar";
                MessageBox.Show("Usuario editado correctamente");               
            }
            MostrarUsuario();
            LimpiarForm();
            
            
        }
        
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (GridViewUsuario.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                txtNom.Text = GridViewUsuario.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtAP.Text = GridViewUsuario.CurrentRow.Cells["APATERNO"].Value.ToString();
                txtAM.Text = GridViewUsuario.CurrentRow.Cells["AMATERNO"].Value.ToString();
                txtCorreo.Text = GridViewUsuario.CurrentRow.Cells["CORREO"].Value.ToString();
                txtPas.Text = GridViewUsuario.CurrentRow.Cells["PASSWORD"].Value.ToString();
                cmbUser.Text = GridViewUsuario.CurrentRow.Cells["CARGO"].Value.ToString();
                IDUsuario = GridViewUsuario.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("Selecciona una fila por favor");
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (GridViewUsuario.SelectedRows.Count > 0) 
            {
                IDUsuario = GridViewUsuario.CurrentRow.Cells["ID"].Value.ToString();
                objetoCN.EliminarUsuario(Convert.ToInt32(IDUsuario));
                MessageBox.Show("Usuario eliminado");
                MostrarUsuario();
            }
            else
                MessageBox.Show("Selecciona una fila por favor");
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrador adm = new Administrador();
            adm.FormClosed += (s, args) => this.Close();
            adm.Show();
        }
    }
}
