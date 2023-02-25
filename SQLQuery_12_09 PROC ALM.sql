select*from USUARIO

--delete USUARIO where IdUsuario=2

--update USUARIO set Estado=0 where IdUsuario=2

--alter proc SP_REGISTRARUSUARIO(
-- @Documento varchar(50),
-- @NombreCompleto varchar(50),
-- @Correo varchar(50),
-- @Clave varchar(50),
-- @IdRol int,
-- @Estado bit,
-- @IdUsuarioResultado int output,
-- @Mensaje varchar(500) output
-- )

--as
--begin

--set @IdUsuarioResultado =0
--set @Mensaje=''

--if not exists (select*from USUARIO where Documento = @Documento)
--begin

-- insert into usuario(Documento,NombreCompleto,Correo,Clave,IdRol,Estado)
-- values(@Documento,@NombreCompleto,@Correo,@Clave,@IdRol,@Estado)

-- set @IdUsuarioResultado = SCOPE_IDENTITY()
 
-- end
-- else
-- set @Mensaje= 'No se puede repetir el documento para mas de un usuario'
-- end

--CREATE proc SP_EDITARUSUARIO(

-- @IdUsuario int,
-- @Documento varchar(50),
-- @NombreCompleto varchar(50),
-- @Correo varchar(50),
-- @Clave varchar(50),
-- @IdRol int,
-- @Estado bit,
-- @Respuesta bit output,
-- @Mensaje varchar(500) output
-- )

--as
--begin

--set @Respuesta =0
--set @Mensaje=''

--if not exists (select*from USUARIO where Documento = @Documento and IdUsuario != @IdUsuario)
--begin

-- update usuario set
-- Documento = @Documento,
-- NombreCompleto = @NombreCompleto,
-- Correo = @Correo,
-- Clave= @Clave,
-- IdRol = @IdRol,
-- Estado = @Estado
-- where IdUsuario = @IdUsuario


-- set @Respuesta = 1
 
-- end
-- else
-- set @Mensaje= 'No se puede repetir el documento para mas de un usuario'
-- end

--CREATE proc SP_ELIMINARRUSUARIO(

-- @IdUsuario int,
-- @Respuesta bit output,
-- @Mensaje varchar(500) output
-- )

--as
--begin

--set @Respuesta =0
--set @Mensaje=''
--declare @pasoreglas bit = 1

--if exists (select *from COMPRA C
--inner join USUARIO U on u.IdUsuario = C.IdUsurio
--where u.IdUsuario =@IdUsuario)

--begin
--    set @pasoreglas =0
--    set @Respuesta =0
--	set @Mensaje= @Mensaje +'No se puede eliminar porque el usuario esta relacionado a una Compra\n'

--end

--if exists (select *from VENTA V
--inner join USUARIO U on u.IdUsuario = V.IdUsurio
--where u.IdUsuario =@IdUsuario)

--begin
--    set @pasoreglas =0
--    set @Respuesta =0
--	set @Mensaje= @Mensaje +'No se puede eliminar porque el usuario esta relacionado a una Venta\n'

--end

--if(@pasoreglas = 1)
--  begin 
--  delete from USUARIO where IdUsuario = @IdUsuario
--  set @Respuesta =1
--  end
-- end
--USE DBSISTEMA_VENTA



--PROCEDIMIENTO  ALMACENADO PARA GUARDAR CATEGORIA
--CREATE PROC SP_REGISTRARCATEGORIA(
--@Descripcion varchar(50),
--@Resultado bit output,
--@Mensaje varchar(500) output
--) as
--begin
--    set @Resultado =0
--	if not exists (select*from CATEGORIA where Descripcion = @Descripcion)
--	begin
--	    insert into CATEGORIA(Descripcion) values(@Descripcion)
--		set @Resultado = SCOPE_IDENTITY()
--		end
--		else
--		set @Mensaje= 'No se puede repetir la misma categoría'

--end

--go

----PROCEDIMIENTO  ALMACENADO PARA MODIFICAR CATEGORIA
--CREATE PROC SP_EDITARCATEGORIA(
--@IdCategoria varchar(50),
--@Descripcion varchar(50),
--@Resultado bit output,
--@Mensaje varchar(500) output
--) as
--begin
--    set @Resultado = 1
--	  if not exists (select*from CATEGORIA where Descripcion = @Descripcion and IdCategoria != @IdCategoria)
--	  update CATEGORIA set
--	  Descripcion = @Descripcion
--	  where IdCategoria=IdCategoria
--	  else
--	  begin
--	      set @Resultado=0
--		  set @Mensaje= 'No se puede repetir la misma categoría'
--	  end

