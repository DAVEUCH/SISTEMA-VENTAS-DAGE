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

namespace CapaPresentacion
{
    public partial class fmrUsuarios : Form
    {
        public fmrUsuarios()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void fmrUsuarios_Load(object sender, EventArgs e)
        {
            //ESTO ES PARA EL COMBO DE ESTADO
            cboEstado.Items.Add(new OpcionesCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionesCombo() { Valor = 0, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            //ESTO ES PARA EL COMBO DE ROL

            List<Rol> listarol = new CN_Rol().Listar();

            foreach(Rol item in listarol)
            {
                cboRol.Items.Add(new OpcionesCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;

            foreach(DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboBusqueda.Items.Add(new OpcionesCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            //LISTA LA TABLA DE USUARIOS

            List<Usuario> listausuario = new CN_Usuario().Listar();

            foreach (Usuario item in listausuario)
            {
                dgvdata.Rows.Add(new object[] {"",item.IdUsusario,item.Documento,item.NombreCompleto,item.Correo,item.Clave,
                item.oRol.IdRol,//valor
                item.oRol.Descripcion,// texto
                item.Estado== true ? 1:0,//valor
                item.Estado == true ? "Activo" : "No Activo",// texto
            });

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //dgvdata.Rows.Add(new object[] {"",txtid.Text,txtDocumento.Text,txtNombreusu.Text,txtCorreo.Text,
            //    txtClave.Text, ((OpcionesCombo)cboRol.SelectedItem).Valor.ToString(),
            //    ((OpcionesCombo)cboRol.SelectedItem).Texto.ToString(),
            //    ((OpcionesCombo)cboEstado.SelectedItem).Valor.ToString(),
            //    ((OpcionesCombo)cboEstado.SelectedItem).Texto.ToString(),
            //});

            //Limpiar();
           

        }
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtDocumento.Text = "";
            txtNombreusu.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            txtConfirmarcontra.Text = "";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //vamos a programar la celda del boton con iamgen del check

            if(e.RowIndex < 0)
            
                return;

            if (e.ColumnIndex == 0) { 
                
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var w = Properties.Resources.check.Width;
                    var h = Properties.Resources.check.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w)/2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                    e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                    e.Handled = true;
                }

            
            }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //ESTO ES PARA QUE CUANDO LE DES CLICK AL CHECK TE APARESCA PARA EDITAR
            if(dgvdata.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if(indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtDocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombreusu.Text =dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtClave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfirmarcontra.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach(OpcionesCombo oc in cboRol.Items)
                    {

                        if(Convert.ToInt32( oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = cboRol.Items.IndexOf(oc);
                            cboRol.SelectedIndex = indice_combo;
                            break;

                        }

                    }

                    foreach (OpcionesCombo oc in cboEstado.Items)
                    {

                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indice_combo;
                            break;

                        }

                    }


                }
               
            }
        }
    }
    }

