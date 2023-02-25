using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaEntidad;
using CapaPresentacion.Utilidades;
using CapaPresentacion.Model;
using CapaNegocio;
using System.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace CapaPresentacion
{
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new CN_Compra().ObtenerCompra(txtBusquedanrodoc.Text);

            if(oCompra.IdCompra != 0)
            {
                txtnrodoc.Text = oCompra.NumeroDocumento;

                txtFecha.Text = oCompra.FechaRegistro;
                txtTipoDoc.Text = oCompra.TipoDocumento;
                txtUsuario.Text = oCompra.oUsuario.NombreCompleto;
                txtNumdocprov.Text = oCompra.oProveedor.Documento;
                txtNomProveedor.Text = oCompra.oProveedor.RazonSocial;

                dgvdata.Rows.Clear();
                foreach(Detalle_Compra dc in oCompra.oDetalleCompra)
                {
                    dgvdata.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });
                }

                txtTotalPagar.Text = oCompra.MontoTotal.ToString("0.00");
            }
            
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtTipoDoc.Text = "";
            txtUsuario.Text = "";
            txtNumdocprov.Text = "";
            txtNomProveedor.Text = "";
            dgvdata.Rows.Clear();
            txtTotalPagar.Text = "0.00";
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (txtTipoDoc.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_Html = Properties.Resources.PlantillaCompra.ToString();
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            //AQUI ESTAMOS LLAMANDO LOS CAMPOS DE NEGOCIO PARA QUE SE IMPRIMAN EN EL PDF
            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.RUC.ToUpper());
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion.ToUpper());

            //AQUI ESTAMOS LLAMANDO LOS CAMPOS DE DOCUMENTO DE COMPRA PARA QUE SE IMPRIMAN EN EL PDF
            Texto_Html = Texto_Html.Replace("@tipodocumento", txtTipoDoc.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnrodoc.Text);

            //AQUI ESTAMOS LLAMANDO LOS CAMPOS DE PROVEEDOR PARA QUE SE IMPRIMAN EN EL PDF
            Texto_Html = Texto_Html.Replace("@docproveedor", txtNumdocprov.Text);
            Texto_Html = Texto_Html.Replace("@nombreproveedor", txtNomProveedor.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtFecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtUsuario.Text);


            //AQUI IMPRIMIREMOS LAS FILAS EN LA TABLA HTML
            string filas = string.Empty;
            foreach(DataGridViewRow row in dgvdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Subtotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtTotalPagar.Text);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = string.Format("REPORTE DE COMPRA_{0}.pdf", txtBusquedanrodoc.Text);
            saveFile.Filter = "Pdf Files | *.pdf";

            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream =new FileStream(saveFile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4,25,25,25,25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        //AJUSTANDO E TEXTO
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

       
    }
}