--end

--GO

----PROCEDIMIENTO  ALMACENADO PARA ELIMINAR CATEGORIA
--CREATE PROC SP_ELIMINARCATEGORIA(
--@IdCategoria varchar(50),
--@Resultado bit output,
--@Mensaje varchar(500) output
--) as
--begin
--    set @Resultado = 1
--	  if not exists (
--	  select*from CATEGORIA C
--	  inner join PRODUCTO P ON P.IdCategoria = C.IdCategoria
--	  where c.IdCategoria =@IdCategoria
--	  )
--	  begin
--	    delete top(1) from CATEGORIA where IdCategoria= @IdCategoria
--		end
--	  else
--	  begin
--	      set @Resultado=0
--		  set @Mensaje= 'No se puede eliminar la categoria seleccionada porque se encuentra relacionada a un producto'
--	  end
--end

--go

--PROCEDIMIENTO  ALMACENADO PARA GUARDAR PRODUCTO
--CREATE PROC SP_REGISTRARPRODUCTO(
--@Codigo varchar(50),
--@Nombre varchar(100),
--@Descripcion varchar(100),
--@IdCategoria int,
--@Estado bit,
--@Resultado int output,
--@Mensaje varchar(500) output
--) as
--begin
--    set @Resultado =0
--	if not exists (select*from PRODUCTO where Codigo = @Codigo)
--	begin
--	    insert into PRODUCTO(Codigo,Nombre,Descripcion,IdCategoria,Estado) values(@Codigo,@Nombre,@Descripcion,@IdCategoria,@Estado)
--		set @Resultado = SCOPE_IDENTITY()
--		end
--		else
--		set @Mensaje= 'Ya existe un producto con el mismo codigo'

--end
--go

----PROCEDIMIENTO  ALMACENADO PARA MODIFICAR CATEGORIA
--CREATE PROC SP_EDITARPRODUCTO(
--@IdProducto int,
--@Codigo varchar(50),
--@Nombre varchar(100),
--@Descripcion varchar(100),
--@IdCategoria int,
--@Estado bit,
--@Resultado int output,
--@Mensaje varchar(500) output
--) as
--begin
--    set @Resultado = 1
--	  if not exists (select*from PRODUCTO where Codigo = @Codigo and  IdProducto != @IdProducto)
--	  update PRODUCTO set
--	  Codigo = @Codigo, Nombre=@Nombre, Descripcion=@Descripcion,IdCategoria=@IdCategoria,Estado=@Estado
--	  where IdProducto=@IdProducto
--	  else
--	  begin
--	      set @Resultado=0
--		  set @Mensaje= 'Ya existe un producto con el mismo codigo'
--	  end

--end

--GO

--PROCEDIMIENTO  ALMACENADO PARA ELIMINAR CATEGORIA
--CREATE PROC SP_ELIMINARPRODUCTO(
--@IdProducto varchar(50),
--@Respuesta bit output,
--@Mensaje varchar(500) output
--) as
--begin
--    set @Respuesta = 0
--	set @Mensaje=''
--	declare @pasoreglas bit =1
--	  if not exists (
--	  select*from DETALLE_COMPRA DC
--	  inner join PRODUCTO P ON P.IdProducto = DC.IdProducto
--	  where P.IdProducto =@IdProducto
--	  )
--	  begin
--	      set @pasoreglas = 0
--	      set @Respuesta = 0
--	      set @Mensaje = @Mensaje + 'No se puede eliminar porque se encuentra relacionado a una Compra\n'
--		  end

--      if exists(
--	  select*from DETALLE_VENTA DV
--	  inner join PRODUCTO P ON P.IdProducto = DV.IdProducto
--	  where P.IdProducto =@IdProducto
--	  )
--	  begin
--	      set @pasoreglas = 0
--	      set @Respuesta = 0
--	      set @Mensaje = @Mensaje + 'No se puede eliminar porque se encuentra relacionado a una Venta\n'
--		  end

--	   if(@pasoreglas =1)
--	   begin
--	   delete from PRODUCTO where IdProducto= @IdProducto
--	   set @Respuesta=1
--		end
--end

--go

