using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDPedido
    {
        private CDConexion Conn = new CDConexion();

        MySqlDataReader listar;
        DataTable Tabla = new DataTable();
        MySqlCommand cmd = new MySqlCommand();

        public DataTable Listar()
        {
            cmd.Connection = Conn.AbrirConexion();
            cmd.CommandText = "SP_Listar";
            cmd.CommandType = CommandType.StoredProcedure;
            listar = cmd.ExecuteReader();
            Tabla.Load(listar);
            Conn.CerrarConexion();
            return Tabla;
        }

    }

}
