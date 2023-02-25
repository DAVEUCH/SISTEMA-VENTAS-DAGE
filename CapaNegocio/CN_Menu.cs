using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Menu
    {
        private CD_Menu objcd_Menu = new CD_Menu();

        public List<Menu> Listar()
        {
            return objcd_Menu.Listar();
        }
    }
}
