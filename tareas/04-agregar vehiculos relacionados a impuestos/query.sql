/****** Script para el comando SelectTopNRows de SSMS  ******/
SELECT TOP (1000) [Id]
      ,[InsertedAt]
      ,[InsertedBy]
      ,[UpdatedAt]
      ,[UpdatedBy]
      ,[DeletedAt]
      ,[DeletedBy]
      ,[IsDeleted]
      ,[dFecha_Pago]
      ,[iAnio]
      ,[iPeriodo]
      ,[nMonto_Pagar]
      ,[sDominio]
      ,[nPago]
      ,[nSaldo]
      ,[tObservaciones]
      ,[VehiculoId]
  FROM [Ciudadano].[dbo].[Impuesto_Aut]

  update dbo.Impuesto_Aut set sNroDocumento='' where id='A67E5021-DFAE-4216-A108-A07CD9F614CC'

  select ia.* 
  from dbo.Impuesto_Aut as ia
  inner join dbo.Vehiculos as v on v.id = ia.VehiculoId
  inner join dbo.VehiculosTitulares as vt on vt.VehiculoId = v.Id
  inner join dbo.Titulares as t on t.id = vt.TitularId
  where t.sNroDocumento='28105434'

  select * from dbo.Titulares as t where t.sNroDocumento='28105434'
    select * from dbo.Vehiculos as v 

--insert into dbo.Vehiculos(id,IsDeleted,sDominio,sModelo,sMarca,iAnio,nVal_F_V,sDomicilio,iPIN)
--values(newid(),0,'AAA111','Gol','WV',2020,1000.00,'Alvarado',6),
--(newid(),0,'BBB222','Clio','Renault',2021,2000.00,'Caseros',7),
--(newid(),0,'CCC333','C3','Citroen',2019,2000.00,'Bs As',8),
--(newid(),0,'DDD444','Rav4','Toyota',2010,3000.00,'Catamarca',9),
--(newid(),0,'EEE555','Amarok','WV',2009,4000.00,'Belgrano',10)

insert into dbo.VehiculosTitulares(id,IsDeleted,VehiculoId,TitularId)
values
--(newid(),0,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5','105')
--(newid(),0,'0D70B806-E67F-41CD-827E-9CB12D284988','104')
--(newid(),0,'87DF519E-5BC8-4ECE-A4D3-5E04F96B9CDF','102')

--update dbo.Impuesto_Aut set VehiculoId='FFA77AF2-B9E0-44C2-B013-F395DF785FE5' 
--where id='A67E5021-DFAE-4216-A108-A07CD9F614CC'

--update dbo.Impuesto_Aut set VehiculoId='0D70B806-E67F-41CD-827E-9CB12D284988' 
--where id='39383767-A0C7-432F-B9AA-B41820E12F54'

--update dbo.Impuesto_Aut set VehiculoId='87DF519E-5BC8-4ECE-A4D3-5E04F96B9CDF' 
--where id='DCA575B3-B926-4B84-8968-98A62CA3DCD5'


select * from dbo.Impuesto_Aut
select * from dbo.Impuesto_Inm
select * from dbo.Impuesto_Tsg
select * from dbo.Inmuebles
select * from dbo.InmueblesTitulares
select * from dbo.Usuarios
select * from dbo.RolPermisos
select * from dbo.Titulares
select * from dbo.Vehiculos

--  INSERT INTO Usuarios(Id,InsertedAt,UsuarioNombre,Password,Nombres,Apellidos,FechaNacimiento,Email,IsDeleted,RolId)
--VALUES(newid(),getdate(),'eee',hashbytes('MD5',HashBytes('SHA1', 'eee')),'eee','eee','1985-06-26 00:00:00','e@e.e',0,'COD_CONTRIBUYENTE')

--INSERT INTO Usuarios(Id,InsertedAt,UsuarioNombre,Password,Nombres,Apellidos,FechaNacimiento,Email,IsDeleted,RolId)
--values(newid(),getdate(),'ccc',hashbytes('MD5',HashBytes('SHA1', 'ccc')),'ccc','ccc','1990-05-15 00:00:00','c@c.c',0,'COD_CONTRIBUYENTE')

--insert into dbo.InmueblesTitulares(id,IsDeleted,InmuebleId,TitularId)
--values
--(newid(),0,'11111','105'),
--(newid(),0,'22222','104')
