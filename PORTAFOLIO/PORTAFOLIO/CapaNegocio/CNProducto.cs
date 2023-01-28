using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNProducto
    {
        private CDProducto objetoCD = new CDProducto();
    
        public DataTable MostrarProducto()
        {
            DataTable Tab = new DataTable();
            Tab = objetoCD.LProducto();
            return Tab;
        }
        public void IProducto(string nombre, string cantidad)
        {
            objetoCD.AgregarProducto(nombre, cantidad);
        }
        public void EProductoo(string nombre, string cantidad, int idprod)
        {
            objetoCD.EditarProducto(nombre, cantidad, idprod);
        }
        public void DProducto(int idprod)
        {
            objetoCD.EliminarProducto(idprod);
        }
    }
}
