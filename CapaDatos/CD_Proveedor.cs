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
    public class CD_Proveedor
    {
        public List<Proovedor> Listar()
        {

            List<Proovedor> lista = new List<Proovedor>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdProveedor,Documento,RazonSocial,Correo,Telefono,Estado from PROVEEDOR");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proovedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                Documento = dr["Documento"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });

                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Proovedor>();

                }
            }
            return lista;
        }

        // MEDOTO DE REGISTRAR Proovedor
        public int Registrar(Proovedor obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase Proovedor

            int idProovedorgenerado = 0;
            Mensaje = string.Empty;

            //aqui agrego mi procedimiento almacenado

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {


                    SqlCommand cmd = new SqlCommand("SP_REGISTRARPROVEEDOR", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase Proovedor
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();// con este comando ejecuto mi query

                    idProovedorgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }

            }
            catch (Exception ex)
            {
                idProovedorgenerado = 0;
                Mensaje = ex.Message;

            }

            return idProovedorgenerado;

        }

        // MEDOTO DE EDITAR Proovedor
        public bool Editar(Proovedor obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase Proovedor

            bool respuesta = false;
            Mensaje = string.Empty;

            //aqui agrego mi procedimiento almacenado

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {


                    SqlCommand cmd = new SqlCommand("SP_EDITARPROVEEDOR ", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase Proovedor

                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
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

        // MEDOTO DE ELIMINAR Proovedor
        public bool Eliminar(Proovedor obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase Categoria

            bool respuesta = false;
            Mensaje = string.Empty;

            //aqui agrego mi procedimiento almacenado

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {


                    SqlCommand cmd = new SqlCommand("SP_ELIMINARPROVEEDOR ", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase Categoria

                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
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
