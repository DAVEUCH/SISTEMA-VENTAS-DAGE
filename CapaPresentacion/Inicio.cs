using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Model;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public Inicio(Usuario objusuario = null)
        {
            if (objusuario == null)
                usuarioActual = new Usuario() { NombreCompleto = "ADMIN PAPURRIZ", IdUsusario = 1 };
            else
                usuarioActual = objusuario;

            InitializeComponent();
        }

       

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos =new CN_Permiso().Listar(usuarioActual.IdUsusario);

            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);

                if(encontrado == false)
                {
                    iconmenu.Visible = false;
                }
            }

            lblusuario.Text = usuarioActual.NombreCompleto;
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario){

            if(MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if(FormularioActivo != null){

                FormularioActivo.Close();
            }
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;

            //aqui le ponemos el formulario al contenedor

            contenedor.Controls.Add(formulario);
            formulario.Show();


        }

        private void menuUsuario_Click(object sender, EventArgs e)
        {
            //AbrirFormulario((IconMenuItem)sender, new fmrUsuarios());

        }

        private void submenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenimiento, new frmCategoria());

        }

        private void submenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenimiento, new frmProducto());
        }

        private void submenuRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new frmVentas(usuarioActual));
        }

        private void submenuVerDetVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new frmDetalleVenta());
        }

        private void submenuRegistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new frmCompras(usuarioActual));
        }

        private void submenuVerDetCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new frmDetalleCompra());
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void menuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }

      

        private void submenuNegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenimiento, new FrmNegocio());

        }

        private void submenuReporteCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuReportes, new frmReporteCompras());

        }

        private void submenuReporteVentas_Click(object sender, EventArgs e)
        {
            frmReporteVentas FV = new frmReporteVentas();
            //FV.ShowDialog();
            FV.Visible = true;

        }

        private void menuAcercade_Click(object sender, EventArgs e)
        {
            mdAcercade md = new mdAcercade();
            md.ShowDialog();

        }

        private void submenuCrearRol_Click(object sender, EventArgs e)
        {
            frmCrear_Rol CR = new frmCrear_Rol();
            //FV.ShowDialog();
            CR.Visible = true;

        }

        private void listaDeAccesosXRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccesosporusuario AP = new frmAccesosporusuario();
            //FV.ShowDialog();
            AP.Visible = true;

        }

        private void submenuCrearUsuarios_Click(object sender, EventArgs e)
        {
            fmrUsuarios FU = new fmrUsuarios();
            //FV.ShowDialog();
            FU.Visible = true;
            //AbrirFormulario((IconMenuItem)sender, new fmrUsuarios());
        }

     
    }
}
