﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Rol
    {
        private CD_Rol objcd_rol = new CD_Rol();

        public List<Rol> Listar()
        {
            return objcd_rol.Listar();
        }

        public int Registrar(Rol obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario el nombre del Rol del usuario, inserte el dato solicitado porfavor\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_rol.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Rol obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario el nombre del rol, inserte el dato solicitado porfavor\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_rol.Editar(obj, out Mensaje);
            }

        }
        public bool Eliminar(Rol obj, out string Mensaje)
        {
            return objcd_rol.Eliminar(obj, out Mensaje);
        }
    }
}
