using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
     public class Menu
    {
        public int IdMenu { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; }
        public List<Submenu> oSubMenu { get; set; }
        public bool Activo { get; set; }
        public string FechaRegistro { get; set; }



    }
}
