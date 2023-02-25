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
    public class CD_PERMISO
    {
        //ESTE LISTADO ES PARA SABER QUE MODULOS TIENE POR USUARIO
        public List<Permiso> Listar(int idusuario)
        {

            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.IdRol, p.NombreMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.IdRol = p.IdRol");
                    query.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol");
                    query.AppendLine("where u.IdUsuario = @idusuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idusuario", idusuario);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            lista.Add(new Permiso()
                            {
                                oRol = new Rol() {IdRol= Convert.ToInt32(dr["IdRol"]) },
                                NombreMenu = dr["NombreMenu"].ToString(),

                            }) ;

                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();

                }
            }
            return lista;
        }

        public int Registrar(Permiso obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase Cliente
            int idPermisogenerado = 0;
            Mensaje = string.Empty;
            //aqui agrego mi procedimiento almacenado
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {


                    SqlCommand cmd = new SqlCommand("SP_REGISTRAR_PERMISO", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase Cliente
                    cmd.Parameters.AddWithValue("IdPermiso", obj.IdPermiso);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("NombreMenu", obj.oMenu.Nombre);
                    cmd.Parameters.AddWithValue("IdMenu", obj.oMenu.IdMenu);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();// con este comando ejecuto mi query

                    idPermisogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }

            }
            catch (Exception ex)
            {
                idPermisogenerado = 0;
                Mensaje = ex.Message;

            }

            return idPermisogenerado;

        }

        // MEDOTO DE EDITAR Producto
        public bool Editar(Permiso obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase Producto

            bool respuesta = false;
            Mensaje = string.Empty;

            //aqui agrego mi procedimiento almacenado

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {


                    SqlCommand cmd = new SqlCommand("SP_EDITAR_PERMISO ", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase Producto

                    cmd.Parameters.AddWithValue("IdPermiso", obj.IdPermiso);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("NombreMenu", obj.oMenu.Nombre);
                    cmd.Parameters.AddWithValue("IdMenu", obj.oMenu.IdMenu);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();// con este comando ejecuto mi query

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;

            }

            return respuesta;

        }

        //ESTE LISTADO ES PARA UNA TABLA DE PERMISO X MODULO
        public List<Permiso> ListarPermiso2()
        {

            List<Permiso> listaper = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdPermiso,R.IdRol,R.Descripcion[NombreRol],R.Estado,M.IdMenu,M.Nombre[NombreMenu],M.Activo from PERMISO P");
                    query.AppendLine("inner join ROL R ON P.IdRol=R.IdRol");
                    query.AppendLine("inner join MENU M ON P.IdMenu=M.IdMenu");
                   

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            listaper.Add(new Permiso()
                            {
                                IdPermiso= Convert.ToInt32(dr["IdPermiso"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["NombreRol"].ToString(), Estado = Convert.ToBoolean(dr["Estado"]) },
                                oMenu = new Menu() { IdMenu = Convert.ToInt32(dr["IdMenu"]) , Nombre = dr["NombreMenu"].ToString() , Activo= Convert.ToBoolean(dr["Activo"]) },             

                            });

                        }
                    }

                }
                catch (Exception ex)
                {
                    listaper = new List<Permiso>();

                }
            }
            return listaper;
        }

        // MEDOTO DE ELIMINAR Permiso
        public bool Eliminar(Permiso obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase Producto

            bool respuesta = false;
            Mensaje = string.Empty;

            //aqui agrego mi procedimiento almacenado

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {


                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR_PERMISO", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase Producto

                    cmd.Parameters.AddWithValue("IdPermiso", obj.IdPermiso);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();// con este comando ejecuto mi query

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;

            }

            return respuesta;

        }
    }
}
