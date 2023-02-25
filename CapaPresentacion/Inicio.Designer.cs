
namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuUsuario = new FontAwesome.Sharp.IconMenuItem();
            this.submenuCrearRol = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeAccesosXRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuCrearUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMantenimiento = new FontAwesome.Sharp.IconMenuItem();
            this.submenuCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.submenuProducto = new FontAwesome.Sharp.IconMenuItem();
            this.submenuNegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areasSucursalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centroDeCostosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subCentroDeCostosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subsubCentroDeCostosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.almacenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDePrecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motivoDeOperacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeCambioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serieYNumeracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formaDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegistrarVenta = new FontAwesome.Sharp.IconMenuItem();
            this.movVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuVerDetVenta = new FontAwesome.Sharp.IconMenuItem();
            this.ordenDePedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movOrdenDePedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploradorDeOrdenDePedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cotizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movCotizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guiaDeRemisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movGuiaDeRemisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expGuiaDeRemisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegistrarCompra = new FontAwesome.Sharp.IconMenuItem();
            this.submenuVerDetCompra = new FontAwesome.Sharp.IconMenuItem();
            this.ordenDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movOrdenDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expOrdenDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitudDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movSolicitudDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expSolictudDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitudDeRequerimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuProveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.submenuReporteCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuReporteVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAcercade = new FontAwesome.Sharp.IconMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.movSolicitudDeRequermientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expSolicituDeRequerimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuario,
            this.menuMantenimiento,
            this.menuVentas,
            this.menuCompras,
            this.menuClientes,
            this.menuProveedores,
            this.menuReportes,
            this.menuAcercade});
            this.menu.Location = new System.Drawing.Point(0, 60);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1367, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuUsuario
            // 
            this.menuUsuario.AutoSize = false;
            this.menuUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuCrearRol,
            this.listaDeAccesosXRolToolStripMenuItem,
            this.submenuCrearUsuarios});
            this.menuUsuario.IconChar = FontAwesome.Sharp.IconChar.UserCog;
            this.menuUsuario.IconColor = System.Drawing.Color.Black;
            this.menuUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuario.IconSize = 50;
            this.menuUsuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuario.Name = "menuUsuario";
            this.menuUsuario.Size = new System.Drawing.Size(122, 69);
            this.menuUsuario.Text = "Seguridad";
            this.menuUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuUsuario.Click += new System.EventHandler(this.menuUsuario_Click);
            // 
            // submenuCrearRol
            // 
            this.submenuCrearRol.Name = "submenuCrearRol";
            this.submenuCrearRol.Size = new System.Drawing.Size(180, 22);
            this.submenuCrearRol.Text = "Crear Rol";
            this.submenuCrearRol.Click += new System.EventHandler(this.submenuCrearRol_Click);
            // 
            // listaDeAccesosXRolToolStripMenuItem
            // 
            this.listaDeAccesosXRolToolStripMenuItem.Name = "listaDeAccesosXRolToolStripMenuItem";
            this.listaDeAccesosXRolToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listaDeAccesosXRolToolStripMenuItem.Text = "Crear Permisos";
            this.listaDeAccesosXRolToolStripMenuItem.Click += new System.EventHandler(this.listaDeAccesosXRolToolStripMenuItem_Click);
            // 
            // submenuCrearUsuarios
            // 
            this.submenuCrearUsuarios.Name = "submenuCrearUsuarios";
            this.submenuCrearUsuarios.Size = new System.Drawing.Size(180, 22);
            this.submenuCrearUsuarios.Text = "Crear Usuarios";
            this.submenuCrearUsuarios.Click += new System.EventHandler(this.submenuCrearUsuarios_Click);
            // 
            // menuMantenimiento
            // 
            this.menuMantenimiento.AutoSize = false;
            this.menuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuCategoria,
            this.submenuProducto,
            this.submenuNegocio,
            this.marcaToolStripMenuItem,
            this.areasSucursalesToolStripMenuItem,
            this.centroDeCostosToolStripMenuItem,
            this.almacenToolStripMenuItem,
            this.cajaToolStripMenuItem,
            this.transportistaToolStripMenuItem,
            this.listaDePrecioToolStripMenuItem,
            this.motivoDeOperacionToolStripMenuItem,
            this.monedaToolStripMenuItem,
            this.tipoDeCambioToolStripMenuItem,
            this.vendedorToolStripMenuItem,
            this.serieYNumeracionToolStripMenuItem,
            this.formaDePagoToolStripMenuItem});
            this.menuMantenimiento.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menuMantenimiento.IconColor = System.Drawing.Color.Black;
            this.menuMantenimiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMantenimiento.IconSize = 50;
            this.menuMantenimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMantenimiento.Name = "menuMantenimiento";
            this.menuMantenimiento.Size = new System.Drawing.Size(122, 69);
            this.menuMantenimiento.Text = "Mantenimiento";
            this.menuMantenimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuCategoria
            // 
            this.submenuCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuCategoria.IconColor = System.Drawing.Color.Black;
            this.submenuCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuCategoria.Name = "submenuCategoria";
            this.submenuCategoria.Size = new System.Drawing.Size(186, 22);
            this.submenuCategoria.Text = "Categoria";
            this.submenuCategoria.Click += new System.EventHandler(this.submenuCategoria_Click);
            // 
            // submenuProducto
            // 
            this.submenuProducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuProducto.IconColor = System.Drawing.Color.Black;
            this.submenuProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuProducto.Name = "submenuProducto";
            this.submenuProducto.Size = new System.Drawing.Size(186, 22);
            this.submenuProducto.Text = "Producto";
            this.submenuProducto.Click += new System.EventHandler(this.submenuProducto_Click);
            // 
            // submenuNegocio
            // 
            this.submenuNegocio.Name = "submenuNegocio";
            this.submenuNegocio.Size = new System.Drawing.Size(186, 22);
            this.submenuNegocio.Text = "Negocio";
            this.submenuNegocio.Click += new System.EventHandler(this.submenuNegocio_Click);
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.marcaToolStripMenuItem.Text = "Marca";
            // 
            // areasSucursalesToolStripMenuItem
            // 
            this.areasSucursalesToolStripMenuItem.Name = "areasSucursalesToolStripMenuItem";
            this.areasSucursalesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.areasSucursalesToolStripMenuItem.Text = "Areas - Sucursales";
            // 
            // centroDeCostosToolStripMenuItem
            // 
            this.centroDeCostosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subCentroDeCostosToolStripMenuItem});
            this.centroDeCostosToolStripMenuItem.Name = "centroDeCostosToolStripMenuItem";
            this.centroDeCostosToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.centroDeCostosToolStripMenuItem.Text = "Centro de Costos";
            // 
            // subCentroDeCostosToolStripMenuItem
            // 
            this.subCentroDeCostosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subsubCentroDeCostosToolStripMenuItem});
            this.subCentroDeCostosToolStripMenuItem.Name = "subCentroDeCostosToolStripMenuItem";
            this.subCentroDeCostosToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.subCentroDeCostosToolStripMenuItem.Text = "Sub Centro de Costos";
            // 
            // subsubCentroDeCostosToolStripMenuItem
            // 
            this.subsubCentroDeCostosToolStripMenuItem.Name = "subsubCentroDeCostosToolStripMenuItem";
            this.subsubCentroDeCostosToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.subsubCentroDeCostosToolStripMenuItem.Text = "Subsub Centro de Costos";
            // 
            // almacenToolStripMenuItem
            // 
            this.almacenToolStripMenuItem.Name = "almacenToolStripMenuItem";
            this.almacenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.almacenToolStripMenuItem.Text = "Almacen";
            // 
            // cajaToolStripMenuItem
            // 
            this.cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            this.cajaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cajaToolStripMenuItem.Text = "Caja";
            // 
            // transportistaToolStripMenuItem
            // 
            this.transportistaToolStripMenuItem.Name = "transportistaToolStripMenuItem";
            this.transportistaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.transportistaToolStripMenuItem.Text = "Transportista";
            // 
            // listaDePrecioToolStripMenuItem
            // 
            this.listaDePrecioToolStripMenuItem.Name = "listaDePrecioToolStripMenuItem";
            this.listaDePrecioToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.listaDePrecioToolStripMenuItem.Text = "Lista de Precio";
            // 
            // motivoDeOperacionToolStripMenuItem
            // 
            this.motivoDeOperacionToolStripMenuItem.Name = "motivoDeOperacionToolStripMenuItem";
            this.motivoDeOperacionToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.motivoDeOperacionToolStripMenuItem.Text = "Motivo de Operacion";
            // 
            // monedaToolStripMenuItem
            // 
            this.monedaToolStripMenuItem.Name = "monedaToolStripMenuItem";
            this.monedaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.monedaToolStripMenuItem.Text = "Moneda";
            // 
            // tipoDeCambioToolStripMenuItem
            // 
            this.tipoDeCambioToolStripMenuItem.Name = "tipoDeCambioToolStripMenuItem";
            this.tipoDeCambioToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.tipoDeCambioToolStripMenuItem.Text = "Tipo de Cambio";
            // 
            // vendedorToolStripMenuItem
            // 
            this.vendedorToolStripMenuItem.Name = "vendedorToolStripMenuItem";
            this.vendedorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.vendedorToolStripMenuItem.Text = "Vendedor";
            // 
            // serieYNumeracionToolStripMenuItem
            // 
            this.serieYNumeracionToolStripMenuItem.Name = "serieYNumeracionToolStripMenuItem";
            this.serieYNumeracionToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.serieYNumeracionToolStripMenuItem.Text = "Serie y Numeracion";
            // 
            // formaDePagoToolStripMenuItem
            // 
            this.formaDePagoToolStripMenuItem.Name = "formaDePagoToolStripMenuItem";
            this.formaDePagoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.formaDePagoToolStripMenuItem.Text = "Forma de pago";
            // 
            // menuVentas
            // 
            this.menuVentas.AutoSize = false;
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistrarVenta,
            this.submenuVerDetVenta,
            this.ordenDePedidoToolStripMenuItem,
            this.cotizacionToolStripMenuItem,
            this.guiaDeRemisionToolStripMenuItem});
            this.menuVentas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuVentas.IconColor = System.Drawing.Color.Black;
            this.menuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVentas.IconSize = 50;
            this.menuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(122, 69);
            this.menuVentas.Text = "Ventas";
            this.menuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuRegistrarVenta
            // 
            this.submenuRegistrarVenta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movVentaToolStripMenuItem,
            this.expVentaToolStripMenuItem});
            this.submenuRegistrarVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegistrarVenta.IconColor = System.Drawing.Color.Black;
            this.submenuRegistrarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegistrarVenta.Name = "submenuRegistrarVenta";
            this.submenuRegistrarVenta.Size = new System.Drawing.Size(166, 22);
            this.submenuRegistrarVenta.Text = "Venta";
            this.submenuRegistrarVenta.Click += new System.EventHandler(this.submenuRegistrarVenta_Click);
            // 
            // movVentaToolStripMenuItem
            // 
            this.movVentaToolStripMenuItem.Name = "movVentaToolStripMenuItem";
            this.movVentaToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.movVentaToolStripMenuItem.Text = "Punto de venta";
            // 
            // expVentaToolStripMenuItem
            // 
            this.expVentaToolStripMenuItem.Name = "expVentaToolStripMenuItem";
            this.expVentaToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.expVentaToolStripMenuItem.Text = "Exp. Venta";
            // 
            // submenuVerDetVenta
            // 
            this.submenuVerDetVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuVerDetVenta.IconColor = System.Drawing.Color.Black;
            this.submenuVerDetVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuVerDetVenta.Name = "submenuVerDetVenta";
            this.submenuVerDetVenta.Size = new System.Drawing.Size(166, 22);
            this.submenuVerDetVenta.Text = "Ver Detalle";
            this.submenuVerDetVenta.Click += new System.EventHandler(this.submenuVerDetVenta_Click);
            // 
            // ordenDePedidoToolStripMenuItem
            // 
            this.ordenDePedidoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movOrdenDePedidoToolStripMenuItem,
            this.exploradorDeOrdenDePedidoToolStripMenuItem});
            this.ordenDePedidoToolStripMenuItem.Name = "ordenDePedidoToolStripMenuItem";
            this.ordenDePedidoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.ordenDePedidoToolStripMenuItem.Text = "Orden de Pedido";
            // 
            // movOrdenDePedidoToolStripMenuItem
            // 
            this.movOrdenDePedidoToolStripMenuItem.Name = "movOrdenDePedidoToolStripMenuItem";
            this.movOrdenDePedidoToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.movOrdenDePedidoToolStripMenuItem.Text = "Mov. Orden de Pedido";
            // 
            // exploradorDeOrdenDePedidoToolStripMenuItem
            // 
            this.exploradorDeOrdenDePedidoToolStripMenuItem.Name = "exploradorDeOrdenDePedidoToolStripMenuItem";
            this.exploradorDeOrdenDePedidoToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.exploradorDeOrdenDePedidoToolStripMenuItem.Text = "Exp. de Orden de Pedido";
            // 
            // cotizacionToolStripMenuItem
            // 
            this.cotizacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movCotizacionToolStripMenuItem,
            this.exToolStripMenuItem});
            this.cotizacionToolStripMenuItem.Name = "cotizacionToolStripMenuItem";
            this.cotizacionToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cotizacionToolStripMenuItem.Text = "Cotizacion";
            // 
            // movCotizacionToolStripMenuItem
            // 
            this.movCotizacionToolStripMenuItem.Name = "movCotizacionToolStripMenuItem";
            this.movCotizacionToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.movCotizacionToolStripMenuItem.Text = "Mov. Cotizacion";
            // 
            // exToolStripMenuItem
            // 
            this.exToolStripMenuItem.Name = "exToolStripMenuItem";
            this.exToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exToolStripMenuItem.Text = "Ex. Cotizacion";
            // 
            // guiaDeRemisionToolStripMenuItem
            // 
            this.guiaDeRemisionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movGuiaDeRemisionToolStripMenuItem,
            this.expGuiaDeRemisionToolStripMenuItem});
            this.guiaDeRemisionToolStripMenuItem.Name = "guiaDeRemisionToolStripMenuItem";
            this.guiaDeRemisionToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.guiaDeRemisionToolStripMenuItem.Text = "Guia de Remision";
            // 
            // movGuiaDeRemisionToolStripMenuItem
            // 
            this.movGuiaDeRemisionToolStripMenuItem.Name = "movGuiaDeRemisionToolStripMenuItem";
            this.movGuiaDeRemisionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.movGuiaDeRemisionToolStripMenuItem.Text = "Mov. Guia de Remision";
            // 
            // expGuiaDeRemisionToolStripMenuItem
            // 
            this.expGuiaDeRemisionToolStripMenuItem.Name = "expGuiaDeRemisionToolStripMenuItem";
            this.expGuiaDeRemisionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.expGuiaDeRemisionToolStripMenuItem.Text = "Exp. Guia de Remision";
            // 
            // menuCompras
            // 
            this.menuCompras.AutoSize = false;
            this.menuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistrarCompra,
            this.submenuVerDetCompra,
            this.ordenDeCompraToolStripMenuItem,
            this.solicitudDeCompraToolStripMenuItem,
            this.solicitudDeRequerimientoToolStripMenuItem});
            this.menuCompras.IconChar = FontAwesome.Sharp.IconChar.CartFlatbed;
            this.menuCompras.IconColor = System.Drawing.Color.Black;
            this.menuCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCompras.IconSize = 50;
            this.menuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCompras.Name = "menuCompras";
            this.menuCompras.Size = new System.Drawing.Size(122, 69);
            this.menuCompras.Text = "Compras";
            this.menuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuRegistrarCompra
            // 
            this.submenuRegistrarCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegistrarCompra.IconColor = System.Drawing.Color.Black;
            this.submenuRegistrarCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegistrarCompra.Name = "submenuRegistrarCompra";
            this.submenuRegistrarCompra.Size = new System.Drawing.Size(217, 22);
            this.submenuRegistrarCompra.Text = "Registrar";
            this.submenuRegistrarCompra.Click += new System.EventHandler(this.submenuRegistrarCompra_Click);
            // 
            // submenuVerDetCompra
            // 
            this.submenuVerDetCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuVerDetCompra.IconColor = System.Drawing.Color.Black;
            this.submenuVerDetCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuVerDetCompra.Name = "submenuVerDetCompra";
            this.submenuVerDetCompra.Size = new System.Drawing.Size(217, 22);
            this.submenuVerDetCompra.Text = "Ver Detalle";
            this.submenuVerDetCompra.Click += new System.EventHandler(this.submenuVerDetCompra_Click);
            // 
            // ordenDeCompraToolStripMenuItem
            // 
            this.ordenDeCompraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movOrdenDeCompraToolStripMenuItem,
            this.expOrdenDeCompraToolStripMenuItem});
            this.ordenDeCompraToolStripMenuItem.Name = "ordenDeCompraToolStripMenuItem";
            this.ordenDeCompraToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.ordenDeCompraToolStripMenuItem.Text = "Orden de Compra";
            // 
            // movOrdenDeCompraToolStripMenuItem
            // 
            this.movOrdenDeCompraToolStripMenuItem.Name = "movOrdenDeCompraToolStripMenuItem";
            this.movOrdenDeCompraToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.movOrdenDeCompraToolStripMenuItem.Text = "Mov. Orden de Compra";
            // 
            // expOrdenDeCompraToolStripMenuItem
            // 
            this.expOrdenDeCompraToolStripMenuItem.Name = "expOrdenDeCompraToolStripMenuItem";
            this.expOrdenDeCompraToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.expOrdenDeCompraToolStripMenuItem.Text = "Exp. Orden de Compra";
            // 
            // solicitudDeCompraToolStripMenuItem
            // 
            this.solicitudDeCompraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movSolicitudDeCompraToolStripMenuItem,
            this.expSolictudDeCompraToolStripMenuItem});
            this.solicitudDeCompraToolStripMenuItem.Name = "solicitudDeCompraToolStripMenuItem";
            this.solicitudDeCompraToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.solicitudDeCompraToolStripMenuItem.Text = "Solicitud de Compra";
            // 
            // movSolicitudDeCompraToolStripMenuItem
            // 
            this.movSolicitudDeCompraToolStripMenuItem.Name = "movSolicitudDeCompraToolStripMenuItem";
            this.movSolicitudDeCompraToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.movSolicitudDeCompraToolStripMenuItem.Text = "Mov. Solicitud de Compra";
            // 
            // expSolictudDeCompraToolStripMenuItem
            // 
            this.expSolictudDeCompraToolStripMenuItem.Name = "expSolictudDeCompraToolStripMenuItem";
            this.expSolictudDeCompraToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.expSolictudDeCompraToolStripMenuItem.Text = "Exp. Solictud de Compra";
            // 
            // solicitudDeRequerimientoToolStripMenuItem
            // 
            this.solicitudDeRequerimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movSolicitudDeRequermientoToolStripMenuItem,
            this.expSolicituDeRequerimientoToolStripMenuItem});
            this.solicitudDeRequerimientoToolStripMenuItem.Name = "solicitudDeRequerimientoToolStripMenuItem";
            this.solicitudDeRequerimientoToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.solicitudDeRequerimientoToolStripMenuItem.Text = "Solicitud de Requerimiento";
            // 
            // menuClientes
            // 
            this.menuClientes.AutoSize = false;
            this.menuClientes.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            this.menuClientes.IconColor = System.Drawing.Color.Black;
            this.menuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuClientes.IconSize = 50;
            this.menuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(122, 69);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);
            // 
            // menuProveedores
            // 
            this.menuProveedores.AutoSize = false;
            this.menuProveedores.IconChar = FontAwesome.Sharp.IconChar.Vcard;
            this.menuProveedores.IconColor = System.Drawing.Color.Black;
            this.menuProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProveedores.IconSize = 50;
            this.menuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProveedores.Name = "menuProveedores";
            this.menuProveedores.Size = new System.Drawing.Size(122, 69);
            this.menuProveedores.Text = "Proveedores";
            this.menuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProveedores.Click += new System.EventHandler(this.menuProveedores_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.AutoSize = false;
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuReporteCompras,
            this.submenuReporteVentas});
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.menuReportes.IconColor = System.Drawing.Color.Black;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReportes.IconSize = 50;
            this.menuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(122, 69);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuReporteCompras
            // 
            this.submenuReporteCompras.Name = "submenuReporteCompras";
            this.submenuReporteCompras.Size = new System.Drawing.Size(236, 22);
            this.submenuReporteCompras.Text = "Reporte Compras Consolidado";
            this.submenuReporteCompras.Click += new System.EventHandler(this.submenuReporteCompras_Click);
            // 
            // submenuReporteVentas
            // 
            this.submenuReporteVentas.Name = "submenuReporteVentas";
            this.submenuReporteVentas.Size = new System.Drawing.Size(236, 22);
            this.submenuReporteVentas.Text = "Reporte Ventas Consolidado";
            this.submenuReporteVentas.Click += new System.EventHandler(this.submenuReporteVentas_Click);
            // 
            // menuAcercade
            // 
            this.menuAcercade.AutoSize = false;
            this.menuAcercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuAcercade.IconColor = System.Drawing.Color.Black;
            this.menuAcercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAcercade.IconSize = 50;
            this.menuAcercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAcercade.Name = "menuAcercade";
            this.menuAcercade.Size = new System.Drawing.Size(122, 69);
            this.menuAcercade.Text = "Acerca de";
            this.menuAcercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuAcercade.Click += new System.EventHandler(this.menuAcercade_Click);
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.menutitulo.Location = new System.Drawing.Point(0, 0);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menutitulo.Size = new System.Drawing.Size(1367, 60);
            this.menutitulo.TabIndex = 1;
            this.menutitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de Ventas";
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 133);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1367, 592);
            this.contenedor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(983, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.SteelBlue;
            this.lblusuario.ForeColor = System.Drawing.Color.White;
            this.lblusuario.Location = new System.Drawing.Point(1033, 23);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(59, 15);
            this.lblusuario.TabIndex = 5;
            this.lblusuario.Text = "lblusuario";
            // 
            // movSolicitudDeRequermientoToolStripMenuItem
            // 
            this.movSolicitudDeRequermientoToolStripMenuItem.Name = "movSolicitudDeRequermientoToolStripMenuItem";
            this.movSolicitudDeRequermientoToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.movSolicitudDeRequermientoToolStripMenuItem.Text = "Mov.Solicitud de Requermiento";
            // 
            // expSolicituDeRequerimientoToolStripMenuItem
            // 
            this.expSolicituDeRequerimientoToolStripMenuItem.Name = "expSolicituDeRequerimientoToolStripMenuItem";
            this.expSolicituDeRequerimientoToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.expSolicituDeRequerimientoToolStripMenuItem.Text = "Exp. Solicitu de Requerimiento";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 725);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menutitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private FontAwesome.Sharp.IconMenuItem menuUsuario;
        private FontAwesome.Sharp.IconMenuItem menuMantenimiento;
        private FontAwesome.Sharp.IconMenuItem menuVentas;
        private FontAwesome.Sharp.IconMenuItem menuCompras;
        private FontAwesome.Sharp.IconMenuItem menuClientes;
        private FontAwesome.Sharp.IconMenuItem menuProveedores;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private FontAwesome.Sharp.IconMenuItem menuAcercade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblusuario;
        private FontAwesome.Sharp.IconMenuItem submenuCategoria;
        private FontAwesome.Sharp.IconMenuItem submenuProducto;
        private FontAwesome.Sharp.IconMenuItem submenuRegistrarVenta;
        private FontAwesome.Sharp.IconMenuItem submenuVerDetVenta;
        private FontAwesome.Sharp.IconMenuItem submenuRegistrarCompra;
        private FontAwesome.Sharp.IconMenuItem submenuVerDetCompra;
        private System.Windows.Forms.ToolStripMenuItem submenuNegocio;
        private System.Windows.Forms.ToolStripMenuItem submenuReporteCompras;
        private System.Windows.Forms.ToolStripMenuItem submenuReporteVentas;
        private System.Windows.Forms.ToolStripMenuItem submenuCrearRol;
        private System.Windows.Forms.ToolStripMenuItem listaDeAccesosXRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem submenuCrearUsuarios;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areasSucursalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centroDeCostosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subCentroDeCostosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subsubCentroDeCostosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem almacenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportistaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDePrecioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motivoDeOperacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monedaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeCambioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serieYNumeracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formaDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenDePedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movOrdenDePedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploradorDeOrdenDePedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cotizacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movCotizacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guiaDeRemisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movGuiaDeRemisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expGuiaDeRemisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movOrdenDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expOrdenDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitudDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movSolicitudDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expSolictudDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitudDeRequerimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movSolicitudDeRequermientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expSolicituDeRequerimientoToolStripMenuItem;
    }
}

