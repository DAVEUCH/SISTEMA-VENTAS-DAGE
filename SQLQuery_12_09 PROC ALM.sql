--select*from USUARIO

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