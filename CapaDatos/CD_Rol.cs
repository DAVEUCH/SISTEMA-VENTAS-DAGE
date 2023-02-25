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
    public class CD_Rol
    {
        public List<Rol> Listar()
        {

            List<Rol> lista = new List<Rol>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdRol,Descripcion,Estado from ROL");
                   

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            lista.Add(new Rol()
                            {
                                IdRol= Convert.ToInt32(dr["IdRol"]),
                                Descripcion =dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])

                            });

                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Rol>();

                }
            }
            return lista;
        }

        //public static List<Rol> Listar2()
        //{
        //    List<Rol> rptListaRol = new List<Rol>();
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_OBTENER_ROLES", oConexion);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        try
        //        {
        //            oConexion.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                rptListaRol.Add(new Rol()
        //                {
        //                    IdRol = Convert.ToInt32(dr["IdRol"].ToString()),
        //                    Descripcion = dr["Descripcion"].ToString(),
        //                    FechaRegistro = dr["FechaRegistro"].ToString()

        //                });
        //            }
        //            dr.Close();

        //            return rptListaRol;

        //        }
        //        catch (Exception ex)
        //        {
        //            rptListaRol = null;
        //            return rptListaRol;
        //        }
        //    }
        //}

        public int Registrar(Rol obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase rol
            int idrolgenerado = 0;
            Mensaje = string.Empty;
            //aqui agrego mi procedimiento almacenado
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRAR_ROL", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase Categoria
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();// con este comando ejecuto mi query

                    idrolgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idrolgenerado = 0;
                Mensaje = ex.Message;
            }
            return idrolgenerado;
        }

        public bool Editar(Rol obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase Categoria
            bool respuesta = false;
            Mensaje = string.Empty;
            //aqui agrego mi procedimiento almacenado
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {
                    SqlCommand cmd = new SqlCommand("SP_MODIFICAR_ROL", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase Categoria

                    cmd.Parameters.AddWithValue("IdRol", obj.IdRol);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
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

        // MEDOTO DE ELIMINAR Categoria
        public bool Eliminar(Rol obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase Categoria

            bool respuesta = false;
            Mensaje = string.Empty;

            //aqui agrego mi procedimiento almacenado

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {


                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR_ROL", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase Categoria

                    cmd.Parameters.AddWithValue("IdRol", obj.IdRol);
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
