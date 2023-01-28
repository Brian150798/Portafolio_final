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
    public class CDProducto
    {
        private CDConexion Conn = new CDConexion();

        MySqlDataReader listar;
        DataTable Tabla = new DataTable();
        MySqlCommand cmd = new MySqlCommand();
        
        public DataTable LProducto()
        {
            cmd.Connection = Conn.AbrirConexion();
            cmd.CommandText = "SP_MostrarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            listar = cmd.ExecuteReader();
            Tabla.Load(listar);
            Conn.CerrarConexion();
            return Tabla;
        }
        public void AgregarProducto(string nombre, string cantidad) 
        {
            cmd.Connection = Conn.AbrirConexion();
            cmd.CommandText = "SP_CrearProducto";
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.AddWithValue("xnombre", nombre);
            cmd.Parameters.AddWithValue("xcantidad", cantidad);            
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        public void EditarProducto(string nombre, string cantidad, int idprod)
        {
            cmd.Connection = Conn.AbrirConexion();
            cmd.CommandText = "SP_EditarProducto";
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.AddWithValue("xnombre", nombre);
            cmd.Parameters.AddWithValue("xcantidad", cantidad);                 
            cmd.Parameters.AddWithValue("xide", idprod);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        public void EliminarProducto(int idprod)
        {
            cmd.Connection = Conn.AbrirConexion();
            cmd.CommandText = "SP_EliminarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("xide", idprod);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
