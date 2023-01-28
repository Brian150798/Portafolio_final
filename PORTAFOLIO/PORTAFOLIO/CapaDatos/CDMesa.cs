using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDMesa
    {
        private CDConexion conn = new CDConexion();
        MySqlDataReader leer;
        DataTable tab = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        public DataTable ListarDisponible() 
        {
            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "SP_ListarDisponible";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tab.Load(leer);
            conn.CerrarConexion();
            return tab;
        }
        public DataTable ListarMesa()
        {
            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "SP_MostrarMesa";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tab.Load(leer);
            conn.CerrarConexion();
            return tab;
        }
        public void IMesa(string numeroMesa, string ubicacion, string descripcion, int disponible_id) 
        {
            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "SP_CrearMesa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("xnumero", numeroMesa);
            comando.Parameters.AddWithValue("xlugar", ubicacion);
            comando.Parameters.AddWithValue("xdetalle", descripcion);
            comando.Parameters.AddWithValue("xdispo", disponible_id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void EMesa(string numeroMesa, string ubicacion, string descripcion, int disponible_id, int mesa)
        {
            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "SP_EditarMesa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("xnumero", numeroMesa);
            comando.Parameters.AddWithValue("xlugar", ubicacion);
            comando.Parameters.AddWithValue("xdetalle", descripcion);
            comando.Parameters.AddWithValue("xdispo", disponible_id);
            comando.Parameters.AddWithValue("xmesa", mesa);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void DMesa(int mesa)
        {
            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "SP_EliminarMesa";
            comando.CommandType = CommandType.StoredProcedure;            
            comando.Parameters.AddWithValue("xmesa", mesa);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