--select*from CLIENTE 
--DROP TABLE CLIENTE 
--CREATE TABLE CLIENTE(
 
-- IdCliente int primary key identity,
-- Documento varchar(50),
-- NombreCompleto varchar(50),
-- Correo varchar(50),
-- Telefono varchar(50),
-- Estado bit,
-- FechaRegistro datetime default getdate()
--)
--go

-- create proc SP_REGISTRARCLIENTE(
-- @Documento varchar(50),
-- @NombreCompleto varchar(50),
-- @Correo varchar(50),
-- @Telefono varchar(50),
-- @Estado bit,
-- @Resultado int output,
-- @Mensaje varchar(500) output
-- )
--as
--begin

--set @Resultado =0
--set @Mensaje=''
--declare @IDPERSONA INT

--if not exists (select*from CLIENTE where Documento = @Documento)
--begin

-- insert into CLIENTE(Documento,NombreCompleto,Correo,Telefono,Estado)
-- values(@Documento,@NombreCompleto,@Correo,@Telefono,@Estado)

-- set @Resultado = SCOPE_IDENTITY()
 
-- end
-- else
-- set @Mensaje= 'No se puede repetir el documento de un mismo cliente'
-- end
-- go

-- CREATE proc SP_EDITARCLIENTE(
-- @IdCliente int,
-- @Documento varchar(50),
-- @NombreCompleto varchar(50),
-- @Correo varchar(50),
-- @Telefono varchar(50),
-- @Estado bit,
-- @Resultado int output,
-- @Mensaje varchar(500) output
-- )

--as
--begin

--set @Resultado =1
--set @Mensaje=''
--declare @IDPERSONA INT

--if not exists (select*from CLIENTE where Documento = @Documento and IdCliente != @IdCliente)
--begin

-- update CLIENTE set
-- Documento = @Documento,
-- NombreCompleto = @NombreCompleto,
-- Correo = @Correo,
-- Telefono= @Telefono,
-- Estado = @Estado
-- where IdCliente = @IdCliente
-- end
-- else
-- begin
-- set @Resultado = 0
-- set @Mensaje= 'No se puede repetir el documento para mas de cliente'
-- end
-- end
-- go

-- CREATE PROC SP_ELIMINARCLIENTE(
--@IdCliente varchar(50),
--@Resultado bit output,
--@Mensaje varchar(500) output
--) as
--begin
--    set @Resultado = 1
--	  if not exists (
--	  select*from CLIENTE c
--	  where c.IdCliente =@IdCliente
--	  )
--	  begin
--	    delete top(1) from CLIENTE where @IdCliente= @IdCliente
--		end
--	  else
--	  begin
--	      set @Resultado=0
--		  set @Mensaje= 'No se puede eliminar'
--	  end
--end

--go

-- create proc SP_REGISTRARPROVEEDOR(
-- @Documento varchar(50),
-- @RazonSocial varchar(50),
-- @Correo varchar(50),
-- @Telefono varchar(50),
-- @Estado bit,
-- @Resultado int output,
-- @Mensaje varchar(500) output
-- )
--as
--begin

--set @Resultado =0
--set @Mensaje=''
--declare @IDPERSONA INT

--if not exists (select*from PROVEEDOR where Documento = @Documento)
--begin

-- insert into PROVEEDOR(Documento,RazonSocial,Correo,Telefono,Estado)
-- values(@Documento,@RazonSocial,@Correo,@Telefono,@Estado)

-- set @Resultado = SCOPE_IDENTITY()
 
-- end
-- else
-- set @Mensaje= 'No se puede repetir el documento de un mismo proveedor'
-- end
-- go

--  CREATE proc SP_EDITARPROVEEDOR(
-- @IdProveedor int,
-- @Documento varchar(50),
-- @RazonSocial varchar(50),
-- @Correo varchar(50),
-- @Telefono varchar(50),
-- @Estado bit,
-- @Resultado int output,
-- @Mensaje varchar(500) output
-- )
--as
--begin
--set @Resultado =1
--set @Mensaje=''
--declare @IDPERSONA INT

--if not exists (select*from PROVEEDOR where Documento = @Documento and IdProveedor != @IdProveedor)
--begin

-- update PROVEEDOR set
-- Documento = @Documento,
-- RazonSocial = @RazonSocial,
-- Correo = @Correo,
-- Telefono= @Telefono,
-- Estado = @Estado
-- where IdProveedor = @IdProveedor
-- end
-- else
-- begin
-- set @Resultado = 0
-- set @Mensaje= 'No se puede repetir el documento para mas de cliente'
-- end
-- end
-- go

