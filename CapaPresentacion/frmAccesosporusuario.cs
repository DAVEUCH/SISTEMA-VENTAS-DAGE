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
    public partial class frmAccesosporusuario : Form
    {
        public frmAccesosporusuario()
        {
            InitializeComponent();
        }

        private void frmAccesosporusuario_Load(object sender, EventArgs e)
        {
            //LISTAR ROL  
            List<Rol> listarol = new CN_Rol().Listar();

            foreach (Rol item in listarol)
            {
                cboRol.Items.Add(new OpcionesCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;

            //LISTAR MENU

            List<Menu> listamenu = new CN_Menu().Listar();

            foreach (Menu item in listamenu)
            {
                cboMenu.Items.Add(new OpcionesCombo() { Valor = item.IdMenu, Texto = item.Nombre });
            }
            cboMenu.DisplayMember = "Texto";
            cboMenu.ValueMember = "Valor";
            cboMenu.SelectedIndex = 0;

            //ESTE FOREACH ES PARA EL COMBO DE FILTROS
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboBusqueda.Items.Add(new OpcionesCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            //LISTA LA TABLA DE PERMISOS

            List<Permiso> listapermiso = new CN_Permiso().ListarPermiso2();
            //PARA QUE SE LLENEN BIEN LAS TABLAS EN CADA CAMPO ES NECESARIO VER TU CONFIGURACION DE DATAGRIEW
            foreach (Permiso item in listapermiso)
            {
                dgvdata.Rows.Add(new object[] {item.IdPermiso,item.oRol.IdRol,item.oRol.Descripcion,item.oMenu.IdMenu,
                item.oMenu.Nombre,"",

            });

            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Permiso objpermiso = new Permiso()
            {
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionesCombo)cboRol.SelectedItem).Valor) },
                oMenu = new Menu() { IdMenu = Convert.ToInt32(((OpcionesCombo)cboMenu.SelectedItem).Valor) , Nombre= ((OpcionesCombo)cboMenu.SelectedItem).Texto} ,

            };

            if (objpermiso.IdPermiso == 0)
            {

                int idpermisogeerado = new CN_Permiso().Registrar(objpermiso, out mensaje);

                if (idpermisogeerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {idpermisogeerado,
                ((OpcionesCombo)cboRol.SelectedItem).Valor.ToString(),
                ((OpcionesCombo)cboRol.SelectedItem).Texto.ToString(),
                ((OpcionesCombo)cboMenu.SelectedItem).Valor.ToString(),
                ((OpcionesCombo)cboMenu.SelectedItem).Texto.ToString(),
                "",
                

            });

                    Limpiar();

                }
                else
                {
                    MessageBox.Show(mensaje);
                }

            }
            else
            {
                bool resultado = new CN_Permiso().Editar(objpermiso, out mensaje);

                if (resultado=false)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    //row.Cells["IdPermiso"].Value = txtid.Text;
                    row.Cells["IdRol"].Value = ((OpcionesCombo)cboRol.SelectedItem).Valor.ToString();
                    row.Cells["NombreRol"].Value = ((OpcionesCombo)cboRol.SelectedItem).Texto.ToString();
                    row.Cells["IdMenu"].Value = ((OpcionesCombo)cboMenu.SelectedItem).Valor.ToString();
                    row.Cells["NombreMenu"].Value = ((OpcionesCombo)cboMenu.SelectedItem).Texto.ToString();

                    Limpiar();

                }

                else
                {
                    MessageBox.Show(mensaje);
                }

            }
        }




            private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                //vamos a programar la celda del boton con iamgen del check

                if (e.RowIndex < 0)

                    return;

                if (e.ColumnIndex == 5)
                {

                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var w = Properties.Resources.check.Width;
                    var h = Properties.Resources.check.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                    e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                    e.Handled = true;
                }

            }

            private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            //ESTO ES PARA QUE CUANDO LE DES CLICK AL CHECK TE APARESCA PARA EDITAR
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["IdPermiso"].Value.ToString();
  

                    foreach (OpcionesCombo oc in cboRol.Items)
                    {

                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = cboRol.Items.IndexOf(oc);
                            cboRol.SelectedIndex = indice_combo;
                            break;

                        }

                    }

                    foreach (OpcionesCombo oc in cboMenu.Items)
                    {

                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdMenu"].Value))
                        {
                            int indice_combo = cboMenu.Items.IndexOf(oc);
                            cboMenu.SelectedIndex = indice_combo;
                            break;

                        }

                    }


                }
            }

        }
            private void Limpiar()
            {

                cboRol.SelectedIndex = 0;
                cboMenu.SelectedIndex = 0;
                //para que te aparezca primera en la casilla para editar

            }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea elimnar el permiso seleccionado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Permiso objpermiso = new Permiso()
                    {
                        IdPermiso = Convert.ToInt32(txtid.Text),

                    };


                    bool respuesta = new CN_Permiso().Eliminar(objpermiso, out mensaje);

                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    Limpiar();

                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionesCombo)cboBusqueda.SelectedItem).Valor.ToString();

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
            Limpiar();
        }

        //private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{

        //}

        //private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
    }

