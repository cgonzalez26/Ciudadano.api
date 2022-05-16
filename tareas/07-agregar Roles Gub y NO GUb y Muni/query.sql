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
      ,[PadreId]
      ,[Geometria]
      ,[FullId]
      ,[TipoZonaId]
  FROM [OranDB].[dbo].[Zonas]
  use Ciudadano
  select * from dbo.Roles
  --insert into dbo.Roles(Id,IsDeleted,Nombre,Descripcion)
  --values('COD_EMPL_MUNICIPAL',0,'Empleado Municipal','Empleado Municipal'),
  --('COD_ORG_GUB',0,'Organismo Gubernamental','Organismo Gubernamental'),
  --('COD_ORG_NOGUB',0,'Organismo No Gubernamental','Organismo No Gubernamental'),
  --('COD_AUTORIDAD_MUNICIPAL',0,'Autoridad Municipal','Autoridad Municipal')

  select * from dbo.Inmuebles
  select * from dbo.Titulares
  select * from dbo.InmueblesTitulares
  select * from dbo.Impuesto_Tsg as tsg
  left join dbo.Inmuebles as i on i.Id = tsg.InmuebleId
  left join dbo.InmueblesTitulares as it on it.InmuebleId = i.Id
  left join dbo.Titulares as t on t.Id = it.TitularId
  where 

  --update dbo.Impuesto_Tsg set dFecha_Pago=null,nPago=0 where id='B5C6DAC7-3FED-4BD2-BBF1-2BAB587FE9B8'
  --insert into dbo.InmueblesTitulares(Id,IsDeleted,InmuebleId,TitularId)
  --values(newid(),0,'33333','102'),
  --(newid(),0,'55555','103')

  select * from dbo.Zonas
  --insert into dbo.Zonas(Id,IsDeleted,Nombre,PadreId,FullId)
  --values('66040',0,'Oran','66','66.60040'),
  --('66040_ID_CENTRO',0,'CENTRO','66040','66.60040.ID_CENTRO'),
  --('66040_ID_ESTE',0,'ESTE','66040','66.60040.ID_ESTE'),
  --('66040_ID_NORTE',0,'NORTE','66040','66.60040.ID_NORTE'),
  --('66040_ID_OESTE',0,'OESTE','66040','66.60040.ID_OESTE'),
  --('66040_ID_SUR',0,'SUR','66040','66.60040.ID_SUR')


