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
   public class CD_Reporte
    {
        public List<ReporteCompra> Compra (string fechainicio,string fechafin,int idproveedor)
        {
            List<ReporteCompra> Lista = new List<ReporteCompra>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
            {

                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("SP_REPORTE_COMPRAS", oconexion);
                    cmd.Parameters.AddWithValue("Fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("Fechafin", fechafin);
                    cmd.Parameters.AddWithValue("IdProveedor", idproveedor);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new ReporteCompra()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumueroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoProveedor = dr["DocumentoProveedor"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioCompra = dr["PrecioCompra"].ToString(),
                                PrecioVenta = dr["PrecioVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                Subtotal = dr["Subtotal"].ToString(),

                            });
                        }
                    }

                }


                catch (Exception ex)
                {
                    Lista = new List<ReporteCompra>();
                }

            }

            return Lista;
        }


        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            List<ReporteVenta> Lista = new List<ReporteVenta>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
            {

                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("SP_REPORTE_VENTAS", oconexion);
                    cmd.Parameters.AddWithValue("Fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("Fechafin", fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new ReporteVenta()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumueroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioVenta = dr["PrecioVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                Subtotal = dr["Subtotal"].ToString(),

                            });
                        }
                    }

                }


                catch (Exception ex)
                {
                    Lista = new List<ReporteVenta>();
                }

            }

            return Lista;
        }





    }
}
