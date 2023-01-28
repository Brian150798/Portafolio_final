using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNMesa
    {
        private CDMesa objetoCD = new CDMesa();

        public DataTable MostrarDisponible() 
        {
            DataTable tab = new DataTable();
            tab = objetoCD.ListarDisponible();
            return tab;
        }
        public DataTable MostrarMesa()
        {
            DataTable tab = new DataTable();
            tab = objetoCD.ListarMesa();
            return tab;
        }
        public void InsertarMesa(string numeroMesa, string ubicacion, string descripcion, int idDisponible) 
        {
            objetoCD.IMesa(numeroMesa, ubicacion, descripcion, idDisponible);
        }
        public void EditarMesa(string numeroMesa, string ubicacion, string descripcion, int idDisponible, int idmesa)
        {
            objetoCD.EMesa(numeroMesa, ubicacion, descripcion, idDisponible, idmesa);
        }
        public void EliminarMesa(int idmesa)
        {
            objetoCD.DMesa(idmesa);
        }
    }
}
