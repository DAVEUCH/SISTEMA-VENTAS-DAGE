select u.idUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.IdRol,r.Descripcion from USUARIO u
inner join rol r on r.IdRol =u.IdRol

select*from USUARIO

insert into USUARIO(Documento,NombreCompleto,Correo,Clave,IdRol,Estado) values
('0069','Geral Alfaro','geral@gmail.com','123',1,1)

delete from USUARIO where IdUsuario=1002