delete from DIAGNOSTICO
dbcc checkident(DIAGNOSTICO,reseed,0)
SET IDENTITY_INSERT DIAGNOSTICO ON
INSERT INTO DIAGNOSTICO(ID,DESCRIPCION)
SELECT ID_DIAGNOSTICO,[DESC] FROM ConsultorioFantini.dbo.DIAGNOSTICOS
SET IDENTITY_INSERT DIAGNOSTICO OFF
--select  * from Diagnostico

delete from LOCALIDAD
dbcc checkident(LOCALIDAD,reseed,0)
SET IDENTITY_INSERT LOCALIDAD ON
INSERT INTO LOCALIDAD(ID,DESCRIPCION)
SELECT ID_LOCALIDAD,[DESC] FROM ConsultorioFantini.dbo.LOCALIDADES
SET IDENTITY_INSERT LOCALIDAD OFF
--select  * from LOCALIDAD


delete from MEDICO
dbcc checkident(MEDICO,reseed,0)
SET IDENTITY_INSERT MEDICO ON
INSERT INTO MEDICO(ID,APEYNOM,TieneAgenda)
SELECT ID_MEDICO,[DESC],0 FROM ConsultorioFantini.dbo.MEDICOS
SET IDENTITY_INSERT MEDICO OFF
--select  * from MEDICO


delete from MUTUAL
dbcc checkident(MUTUAL,reseed,0)
SET IDENTITY_INSERT MUTUAL ON
INSERT INTO MUTUAL(ID,DESCA,DESCC,CODIGO)
SELECT ID_MUTUAL,[DESCA],[DESCC],CODIGO FROM ConsultorioFantini.dbo.MUTUALES
SET IDENTITY_INSERT MUTUAL OFF
--select  * from MUTUAL

delete from TIPODOCUMENTO
dbcc checkident(TIPODOCUMENTO,reseed,0)
SET IDENTITY_INSERT TIPODOCUMENTO ON
INSERT INTO TIPODOCUMENTO(ID,DESCA,DESCC)
SELECT ID_TIPO_DOC,[DESCA],[DESCC] FROM ConsultorioFantini.dbo.TIPOS_DE_DOCUMENTOS
SET IDENTITY_INSERT TIPODOCUMENTO OFF
--select  * from TIPODOCUMENTO




delete from PACIENTE
dbcc checkident(PACIENTE,reseed,0)
SET IDENTITY_INSERT PACIENTE ON
INSERT INTO PACIENTE(ID,IdTipoDocumento,IdProfesion,IdLocalidad,IdMedico,ApeyNom,NroDocumento,Sexo,Calle,Nro,Piso,Depto,TelFijo,TelCelular,Email,Fnac,NroHC,Observaciones,Historia)
SELECT 
		 ID_PACIENTE,
		 ID_TIPO_DOC,
		 NULL,
		 ISNULL((SELECT ID FROM LOCALIDAD WHERE ID=A.Id_Localidad),NULL),
		 ISNULL((SELECT ID FROM MEDICO WHERE ID=A.Id_MEdico),NULL),
		 APELLIDO+','+NOMBRE,
		 NRO_DOC,
		 SEXO,
		 Calle,
		 Nro,
		 Piso,
		 Depto,
		 TEL_FIJO,
		 TEL_CELULAR,
		 null,
		 Fnac,
		 Hc,
		 Obs,
		cast(cast(HISTORIA as varbinary(max)) as varchar(max))

FROM
	 ConsultorioFantini.dbo.PACIENTES A
SET IDENTITY_INSERT PACIENTE OFF
--select  * from PACIENTE where apeynom like '%dick%' where idlocalidad=1


delete from Usuario
dbcc checkident(Usuario,reseed,0)

--INSERT INTO Usuario(ApeyNom,[User],[Password],Rol)
--VALUES('Gutierrez Dick, Emanuel','emanuelgdick@gmail.com','manolo','Admin')

--select  * from TIPODOCUMENTO
