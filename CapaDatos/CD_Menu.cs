using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;


 namespace CapaDatos
{
    public class CD_Menu
    {

        public List<Menu> Listar()
        {

            List<Menu> lista = new List<Menu>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdMenu,Nombre,Activo from MENU");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Menu()
                            {
                                IdMenu = Convert.ToInt32(dr["IdMenu"]),
                                Nombre = dr["Nombre"].ToString(),
                                Activo = Convert.ToBoolean(dr["Activo"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Menu>();

                }
            }
            return lista;
        }

    }
}
