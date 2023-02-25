select*from USUARIO
select*from COMPRA
select*from PERMISO
select*from ROL
select*from MENU
select*from SUBMENU
DBCC CHECKIDENT (PERMISO, RESEED, 0)

delete from PERMISO where IdPermiso=14

select p.IdRol, p.NombreMenu from PERMISO p
inner join ROL r on r.IdRol = p.IdRol
inner join USUARIO u on u.IdRol = r.IdRol
where u.IdUsuario =5

--insert into PERMISO (IdRol,NombreMenu)values
--(1,'menuUsuario'),
--(1,'menuMantenimiento'),
--(1,'menuVentas'),
--(1,'menuCompras'),
--(1,'menuClientes'),
--(1,'menuProveedores'),
--(1,'menuReportes'),
--(1,'menuAcercade')

--insert into PERMISO (IdRol,NombreMenu)values

--(2,'menuMantenimiento'),
--(2,'menuVentas'),
--(2,'menuCompras'),
--(2,'menuProveedores'),
--(2,'menuReportes')

--insert into MENU(Nombre,Icono,Activo)values
--('menuUsuario','vas',1),
--('menuMantenimiento','vas',1),
--('menuVentas','vas',1),
--('menuCompras','vas',1),
--('menuClientes','vas',1),
--('menuProveedores','vas',1),
--('menuReportes','vas',1),
--('menuAcercade','vas',1)

select IdMenu,Nombre,Activo from MENU


--insert into SUBMENU(Nombre,Icono,Activo)values
--(1,'submenuCrearRol',1),
--('menuMantenimiento','vas',1),
--('menuVentas','vas',1),
--('menuCompras','vas',1),
--('menuClientes','vas',1),
--('menuProveedores','vas',1),
--('menuReportes','vas',1),
--('menuAcercade','vas',1)

--update PERMISO set idMenu=3 where IdPermiso=3
--update PERMISO set idMenu=4 where IdPermiso=4
--update PERMISO set idMenu=5 where IdPermiso=5
--update PERMISO set idMenu=6 where IdPermiso=6
--update PERMISO set idMenu=7 where IdPermiso=7
--update PERMISO set idMenu=8 where IdPermiso=8

--update PERMISO set idMenu=2 where IdPermiso=9
--update PERMISO set idMenu=3 where IdPermiso=10
--update PERMISO set idMenu=4 where IdPermiso=11
--update PERMISO set idMenu=6 where IdPermiso=12
--update PERMISO set idMenu=7 where IdPermiso=13

select IdPermiso,R.IdRol,R.Descripcion[NombreRol],R.Estado,M.IdMenu,M.Nombre[NombreMenu],M.Activo from PERMISO P
inner join ROL R ON P.IdRol=R.IdRol
inner join MENU M ON P.IdMenu=M.IdMenu
where r.IdRol=2

create type [dbo].[EDETALLE_PERMISO] as table(
[IdRol] int null,
[NombreMenu] varchar(100) null,
[IdMenu] int null
)
go

create or alter procedure SP_REGISTRAR_PERMISO(
@IdPermiso int,
@IdRol int,
@NombreMenu varchar(100),
@IdMenu int,
@Resultado int output,
@Mensaje varchar(500) output
)
as
begin

set @Resultado =0
if not exists (select *from PERMISO where IdPermiso=@IdPermiso)

begin

insert into PERMISO(IdRol,NombreMenu,IdMenu) values(@IdRol,@NombreMenu,@IdMenu)

set @Resultado = SCOPE_IDENTITY()
end
else
set @Mensaje= 'No se puede repetir la mismo Rol'
end

EXEC SP_REGISTRAR_PERMISO '16' ,'1010','menuReportes','4','',''

delete PERMISO where IdPermiso=23
delete PERMISO where IdPermiso=30
delete PERMISO where IdPermiso=31
delete PERMISO where IdPermiso=32
delete PERMISO where IdPermiso=33

select*from PERMISO
select*from ROL

create or alter procedure SP_EDITAR_PERMISO(
@IdPermiso int,
@IdRol int,
@NombreMenu varchar(100),
@IdMenu int,
@Resultado int output,
@Mensaje varchar(500) output
)
as
begin
set @Resultado = 1
if  exists (select*from PERMISO where IdPermiso != @IdPermiso)
update PERMISO set
	  IdRol = @IdRol, NombreMenu=@NombreMenu,IdMenu=@IdMenu
	  where IdPermiso=@IdPermiso
else
	  begin
	      set @Resultado=0
		  set @Mensaje= 'Ya existe un permiso con el mismo Id'
	  end

end

EXEC SP_EDITAR_PERMISO '29' ,'1009','menuReportes','7','',''
select*from PERMISO

 CREATE OR ALTER PROC SP_ELIMINAR_PERMISO(
@IdPermiso varchar(50),
@Resultado bit output,
@Mensaje varchar(500) output
) as
begin
    set @Resultado = 1
	  if exists (
	  select*from PERMISO p
	  where p.IdPermiso =@IdPermiso
	  )
	  begin
	    delete top(1) from CLIENTE where @IdPermiso= @IdPermiso
		end
	  else
	  begin
	      set @Resultado=0
		  set @Mensaje= 'No se puede eliminar'
	  end
end


