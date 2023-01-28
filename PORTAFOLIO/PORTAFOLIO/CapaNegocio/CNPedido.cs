using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;


namespace CapaNegocio
{
    public class CNPedido
    {
        private CDPedido objetoCD = new CDPedido();

        public DataTable Mostrar()
        {
            DataTable Tab = new DataTable();
            Tab = objetoCD.Listar();
            return Tab;
        }


    }
}