--  CREATE PROC SP_ELIMINARPROVEEDOR(
--@IdProveedor int,
--@Resultado bit output,
--@Mensaje varchar(500) output
--) as
--begin
--    set @Resultado = 1
--	  if not exists (
--	  select*from PROVEEDOR p
--	  inner join COMPRA c on p.IdProveedor=c.IdCompra
--	  where p.IdProveedor =@IdProveedor
--	  )
--	  begin
--	    delete top(1) from PROVEEDOR where IdProveedor= @IdProveedor
--		end
--	  else
--	  begin
--	      set @Resultado=0
--		  set @Mensaje= 'No se puede eliminar porque el proveedor esta relacionadoa una compra'
--	  end
--end

--go


/* Procesos para registrar una compra */

create table #TEMPORALDETALLECOM(IDPROD INT,PRECIOCOM DECIMAL(18,2),PRECIOVENT DECIMAL(18,2),CANT DECIMAL(18,2),TOTAL DECIMAL(18,2))
INSERT INTO #TEMPORALDETALLECOM (IDPROD,PRECIOCOM,PRECIOVENT,CANT,TOTAL)
SELECT IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal from DETALLE_COMPRA

create type [dbo].[EDETALLE_COMPRA] as table(
[IdProducto] int null,
[PrecioCompra] DECIMAL(18,2) null,
[PrecioVenta] DECIMAL(18,2) null,
[Cantidad] DECIMAL(18,2)null,
[MontoTotal] DECIMAL(18,2) null
)
go




create or alter procedure SP_REGISTRAR_COMPRA(
@IdUsuario int,
@IdProveedor int,
@TipoDocumento varchar (500),
@NumeroDocumento varchar (500),
@MontoTotal DECIMAL(18,2),
@DetalleCompra [EDETALLE_COMPRA] readonly,
@Resultado bit output,
@Mensaje varchar(500) output

)

as
begin

begin try

declare @idcompra int = 0
set @Resultado =1 
set @Mensaje =''

begin transaction registro

insert into COMPRA (IdUsurio,IdProveedor,TipoDocumento,NumeroDocumento,MontoTotal)
values(@IdUsuario,@IdProveedor,@TipoDocumento,@NumeroDocumento,@MontoTotal)

set @idcompra = SCOPE_IDENTITY()

insert into DETALLE_COMPRA(IdCompra,IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal)
select @idcompra, IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal from @DetalleCompra

update p set p.Stock= p.Stock + dc.Cantidad,
p.PrecioCompra = dc.PrecioCompra,
p.PrecioVenta =dc.PrecioVenta
from PRODUCTO p
inner join @DetalleCompra dc on dc.IdProducto=p.IdProducto

--este commit es para registrar lo insertado por la compra cuando no hay errores(permanente)
commit transaction registro

end try

begin catch
set @Resultado = 0
set @Mensaje = ERROR_MESSAGE()
--este rollback es para regresar lo insertado si en caso hay errores en las transacciones de "registro" o insertar la data de compra
rollback transaction registro

end catch

end

select count(*) +1 from COMPRA

select c.IdCompra,u.NombreCompleto,pr.Documento,pr.RazonSocial,c.TipoDocumento,c.NumeroDocumento,
c.MontoTotal,convert(char(10), c.FechaRegistro,103)[FechaRegistro] from COMPRA c
inner join USUARIO u on u.IdUsuario=c.IdUsurio
inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor
where c.NumeroDocumento='00000001'

select p.Nombre,dc.PrecioCompra,dc.Cantidad,dc.MontoTotal from DETALLE_COMPRA dc
inner join producto p on p.IdProducto= dc.IdProducto
where dc.IdCompra=1

create type [dbo].[EDETALLE_VENTA] as table(
[IdProducto] int null,
[PrecioVenta] DECIMAL(18,2) null,
[Cantidad] DECIMAL(18,2)null,
[SubTotal] DECIMAL(18,2) null
)
go

select*from [dbo].[EDETALLE_VENTA]

create or alter procedure SP_REGISTRAR_VENTA(
@IdUsuario int,
@TipoDocumento varchar (500),
@NumeroDocumento varchar (500),
@DocumentoCliente varchar (500),
@NombreCliente varchar (500),
@MontoPago DECIMAL(18,2),
@MontoCambio DECIMAL(18,2),
@MontoTotal DECIMAL(18,2),
@DetalleVenta [EDETALLE_VENTA] readonly,
@Resultado bit output,
@Mensaje varchar(500) output

)

