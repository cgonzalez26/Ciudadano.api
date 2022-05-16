/****** Script para el comando SelectTopNRows de SSMS  ******/
SELECT TOP (1000) [Id]
      ,[InsertedAt]
      ,[InsertedBy]
      ,[UpdatedAt]
      ,[UpdatedBy]
      ,[DeletedAt]
      ,[DeletedBy]
      ,[IsDeleted]
      ,[Nombre]
      ,[Descripcion]
  FROM [Ciudadano].[dbo].[Roles]

  insert into dbo.Roles(id, IsDeleted,Nombre,Descripcion)
  values('COD_CONTRIBUYENTE',0,'Contribuyente','Contribuyente')

  insert into dbo.Permisos(id, IsDeleted,Nombre,Descripcion,Orden)
  values
  ('PAGES_MANAGEMENT_IMPUESTOS_AUT_PRINT',0,'Administraci�n > Impuestos Automotor > Imprimir','Administraci�n > Impuestos Automotor > Imprimir',601),
  ('PAGES_MANAGEMENT_IMPUESTOS_INM_PRINT',0,'Administraci�n > Impuestos Inmobiliario > Imprimir','Administraci�n > Impuestos Inmobiliario > Imprimir',701),
  ('PAGES_MANAGEMENT_IMPUESTOS_TSG_PRINT',0,'Administraci�n > Impuestos Tsg > Imprimir','Administraci�n > Impuestos Tsg > Imprimir',801)

  insert into dbo.RolPermisos(id, IsDeleted,RolId,PermisoId)
  values('ID_SC_PH',0,'COD_CONTRIBUYENTE','PAGES_HOME'),
  ('ID_SC_PM_IA',0,'COD_CONTRIBUYENTE','PAGES_MANAGEMENT_IMPUESTOS_AUT'),
  ('ID_SC_PM_II',0,'COD_CONTRIBUYENTE','PAGES_MANAGEMENT_IMPUESTOS_INM'),
  ('ID_SC_PM_ITSG',0,'COD_CONTRIBUYENTE','PAGES_MANAGEMENT_IMPUESTOS_TSG'),
  ('ID_SC_PM_IA_P',0,'COD_CONTRIBUYENTE','PAGES_MANAGEMENT_IMPUESTOS_AUT_PRINT'),
  ('ID_SC_PM_II_P',0,'COD_CONTRIBUYENTE','PAGES_MANAGEMENT_IMPUESTOS_INM_PRINT'),
  ('ID_SC_PM_ITSG_P',0,'COD_CONTRIBUYENTE','PAGES_MANAGEMENT_IMPUESTOS_TSG_PRINT')

use Ciudadano
select * from [dbo].[Usuarios]
select * from dbo.Titulares
update [dbo].[Usuarios] set RolId='COD_CONTRIBUYENTE' where id='764A6040-08D7-4061-9A11-526AA33F3CE0'
update [dbo].[Usuarios] set sNroDocumento='28105434' where id='02F76D3D-CC14-4FBD-BF93-9B91737A762A'

insert into dbo.Titulares(id,IsDeleted,sNroDocumento,sNombre,sApellido,sDomicilio,sTelefono,sMail)
values('100',0,'111','aaa','aaa','aaa','1111111','a@a.a'),
('101',0,'222','bbb','bbb','bbb','2222222','b@b.c'),
('102',0,'333','ccc','ccc','ccc','3333333','c@c.c'),
('103',0,'444','ddd','ddd','ddd','4444444','d@d.d'),
('104',0,'555','eee','eee','eee','5555555','e@e.e'),
('105',0,'28105434','Cristian','Gonzalez','Mza 13, Casa 16, Grupo 648 Casta�ares','154572626','crisgonzalez26@gmail.com')
