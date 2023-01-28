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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "admin@gmail.com" && txtPass.Text == "1234")
            {
                this.Hide();
                Administrador admin = new Administrador();
                admin.Show();
            }
            else 
            {
                MessageBox.Show("Debe ser Administrador");
            }
        }
    }
}
