using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CDUsuario
    {
        private CDConexion conexion = new CDConexion();
        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand com = new MySqlCommand();

        public DataTable Listar()
        {
            com.Connection = conexion.AbrirConexion();
            com.CommandText = "SP_ListarRol";
            com.CommandType = CommandType.StoredProcedure;
            leer = com.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable Mostrar()
        {
            com.Connection = conexion.AbrirConexion();
            com.CommandText = "SP_MostrarUsuario";
            com.CommandType = CommandType.StoredProcedure;
            leer = com.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar (string nombre, string paterno, string materno, string correo, string pass, int cargo) 
        {
            com.Connection = conexion.AbrirConexion();
            com.CommandText = "SP_CrearUsuario";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("nom", nombre);
            com.Parameters.AddWithValue("ape", paterno);
            com.Parameters.AddWithValue("ama", materno);
            com.Parameters.AddWithValue("mail", correo);
            com.Parameters.AddWithValue("pas", pass);
            com.Parameters.AddWithValue("roll", cargo);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
        }
        public void Editar(string nombre, string paterno, string materno, string correo, string pass, int cargo, int usuario) 
        {
            com.Connection = conexion.AbrirConexion();
            com.CommandText = "SP_EditarUsuario";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("nom", nombre);
            com.Parameters.AddWithValue("ape", paterno);
            com.Parameters.AddWithValue("ama", materno);
            com.Parameters.AddWithValue("mail", correo);
            com.Parameters.AddWithValue("pas", pass);
            com.Parameters.AddWithValue("roll", cargo);
            com.Parameters.AddWithValue("id", usuario);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
        }
        public void Eliminar (int usuario) 
        {
            com.Connection = conexion.AbrirConexion();
            com.CommandText = "SP_EliminarUsuario";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("id", usuario);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
        }

    }
}
