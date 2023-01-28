using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDConexion
    {
        private MySqlConnection Conn = new MySqlConnection("Server=localhost;database=restauran;Uid=root;pwd=1234;");
        public MySqlConnection AbrirConexion()
        {
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
            return Conn;
        }
        public MySqlConnection CerrarConexion()
        {
            if (Conn.State == ConnectionState.Open)
                Conn.Close();
            return Conn;
        }
    }
}
