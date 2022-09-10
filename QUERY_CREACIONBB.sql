create database DBSISTEMA_VENTA

GO

USE DBSISTEMA_VENTA

GO

CREATE TABLE ROL(
 
 IdRol int primary key identity,
 Descripcion varchar(100),
 FechaRegistro datetime default getdate()
)
go

--references nos sirve para relacionar las tablas como idrol

CREATE TABLE PERMISO(
 
 IdPermiso int primary key identity,
 IdRol int references ROL(IdRol),
 NombreMenu varchar(100),
 FechaRegistro datetime default getdate()
)
go

CREATE TABLE PROVEEDOR(
 
 IdProveedor int primary key identity,
 Documento varchar(50),
 RazonSocial varchar(50),
 Correo varchar(50),
 Telefono varchar(50),
 Estado bit,
 NombreMenu varchar(100),
 FechaRegistro datetime default getdate()
)
go

CREATE TABLE CLIENTE(
 
 IdCliente int primary key identity,
 Documento varchar(50),
 NombreCompleto varchar(50),
 Correo varchar(50),
 Telefono varchar(50),
 Estado bit,
 NombreMenu varchar(100),
 FechaRegistro datetime default getdate()
)
go

CREATE TABLE USUARIO(
 
 IdUsuario int primary key identity,
 Documento varchar(50),
 NombreCompleto varchar(50),
 Correo varchar(50),
 Clave varchar(50),
 IdRol int references ROL(IdRol),
 Estado bit,
 NombreMenu varchar(100),
 FechaRegistro datetime default getdate()
)
go

CREATE TABLE CATEGORIA(
 
 IdCategoria int primary key identity,
 Descripcion varchar(100),
 Estado bit,
 FechaRegistro datetime default getdate()
)
go

CREATE TABLE PRODUCTO(
 
 IdProducto int primary key identity,
 Codigo varchar(50),
 Nombre varchar(100),
 Descripcion varchar(100),
 IdCategoria int references CATEGORIA(IdCategoria ),
 Stock decimal(10,2) not null default 0,
 PrecioVenta decimal(10,2) default 0,
 PrecioCompra decimal(10,2) default 0,
 Estado bit,
 FechaRegistro datetime default getdate()
)
go

CREATE TABLE COMPRA(
 
 IdCompra int primary key identity,
 IdUsurio int references USUARIO(IdUsuario),
 IdProveedor int references PROVEEDOR(IdProveedor),
 TipoDocumento varchar(50),
 NumeroDocumento varchar(50),
 MontoTotal decimal(10,2),
 FechaRegistro datetime default getdate()
)
go

CREATE TABLE DETALLE_COMPRA(
 
 IdDetalleCompra int primary key identity,
 IdCompra int references COMPRA(IdCompra),
 IdProducto int references PRODUCTO(IdProducto),
 PrecioVenta decimal(10,2) default 0,
 PrecioCompra decimal(10,2) default 0,
 Cantidad decimal(10,2),
 MontoTotal decimal(10,2) default 0,
 FechaRegistro datetime default getdate()
)
go

CREATE TABLE VENTA(
 
 IdVenta int primary key identity,
 IdUsurio int references USUARIO(IdUsuario),
 TipoDocumento varchar(50),
 NumeroDocumento varchar(50),
 DocumentoCliente varchar(50),
 NombreCliente varchar(50),
 MontoPago decimal(10,2),
 MontoCambio decimal(10,2),
 MontoTotal decimal(10,2),
 FechaRegistro datetime default getdate()
)
go

CREATE TABLE DETALLE_VENTA(
 
 IdDetalleVenta int primary key identity,
 IdVenta int references VENTA(IdVenta ),
 IdProducto int references PRODUCTO(IdProducto),
 PrecioVenta decimal(10,2),
 Cantidad decimal(10,2),
 SubTotal decimal(10,2) default 0,
 FechaRegistro datetime default getdate()
)
go

