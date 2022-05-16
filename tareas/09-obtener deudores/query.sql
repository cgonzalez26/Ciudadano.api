use Ciudadano
go

--TItulares con sus Deudas
select z.Id as ZonaId,z.Nombre as Zona,t.TitularId,ti.sNroDocumento,ti.sApellido,ti.sNombre,ti.sDomicilio,sum(t.nSaldo) as nSaldo
from (
	select vt.TitularId,sum(nSaldo) as nSaldo
	  FROM [Ciudadano].[dbo].[Impuesto_Aut] as iaut
	  left join dbo.VehiculosTitulares as vt on vt.VehiculoId = iaut.VehiculoId
	where iaut.nSaldo <>0
	group by iaut.VehiculoId,vt.TitularId
	union
	select it.TitularId,sum(nSaldo) as nSaldo
	  FROM [Ciudadano].[dbo].[Impuesto_Inm] as iinm
	  left join dbo.InmueblesTitulares as it on it.InmuebleId = iinm.InmuebleId
	where iinm.nSaldo <>0
	group by iinm.InmuebleId,it.TitularId
	union
	select it.TitularId,sum(nSaldo) as nSaldo
	  FROM [Ciudadano].[dbo].[Impuesto_Tsg] as itsg
	left join dbo.InmueblesTitulares as it on it.InmuebleId = itsg.InmuebleId
	where itsg.nSaldo <>0
	group by itsg.InmuebleId,it.TitularId
) as t
left join dbo.Titulares as ti on ti.id = t.TitularId
left join dbo.Zonas as z on z.id = ti.ZonaId
group by z.Id,z.Nombre,t.TitularId,ti.sNroDocumento,ti.sApellido,ti.sNombre,ti.sDomicilio

exec getDeudoresByZona @ZonaId = '66040_ID_NORTE' --'ID_ALL'

create procedure getDeudoresByZona(
	@ZonaId VARCHAR(64) = null
)
AS
BEGIN
	select z.Id as ZonaId,z.Nombre as Zona,t.TitularId,ti.sNroDocumento,ti.sApellido,ti.sNombre,ti.sDomicilio,sum(t.nSaldo) as nSaldo
	from (
		select vt.TitularId,sum(nSaldo) as nSaldo
		  FROM [Ciudadano].[dbo].[Impuesto_Aut] as iaut
		  left join dbo.VehiculosTitulares as vt on vt.VehiculoId = iaut.VehiculoId
		  left join dbo.Titulares as ti on ti.id = vt.TitularId
		where iaut.nSaldo <>0 AND (ti.ZonaId = @ZonaId OR @ZonaId = 'ID_ALL')
		group by iaut.VehiculoId,vt.TitularId
		union
		select it.TitularId,sum(nSaldo) as nSaldo
		  FROM [Ciudadano].[dbo].[Impuesto_Inm] as iinm
		  left join dbo.InmueblesTitulares as it on it.InmuebleId = iinm.InmuebleId
		  left join dbo.Titulares as ti on ti.id = it.TitularId
		where iinm.nSaldo <>0 AND (ti.ZonaId = @ZonaId OR @ZonaId = 'ID_ALL')
		group by iinm.InmuebleId,it.TitularId
		union
		select it.TitularId,sum(nSaldo) as nSaldo
		  FROM [Ciudadano].[dbo].[Impuesto_Tsg] as itsg
		left join dbo.InmueblesTitulares as it on it.InmuebleId = itsg.InmuebleId
		left join dbo.Titulares as ti on ti.id = it.TitularId
		where itsg.nSaldo <>0 AND (ti.ZonaId = @ZonaId OR @ZonaId = 'ID_ALL')
		group by itsg.InmuebleId,it.TitularId
	) as t
	left join dbo.Titulares as ti on ti.id = t.TitularId
	left join dbo.Zonas as z on z.id = ti.ZonaId
	group by z.Id,z.Nombre,t.TitularId,ti.sNroDocumento,ti.sApellido,ti.sNombre,ti.sDomicilio
	
END


