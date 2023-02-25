using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaPresentacion.Utilidades;
using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;


namespace CapaPresentacion
{
    public partial class frmReporteVentas : Form
    {
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            // LISTA EL CMBO DE PROVEEDORES
            List<Cliente> listapro = new CN_Cliente().Listar();

            cboBusquedaCliente.Items.Add(new OpcionesCombo() { Valor = 0, Texto = "TODOS" });
            foreach (Cliente item in listapro)
            {
                cboBusquedaCliente.Items.Add(new OpcionesCombo() { Valor = item.IdCliente, Texto = item.NombreCompleto });
            }
            cboBusquedaCliente.DisplayMember = "Texto";
            cboBusquedaCliente.ValueMember = "Valor";
            cboBusquedaCliente.SelectedIndex = 0;


            //LISTA EL COMBO DE TABLA PRINCIPAL,ADEMAS ESTA FUNCION LISTA TODO LAS COLUMNAS QUE HAY EN LA TBAL
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboBusquedaTabla.Items.Add(new OpcionesCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            cboBusquedaTabla.DisplayMember = "Texto";
            cboBusquedaTabla.ValueMember = "Valor";
            cboBusquedaTabla.SelectedIndex = 0;

        }

        private void btnBuscarResultado_Click(object sender, EventArgs e)
        {
            int idcliente = Convert.ToInt32(((OpcionesCombo)cboBusquedaCliente.SelectedItem).Valor.ToString());

            List<ReporteVenta> lista = new List<ReporteVenta>();

            lista = new CN_Reporte().Venta(
                dateFechaInicio.Value.ToString(),
                ddateFechaFin.Value.ToString()
           
                );

            dgvdata.Rows.Clear();

            foreach (ReporteVenta rc in lista)
            {
                dgvdata.Rows.Add(new object[]
                    {
                        rc.FechaRegistro,
                        rc.TipoDocumento,
                        rc.NumueroDocumento,
                        rc.MontoTotal,
                        rc.UsuarioRegistro,
                        rc.DocumentoCliente,
                        rc.NombreCliente,
                        rc.CodigoProducto,
                        rc.NombreProducto,
                        rc.Categoria,
                        rc.PrecioVenta,
                        rc.Cantidad,
                        rc.Subtotal
                    });
            }

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay registros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {

                DataTable dt = new DataTable();

                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {

                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[]
                        {
                            //AQUI DECLARO LAS CELDAS QUE SE LLENARN, TAMBIEN SOLO SE DECLARAN LAS QUE ESTAN VISIBLES
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                            row.Cells[12].Value.ToString(),
                            
                        });
                }

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("REPORTE CONSOLIDADO DE COMPRAS_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                saveFile.Filter = "Excel Files | *.xlsx";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }

        }

        private void btnTablaBusqueda_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionesCombo)cboBusquedaTabla.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }

        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }

        }
    }
}
