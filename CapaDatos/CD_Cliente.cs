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
   public class CD_Cliente
    {
        public List<Cliente> Listar()
        {

            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdCliente,Documento,NombreCompleto,Correo,Telefono,Estado from CLIENTE");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });

                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>();

                }
            }
            return lista;
        }

        // MEDOTO DE REGISTRAR Cliente
        public int Registrar(Cliente obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase Cliente

            int idClientegenerado = 0;
            Mensaje = string.Empty;

            //aqui agrego mi procedimiento almacenado

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {


                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCLIENTE", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase Cliente
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();// con este comando ejecuto mi query

                    idClientegenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }

            }
            catch (Exception ex)
            {
                idClientegenerado = 0;
                Mensaje = ex.Message;

            }

            return idClientegenerado;

        }

        // MEDOTO DE EDITAR Cliente
        public bool Editar(Cliente obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase Cliente

            bool respuesta = false;
            Mensaje = string.Empty;

            //aqui agrego mi procedimiento almacenado

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {


                    SqlCommand cmd = new SqlCommand("SP_EDITARCLIENTE ", oconexion);
                    //con el public" int registrar" de arriba esta llamando objetos de clase Cliente

                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
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

        // MEDOTO DE ELIMINAR Cliente
        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            //con el public" int registrar" de arriba esta llamando objetos de clase Cliente

            bool respuesta = false;
            Mensaje = string.Empty;

            //aqui agrego mi procedimiento almacenado

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {


                    SqlCommand cmd = new SqlCommand("delete from CLIENTE where IdCliente= @IdCliente", oconexion);
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    respuesta= cmd.ExecuteNonQuery() > 0 ? true :false;// con este comando ejecuto mi query
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
