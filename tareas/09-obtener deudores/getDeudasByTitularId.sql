USE [Ciudadano]
GO
/****** Object:  StoredProcedure [dbo].[getDeudasByTitularId]    Script Date: 23/03/2022 13:40:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[getDeudasByTitularId](
	@TitularId VARCHAR(64) = null
)
AS
BEGIN
	select t.iAnio,t.iPeriodo,t.TipoImpuesto,t.Propiedad,t.nSaldo
	from (
		select iaut.iAnio,iaut.iPeriodo,'Impuesto Automotor' as TipoImpuesto,v.sDominio as Propiedad,iaut.nSaldo
		  FROM [Ciudadano].[dbo].[Impuesto_Aut] as iaut
		  left join dbo.VehiculosTitulares as vt on vt.VehiculoId = iaut.VehiculoId
		  left join dbo.Vehiculos as v on v.id = iaut.VehiculoId
		  --left join dbo.Titulares as ti on ti.id = vt.TitularId
		where iaut.nSaldo <>0 AND vt.TitularId = @TitularId
		union
		select iinm.iAnio,iinm.iPeriodo,'Impuesto Inmobiliario' as TipoImpuesto, i.sCatastro as Propiedad,iinm.nSaldo
		  FROM [Ciudadano].[dbo].[Impuesto_Inm] as iinm
		  left join dbo.InmueblesTitulares as it on it.InmuebleId = iinm.InmuebleId
		  left join dbo.Inmuebles as i on i.id = iinm.InmuebleId
		  --left join dbo.Titulares as ti on ti.id = it.TitularId
		where iinm.nSaldo <>0 AND it.TitularId = @TitularId
		union
		select itsg.iAnio,itsg.iPeriodo,'Impuesto Tsg' as TipoImpuesto, i.sCatastro as Propiedad,itsg.nSaldo
		  FROM [Ciudadano].[dbo].[Impuesto_Tsg] as itsg
		left join dbo.InmueblesTitulares as it on it.InmuebleId = itsg.InmuebleId
		left join dbo.Inmuebles as i on i.id = itsg.InmuebleId
		--left join dbo.Titulares as ti on ti.id = it.TitularId
		where itsg.nSaldo <>0 AND it.TitularId = @TitularId
	) as t	
END
