using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objcd_Proveedor = new CD_Proveedor();

        public List<Proovedor> Listar()
        {
            return objcd_Proveedor.Listar();
        }

        public int Registrar(Proovedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el numero del documento, inserte el dato solicitado porfavor\n";
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario el nombre del Proveedor, inserte el dato solicitado porfavor\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el nombre del correo, inserte el dato solicitado porfavor\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Proveedor.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Proovedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el numero del documento, inserte el dato solicitado porfavor\n";
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario el nombre del Proveedor, inserte el dato solicitado porfavor\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el nombre del correo, inserte el dato solicitado porfavor\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Proveedor.Editar(obj, out Mensaje);
            }

        }

        public bool Eliminar(Proovedor obj, out string Mensaje)
        {
            return objcd_Proveedor.Eliminar(obj, out Mensaje);
        }
    }
}
