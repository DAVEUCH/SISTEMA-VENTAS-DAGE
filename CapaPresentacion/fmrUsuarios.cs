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

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dgvdata.Rows.Add(new object[] {"",txtid.Text,txtDocumento.Text,txtNombreusu.Text,txtCorreo.Text,
                txtClave.Text, ((OpcionesCombo)cboRol.SelectedItem).Valor.ToString(),
                ((OpcionesCombo)cboRol.SelectedItem).Texto.ToString(),
                ((OpcionesCombo)cboEstado.SelectedItem).Valor.ToString(),
                ((OpcionesCombo)cboEstado.SelectedItem).Texto.ToString(),
            });

            Limpiar();
           

        }
        private void Limpiar()
        {
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
    }
}
