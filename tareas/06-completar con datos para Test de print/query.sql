select * from dbo.Titulares
select * from [dbo].[Usuarios]

--update [dbo].[Usuarios]
--set sNroDocumento='666', Nombres='Sergio',Apellidos='Nuñez'
--where id='02F76D3D-CC14-4FBD-BF93-9B91737A762A'

--update dbo.Titulares set sNombre='Manuel',sApellido='Rodriguez',sDomicilio='Vidente Lopez 580' 
--where id='100'

--update dbo.Titulares set sNombre='Roberto',sApellido='Lopez',sDomicilio='Vidente Lopez 580' 
--where id='101'

--update dbo.Titulares set sNombre='Angel',sApellido='Figueroa',sDomicilio='Arenales 1500'
--where id='102'

--update dbo.Titulares set sNombre='Natalia',sApellido='Sanchez',sDomicilio='Los Cardones 90' 
--where id='103'

--update dbo.Titulares set sNombre='Mario',sApellido='Diaz',sDomicilio='Los Sauces 198' 
--where id='104'

--update dbo.Titulares set sNombre='Sergio',sApellido='Nuñez',
--sDomicilio='Zuviria 1100',sMail='f@f.f',sNroDocumento='666'
--where id='105'

select vt.TitularId,t.sDomicilio,vt.VehiculoId,v.sDominio,v.sMarca,v.sModelo,t.sNombre,t.sApellido,t.sNroDocumento,ia.*
from Impuesto_Aut as ia
inner join dbo.Vehiculos as v on v.id = ia.VehiculoId
inner join dbo.VehiculosTitulares as vt on vt.VehiculoId = v.Id
inner join dbo.Titulares as t on t.id = vt.TitularId
where v.sDominio='CCC333'
order by iPeriodo asc

insert into dbo.Impuesto_Aut(id,IsDeleted,dFecha_Pago,iAnio,iPeriodo,nMonto_Pagar,sDominio,nPago,nSaldo,VehiculoId)
values
--(newid(),0,'2020-01-09 00:00:00.000',2020,01,500,'CCC333',500,0,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5'),
--(newid(),0,'2020-02-15 00:00:00.000',2020,02,500,'CCC333',500,0,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5'),
--(newid(),0,'2020-03-09 00:00:00.000',2020,03,500,'CCC333',400,100,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5'),
--(newid(),0,'2020-04-10 00:00:00.000',2020,04,500,'CCC333',500,0,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5'),
--(newid(),0,'2020-05-13 00:00:00.000',2020,05,500,'CCC333',500,0,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5'),
--(newid(),0,'2020-06-05 00:00:00.000',2020,06,500,'CCC333',300,200,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5'),
--(newid(),0,'2020-07-20 00:00:00.000',2020,07,500,'CCC333',500,0,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5')
--(newid(),0,'2020-07-20 00:00:00.000',2020,09,500,'CCC333',0,0,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5'),
--(newid(),0,'2020-07-20 00:00:00.000',2020,10,500,'CCC333',0,0,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5'),
--(newid(),0,'2020-07-20 00:00:00.000',2020,11,500,'CCC333',0,0,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5'),
--(newid(),0,'2020-07-20 00:00:00.000',2020,12,500,'CCC333',0,0,'FFA77AF2-B9E0-44C2-B013-F395DF785FE5')

--update  dbo.Impuesto_Aut 
--set iAnio=2020,iPeriodo=8 
--where id='A67E5021-DFAE-4216-A108-A07CD9F614CC'

--update dbo.Impuesto_Aut 
--set isdeleted=1 where id in('428E85B5-93C2-4891-8B79-1BDCA295BA78','3F2ECDAD-554E-49A1-84E0-1D43FEC2A936')

--set dateformat ymd
--update dbo.Impuesto_Aut 
--set dFecha_Pago= null,nSaldo=500
--where id in('E085C2F2-C302-4B62-8EA8-B6ADDB54CD5B','94D3B2E2-3F46-4170-8DCA-5F5817DC361F')

select * from Vehiculos
select * from dbo.Impuesto_Inm
select * from dbo.InmueblesTitulares
select * from dbo.Inmuebles
--update dbo.Impuesto_Inm
--set dFecha_Pago='2020-08-06 00:00:00.0000000',iPeriodo=08,iAnio=2020
--where id='A4A738D8-8DA3-457F-A319-AD6C8EC521FC'

--update dbo.Impuesto_Inm set nPago= 0 where nPago is null

--insert into dbo.Impuesto_Inm(id,IsDeleted,dFecha_Pago,iAnio,iPeriodo,nMonto_Pagar,sCatastro,nPago,nSaldo,InmuebleId)
--values
--(newid(),0,'2020-01-16 00:00:00.000',2020,01,250,'11111',250,0,'11111'),
--(newid(),0,'2020-02-11 00:00:00.000',2020,02,250,'11111',250,0,'11111'),
--(newid(),0,'2020-03-08 00:00:00.000',2020,03,250,'11111',150,100,'11111'),
--(newid(),0,'2020-04-05 00:00:00.000',2020,04,250,'11111',250,0,'11111'),
--(newid(),0,'2020-05-10 00:00:00.000',2020,05,250,'11111',250,0,'11111'),
--(newid(),0,null,2020,06,250,'11111',null,250,'11111'),
--(newid(),0,null,2020,07,250,'11111',null,250,'11111')



