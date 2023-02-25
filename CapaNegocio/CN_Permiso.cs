using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_PERMISO objcd_permiso = new CD_PERMISO();

        public List<Permiso> Listar(int IdUsusario)
        {
            return objcd_permiso.Listar(IdUsusario);
        }

        public int Registrar(Permiso obj, out string Mensaje)
        {
            Mensaje = string.Empty;
           
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_permiso.Registrar(obj,  out Mensaje);
            }

        }

        public List<Permiso> ListarPermiso2()
        {
            return objcd_permiso.ListarPermiso2();
        }

        public bool Editar(Permiso obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_permiso.Editar(obj, out Mensaje);
            }

        }

        public bool Eliminar(Permiso obj, out string Mensaje)
        {
            return objcd_permiso.Eliminar(obj, out Mensaje);
        }

    }
}
