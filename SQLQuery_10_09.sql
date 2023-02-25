select u.idUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.IdRol,r.Descripcion from USUARIO u
inner join rol r on r.IdRol =u.IdRol

select IdProducto,Codigo,Nombre,p.Descripcion,c.IdCategoria,c.Descripcion[DescripcionCategoria],Stock,PrecioCompra, PrecioVenta from PRODUCTO p
inner join CATEGORIA c on c.IdCategoria=p.IdCategoria

select Documento,RazonSocial,Correo,Telefono,Estado from PROVEEDOR p
inner join COMPRA c on p.IdProveedor=c.IdProveedor

select IdCliente,Documento,NombreCompleto,Correo,Telefono,Estado from CLIENTE

select *from CATEGORIA

select IdCategoria,Descripcion,Estado from CATEGORIA



select*from USUARIO
select*from CATEGORIA
select*from NEGOCIO

--insert into USUARIO(Documento,NombreCompleto,Correo,Clave,IdRol,Estado) values
--('70882417','David Marinas','dave@gmail.com','123',1,1)

--update USUARIO set IdUsuario=1 where Documento='70882417'

--delete from USUARIO where IdUsuario=2005


--delete from USUARIO

--DBCC CHECKIDENT (USUARIO, RESEED, 0)

insert into CATEGORIA(Descripcion,Estado) values
('Lacteos',1),
('Bebidas',1),
('Pikeos',1),
('Otros',1)

create table NEGOCIO(

IdNegocio int primary key,
Nombre varchar(60),
RUC varchar(60),
Direccion varchar(60),
logo varbinary(max) NULL
)
GO

insert into NEGOCIO(IdNegocio,Nombre,RUC,Direccion) values
(1,'DAGE SYSTEM PERU','10708824173','Av.Perimetrica Lot 12 Mz C Urb Plantanitos del Amor')





