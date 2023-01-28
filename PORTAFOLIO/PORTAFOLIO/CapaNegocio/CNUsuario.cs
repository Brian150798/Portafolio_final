using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{ 
    public class CNUsuario
    {
        private CDUsuario objetoCD = new CDUsuario();

        public DataTable MostrarRol()
        {
            DataTable tab = new DataTable();
            tab = objetoCD.Listar();
            return tab;
        }
        public DataTable MostrarUsua()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarUsuario (string nombre, string paterno, string materno, string correo, string pass, int cargo) 
        {
            objetoCD.Insertar(nombre, paterno, materno, correo, pass, cargo);
        }
        public void EditarUsuario(string nombre, string paterno, string materno, string correo, string pass, int cargo, int usuario)
        { 
            objetoCD.Editar(nombre, paterno, materno, correo, pass, cargo, usuario);
        }
        public void EliminarUsuario(int usuario) 
        {
            objetoCD.Eliminar(usuario);
        }
    }
}