as
begin

begin try

declare @idventa int = 0
set @Resultado =1 
set @Mensaje =''

begin transaction registro

insert into VENTA(IdUsurio,TipoDocumento,NumeroDocumento,DocumentoCliente,NombreCliente,MontoPago,MontoCambio,MontoTotal)
values(@IdUsuario,@TipoDocumento,@NumeroDocumento,@DocumentoCliente,@NombreCliente,@MontoPago,@MontoCambio,@MontoTotal)

set @idventa = SCOPE_IDENTITY()

insert into DETALLE_VENTA(IdVenta,IdProducto,PrecioVenta,Cantidad,SubTotal)
select @idventa, IdProducto,PrecioVenta,Cantidad,SubTotal from @DetalleVenta

update p set p.Stock= p.Stock - dv.Cantidad
from PRODUCTO p
inner join @DetalleVenta dv on dv.IdProducto=p.IdProducto

--este commit es para registrar lo insertado por la compra cuando no hay errores(permanente)
commit transaction registro

end try

begin catch
set @Resultado = 0
set @Mensaje = ERROR_MESSAGE()
--este rollback es para regresar lo insertado si en caso hay errores en las transacciones de "registro" o insertar la data de compra
rollback transaction registro

end catch

end

select count(*) +1 from VENTA

select v.IdVenta,u.NombreCompleto,v.TipoDocumento,v.NumeroDocumento,v.DocumentoCliente,v.NombreCliente, v.MontoPago,v.MontoCambio,
v.MontoTotal,convert(char(10), v.FechaRegistro,103)[FechaRegistro] from VENTA v
inner join USUARIO u on u.IdUsuario=v.IdUsurio
where v.NumeroDocumento='00000001'

select p.Nombre,dv.PrecioVenta,dv.Cantidad,dv.SubTotal from DETALLE_VENTA dv
inner join producto p on p.IdProducto= dv.IdProducto
where dv.IdVenta=1

select*from DETALLE_VENTA

select*from CLIENTE

update producto set stock = stock - @cantidad where idproducto = @idproducto


select CONVERT(char(10),c.FechaRegistro,103)[FechaRegistro],c.TipoDocumento,c.NumeroDocumento,c.MontoTotal,
u.NombreCompleto[UsuarioRegistro],pro.Documento[DocumentoProveedor],pro.RazonSocial,
p.Codigo[CodigoProducto], p.Nombre[NombreProducto],ca.Descripcion[Categoria],dc.PrecioCompra,dc.PrecioVenta,dc.Cantidad,dc.MontoTotal[Subtotal]
from COMPRA c
inner join USUARIO u on u.IdUsuario= c.IdUsurio
inner join PROVEEDOR pro on pro.IdProveedor=c.IdProveedor
inner join DETALLE_COMPRA dc on dc.IdCompra= c.IdCompra
inner join PRODUCTO p on p.IdProducto = dc.IdProducto
inner join CATEGORIA ca on ca.IdCategoria =p.IdCategoria
where CONVERT(date,c.FechaRegistro) between '2022/10/27' and '2022/11/02'
and pro.IdProveedor=1

create or alter procedure SP_REPORTE_COMPRAS(
@Fechainicio varchar(10),
@Fechafin varchar(10),
@IdProveedor int
)
as
begin

set dateformat dmy;

select CONVERT(char(10),c.FechaRegistro,103)[FechaRegistro],c.TipoDocumento,c.NumeroDocumento,c.MontoTotal,
u.NombreCompleto[UsuarioRegistro],pro.Documento[DocumentoProveedor],pro.RazonSocial,
p.Codigo[CodigoProducto], p.Nombre[NombreProducto],ca.Descripcion[Categoria],dc.PrecioCompra,dc.PrecioVenta,dc.Cantidad,dc.MontoTotal[Subtotal]
from COMPRA c
inner join USUARIO u on u.IdUsuario= c.IdUsurio
inner join PROVEEDOR pro on pro.IdProveedor=c.IdProveedor
inner join DETALLE_COMPRA dc on dc.IdCompra= c.IdCompra
inner join PRODUCTO p on p.IdProducto = dc.IdProducto
inner join CATEGORIA ca on ca.IdCategoria =p.IdCategoria
where CONVERT(date,c.FechaRegistro) between @Fechainicio and @fechafin
and pro.IdProveedor= IIF(@IdProveedor=0,pro.IdProveedor,@IdProveedor)

