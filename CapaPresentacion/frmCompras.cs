using CapaEntidad;
using CapaPresentacion.Utilidades;
using CapaPresentacion.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocio;
using System.Linq;

namespace CapaPresentacion
{
    public partial class frmCompras : Form
    {
        private Usuario _Usuario;
        public frmCompras(Usuario oUsuario=null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void frmCompras_Load(object sender, EventArgs e)
        {

            //ESTO ES PARA EL COMBO DE TIPO DE DOCUMENTO
            cboDocumento.Items.Add(new OpcionesCombo() { Valor = "FACTURA", Texto = "FACTURA" });
            cboDocumento.Items.Add(new OpcionesCombo() { Valor = "BOLETA", Texto = "BOLETA" });
            cboDocumento.DisplayMember = "Texto";
            cboDocumento.ValueMember = "Valor";
            cboDocumento.SelectedIndex = 0;

            //ESTO ES PARA LA FECHA DE HOY
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtidProveedor.Text = "0";
            txtidProducto.Text = "0";

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal =new mdProveedor())
            {
                var result = modal.ShowDialog();

                if(result == DialogResult.OK)
                {
                    txtidProveedor.Text = modal._Provvedor.IdProveedor.ToString();
                    txtNumdoc.Text = modal._Provvedor.Documento;
                    txtNomProveedor.Text = modal._Provvedor.RazonSocial;
                }
                else
                {
                    txtNumdoc.Select();
                }
            }

        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidProducto.Text = modal._Producto.IdProducto.ToString();
                    txtCodigoProducto.Text = modal._Producto.Codigo;
                    txtProducto.Text = modal._Producto.Nombre;
                    //txtPrecioCompra.Text = modal._Producto.PrecioCompra.ToString();
                    //txtPrecioVenta.Text = modal._Producto.PrecioVenta.ToString();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }

        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().Listar().Where(p => p.Codigo == txtCodigoProducto.Text && p.Estado == true).FirstOrDefault();

                if(oProducto != null)
                {
                    txtCodigoProducto.BackColor = Color.Honeydew;
                    txtidProducto.Text = oProducto.IdProducto.ToString();
                    txtProducto.Text = oProducto.Nombre;
                    txtPrecioCompra.Select();

                }
                else
                {
                    txtCodigoProducto.BackColor = Color.MistyRose;
                    txtidProducto.Text = "0";
                    txtProducto.Text = "";

                }
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0;
            decimal precioventa = 0;
            bool prodcuto_existe = false;

            if (int.Parse(txtidProducto.Text) == 0)
            {
                MessageBox.Show("Debe sellecionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtPrecioCompra.Text,out preciocompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
                return;
            }

            if (!decimal.TryParse(txtPrecioVenta.Text, out precioventa))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
                return;
            }

            foreach(DataGridViewRow fila in dgvdata.Rows)
            {
                if(fila.Cells["IdProducto"].Value.ToString() == txtidProducto.Text)
                {
                    prodcuto_existe = true;
                    break;
                }
            }
            if (!prodcuto_existe)
            {
                dgvdata.Rows.Add(new object[]
                {
                    txtidProducto.Text,
                    txtProducto.Text,
                    preciocompra.ToString("0.00"),
                    precioventa.ToString("0.00"),
                    txtCantidad.Value.ToString("0.00"),
                    (txtCantidad.Value * preciocompra).ToString("0.00")


                });

                CalcularTotal();
                LimpiarProducto();
            }

        }
        private void LimpiarProducto()
        {
            txtidProducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtCodigoProducto.BackColor = Color.White;
            txtProducto.Text = "";
            txtPrecioCompra.Text = "0.00";
            txtPrecioVenta.Text = "0.00";
            txtCantidad.Value = 1;
            //para que te aparezca primera en la casilla para editar
            txtCodigoProducto.Select();

        }

        private void CalcularTotal()
        {
            decimal total = 0;
            if(dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString());

            }
            txtTotalPagar.Text = total.ToString("0.00");
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //vamos a programar la celda del boton con iamgen del check

            if (e.RowIndex < 0)

                return;

            if (e.ColumnIndex == 6)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.basura.Width;
                var h = Properties.Resources.basura.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.basura, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ESTO ES PARA QUE CUANDO LE DES CLICK EL BOTON DE ELIMINAR PO DETALLE EN LA COMPRA
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgvdata.Rows.RemoveAt(indice);
                    CalcularTotal();
                 
                }
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ESTO ES PARA QUE EL TXT SOLO SE PUEDA ESCRIBIR NUMEROS

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if(txtPrecioCompra.Text.Trim().Length ==0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if(Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }

            }
             

        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {

            //ESTO ES PARA QUE EL TXT SOLO SE PUEDA ESCRIBIR NUMEROS

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }

            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtidProveedor.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            //PARAMETRO DATATABLE

            DataTable detalle_compra = new DataTable();

            detalle_compra.Columns.Add("IdProducto", typeof(int));
            detalle_compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(decimal));
            detalle_compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach(DataGridViewRow row in dgvdata.Rows)
            {
                detalle_compra.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                        row.Cells["PrecioCompra"].Value.ToString(),
                        row.Cells["PrecioVenta"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["Subtotal"].Value.ToString()

                    });
            }

            int idcorrelativo = new CN_Compra().ObtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000000}", idcorrelativo);

            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsusario = _Usuario.IdUsusario },
                oProveedor = new Proovedor() { IdProveedor = Convert.ToInt32(txtidProveedor.Text) },
                TipoDocumento = ((OpcionesCombo)cboDocumento.SelectedItem).Texto,
                NumeroDocumento = numerodocumento,
                MontoTotal = Convert.ToDecimal(txtTotalPagar.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(oCompra, detalle_compra, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Numer de compra Genenerada:\n" + numerodocumento + "\n\n¿Desea copiar al portapapeles?","Mensaje",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    Clipboard.SetText(numerodocumento);

                txtidProveedor.Text = "0";
                txtNumdoc.Text = "";
                txtNomProveedor.Text = "";
                dgvdata.Rows.Clear();
                CalcularTotal();
            }

            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
