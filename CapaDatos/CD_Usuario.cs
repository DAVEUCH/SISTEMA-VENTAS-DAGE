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
    public class CD_Usuario
    {
        public List<Usuario> Listar(){

            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion =new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.idUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.IdRol,r.Descripcion from USUARIO u");
                    query.AppendLine("inner join rol r on r.IdRol =u.IdRol");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsusario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol =new Rol() { IdRol= Convert.ToInt32(dr["IdRol"]), Descripcion =dr["Descripcion"].ToString()}
                            });
                               
                        }
                    }

                }
                catch(Exception ex)
                {
                    lista = new List<Usuario>();

                }
            }
            return lista;
        }

        public int Registrar(Usuario obj,out string Mensaje){
            //con el public" int registrar" de arriba esta llamando objetos de clase usuario
            
            int idusuariogenerado = 0;
            Mensaje = string.Empty;

            //aqui agrego mi procedimiento almacenado

            try{

                using (SqlConnection oconexion = new SqlConnection(Conexion.CN)) {


                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase usuario
                    cmd.Parameters.AddWithValue("Documento",obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();// con este comando ejecuto mi query

                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }

            }
            catch(Exception ex) {
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            
            }

            return idusuariogenerado;

        }
    }
}