end


create or alter procedure SP_REPORTE_VENTAS(
@Fechainicio varchar(10),
@Fechafin varchar(10)
)
as
begin

set dateformat dmy;

select CONVERT(char(10),v.FechaRegistro,103)[FechaRegistro],v.TipoDocumento,v.NumeroDocumento,v.MontoTotal,
u.NombreCompleto[UsuarioRegistro],v.DocumentoCliente,v.NombreCliente,
p.Codigo[CodigoProducto], p.Nombre[NombreProducto],ca.Descripcion[Categoria],dv.PrecioVenta,dv.Cantidad,dv.SubTotal 
from VENTA v
inner join USUARIO u on u.IdUsuario= v.IdUsurio
inner join DETALLE_VENTA dv on dv.IdVenta= v.IdVenta
inner join PRODUCTO p on p.IdProducto = dv.IdProducto
inner join CATEGORIA ca on ca.IdCategoria =p.IdCategoria
where CONVERT(date,v.FechaRegistro) between @Fechainicio and @fechafin

end

--PROCEDMIENTO PARA OBTENER ROLES
CREATE or alter PROC SP_OBTENER_ROLES
as
begin
 select IdRol, Descripcion,FechaRegistro from ROL
end



go

select*from ROL

--PROCEDIMIENTO PARA GUARDAR ROL
create or alter procedure  SP_REGISTRAR_ROL(
@Descripcion varchar(100),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
) as
begin
    set @Resultado =0
	if not exists (select*from ROL where Descripcion = @Descripcion)
	begin
	    insert into ROL(Descripcion,Estado) values(@Descripcion,@Estado)
		set @Resultado = SCOPE_IDENTITY()
		end
		else
		set @Mensaje= 'No se puede repetir la misma categoría'
		end

go


exec SP_REGISTRAR_ROL 'COMPRAS','1'

SELECT*FROM rol

--PROCEDIMIENTO PARA MODIFICAR ROLES
create or alter procedure SP_MODIFICAR_ROL(
@IdRol int,
@Descripcion varchar(100),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
) as
begin
    set @Resultado = 1
	  if not exists (select*from ROL where Descripcion = @Descripcion and IdRol != @IdRol)
	  update ROL set
	  Descripcion = @Descripcion,Estado=@Estado
	  where IdRol=@IdRol
	  else
	  begin
	      set @Resultado=0
		  set @Mensaje= 'No se puede repetir la misma rol'
	  end

end

go

--PROCEDIMIENTO PARA ELIMINAR ROL
create or alter procedure SP_ELIMINAR_ROL(
@IdRol int,
@Resultado bit output,
@Mensaje varchar(500) output
) as
begin
    set @Resultado = 1
	  if not exists (
	  select*from ROL C
	  inner join USUARIO U ON u.IdRol = c.IdRol
	  where c.IdRol =@IdRol
	  )
	  begin
	    delete top(1) from ROL where IdRol= @IdRol
		end
	  else
	  begin
	      set @Resultado=0
		  set @Mensaje= 'No se puede eliminar la rol seleccionada porque se encuentra relacionada a un usuario'
	  end
end
go

create procedure SP_OBTENER_PERMISOS(
@IdRol int)
as
begin
select p.IdPermisos,m.Nombre[Menu],sm.Nombre[SubMenu],p.Activo from PERMISOS p
inner join SUBMENU sm on sm.IdSubMenu = p.IdSubMenu
inner join MENU m on m.IdMenu = sm.IdMenu
where p.IdRol = @IdRol
end

go

--PROCEDIMIENTO PARA ACTUALIZAR PERMISOS
create procedure SP_ACTUALIZARPERMISOS(
@Detalle xml,
@Resultado bit output
)
as
begin
begin try

	BEGIN TRANSACTION
	declare @permisos table(idpermisos int,activo bit)

	insert into @permisos(idpermisos,activo)
	select 
	idpermisos = Node.Data.value('(IdPermisos)[1]','int'),
	activo = Node.Data.value('(Activo)[1]','bit')
	FROM @Detalle.nodes('/DETALLE/PERMISO') Node(Data)

	select * from @permisos

	update p set p.Activo = pe.activo from PERMISOS p
	inner join @permisos pe on pe.idpermisos = p.IdPermisos

	COMMIT
	set @Resultado = 1

end try
begin catch
	ROLLBACK
	set @Resultado = 0
end catch
end

go

select*from PERMISO 

select*from PERMISOS



