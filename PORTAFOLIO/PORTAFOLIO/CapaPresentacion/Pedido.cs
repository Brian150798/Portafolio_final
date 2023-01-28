using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using MySql.Data.MySqlClient;
using CapaNegocio;


namespace CapaPresentacion
{
    public partial class Pedido : Form
    {
        public Pedido()
        {
            InitializeComponent();
        }

       

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;database=restauran;Uid=root;pwd=1234;");
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "call SP_Listar ";
            MySqlDataReader reader = cmd.ExecuteReader();
            MessageBox.Show("Presione 'Aceptar' para guardar Pedido");           
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\\Users\\Sabina\\Desktop";
            saveFileDialog1.Title = "Guardar Reporte";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string filename = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
            }
            Document doc = new Document();
            FileStream file = new FileStream(filename,
            FileMode.OpenOrCreate,
            FileAccess.ReadWrite,
            FileShare.ReadWrite);
            PdfWriter.GetInstance(doc, file);
            MessageBox.Show("PEDIDO GUARDADO!!!");

            doc.Open();
            Paragraph title = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.TIMES, 28f, BaseColor.BLUE);
            string remito = "ORDEN DE PEDIDO";
            string envio = "Fecha:" + DateTime.Now.ToString();
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("C:\\Users\\Sabina\\Desktop\\PORTAFOLIO 2023\\IMAGENES\\bodega.png");
            Chunk chunk = new Chunk("Solicitud de Insumos", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD));
            doc.Add(new Paragraph(chunk));
            doc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
            doc.Add(imagen);
            doc.Add(new Paragraph(remito));
            doc.Add(new Paragraph(envio));
            doc.AddCreationDate();
            doc.Add(new Paragraph("______________________________________________", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD)));
            doc.Add(new Paragraph("Detalle", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD)));
            doc.Add(title);
            doc.Add(new Paragraph(" "));
            PdfPTable table = new PdfPTable(2);
            table.AddCell("Nombre ");
            table.AddCell("Cantidad");

            while (reader.Read())
            {
                table.AddCell(reader.GetString("nombreSolicitar"));
                table.AddCell(reader.GetString("CantidadSolicitar"));
            }
            doc.Add(table);

            doc.Close();
            con.Close();

        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void Listar()
        {
            CNPedido bodega = new CNPedido();
            GridViewPedido.DataSource = bodega.Mostrar();
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
