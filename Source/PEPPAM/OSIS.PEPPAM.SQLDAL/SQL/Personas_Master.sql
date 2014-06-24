-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Master_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Master_Congregacion]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Master_Congregacion]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Master_PersonasTipoCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Master_PersonasTipoCata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Master_PersonaEstadoCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Master_PersonaEstadoCata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Master_PersonaTipoSecuencia]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Master_PersonaTipoSecuencia]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Master_PersonaCorreo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Master_PersonaCorreo]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Personas_Master_Editar]
(
	@Congregacion_Secuencia  [Int] ,
	@Persona_Apellidos  [VarChar]  (50),
	@Persona_Clave  [VarChar]  (50),
	@Persona_Congregacion  [VarChar]  (50) = 'N/E',
	@Persona_Conyuge_Apellido  [VarChar]  (50),
	@Persona_Correo  [VarChar]  (50),
	@Persona_Estado_Secuencia  [Int]  = 0,
	@Persona_Nombres  [VarChar]  (50),
	@Persona_Sexo  [NChar]  (1),
	@Persona_Tipo_Secuencia  [Int]  = 1,
	@Persona_Verificacion_Numero  [VarChar]  (50),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Persona_Secuencia  [Int] 

)

AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
UPDATE 
	[dbo].[Personas_Master] 
SET
	[Congregacion_Secuencia] = @Congregacion_Secuencia,
	[Persona_Apellidos] = @Persona_Apellidos,
	[Persona_Clave] = @Persona_Clave,
	[Persona_Congregacion] = @Persona_Congregacion,
	[Persona_Conyuge_Apellido] = @Persona_Conyuge_Apellido,
	[Persona_Correo] = @Persona_Correo,
	[Persona_Estado_Secuencia] = @Persona_Estado_Secuencia,
	[Persona_Nombres] = @Persona_Nombres,
	[Persona_Sexo] = @Persona_Sexo,
	[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia,
	[Persona_Verificacion_Numero] = @Persona_Verificacion_Numero,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Personas_Master].[Persona_Secuencia] = @Persona_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Personas_Master]
(
	[Congregacion_Secuencia],
	[Persona_Apellidos],
	[Persona_Clave],
	[Persona_Congregacion],
	[Persona_Conyuge_Apellido],
	[Persona_Correo],
	[Persona_Estado_Secuencia],
	[Persona_Nombres],
	[Persona_Sexo],
	[Persona_Tipo_Secuencia],
	[Persona_Verificacion_Numero],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Congregacion_Secuencia,
	@Persona_Apellidos,
	@Persona_Clave,
	@Persona_Congregacion,
	@Persona_Conyuge_Apellido,
	@Persona_Correo,
	@Persona_Estado_Secuencia,
	@Persona_Nombres,
	@Persona_Sexo,
	@Persona_Tipo_Secuencia,
	@Persona_Verificacion_Numero,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Persona_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Persona_Secuencia AS 'Persona_Secuencia' 
        FROM [Personas_Master]
        WHERE ([Personas_Master].[Persona_Secuencia] = @Persona_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Personas_Master_Borrar]
(
	@Persona_Secuencia  [Int] 

)

AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END

    UPDATE [Persona_Contactos_Trans] SET
     [Persona_Contactos_Trans].[Persona_Secuencia] = NULL
    WHERE     ([Persona_Contactos_Trans].[Persona_Secuencia] = @Persona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Personas_Notificaciones_Trans] SET
     [Personas_Notificaciones_Trans].[Persona_Secuencia] = NULL
    WHERE     ([Personas_Notificaciones_Trans].[Persona_Secuencia] = @Persona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Personas_Turnos_Trans] SET
     [Personas_Turnos_Trans].[Persona_Secuencia] = NULL
    WHERE     ([Personas_Turnos_Trans].[Persona_Secuencia] = @Persona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Rutas_Master] SET
     [Rutas_Master].[Ruta_Persona_Encargado] = NULL
    WHERE     ([Rutas_Master].[Ruta_Persona_Encargado] = @Persona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Rutas_Master] SET
     [Rutas_Master].[Ruta_Persona_Auxiliar] = NULL
    WHERE     ([Rutas_Master].[Ruta_Persona_Auxiliar] = @Persona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Zonas_Encargados_Trans] SET
     [Zonas_Encargados_Trans].[Persona_Secuencia] = NULL
    WHERE     ([Zonas_Encargados_Trans].[Persona_Secuencia] = @Persona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Personas_Tipos_Trans] SET
     [Personas_Tipos_Trans].[Persona_Secuencia] = NULL
    WHERE     ([Personas_Tipos_Trans].[Persona_Secuencia] = @Persona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Persona_Roles_Trans] SET
     [Persona_Roles_Trans].[Persona_Secuencia] = NULL
    WHERE     ([Persona_Roles_Trans].[Persona_Secuencia] = @Persona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Notificaciones_Personas_Trans] SET
     [Notificaciones_Personas_Trans].[Persona_Secuencia] = NULL
    WHERE     ([Notificaciones_Personas_Trans].[Persona_Secuencia] = @Persona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Personas_Diponibilidad] SET
     [Personas_Diponibilidad].[Persona_Secuencia] = NULL
    WHERE     ([Personas_Diponibilidad].[Persona_Secuencia] = @Persona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Horario_Turno_Informe_Trans] SET
     [Horario_Turno_Informe_Trans].[Persona_Secuencia] = NULL
    WHERE     ([Horario_Turno_Informe_Trans].[Persona_Secuencia] = @Persona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Personas_Master]
    WHERE 
      ([Personas_Master].[Persona_Secuencia] = @Persona_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Master]
(
	@Persona_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Personas_Master].[Persona_Secuencia],
                [Personas_Master].[Congregacion_Secuencia],
                [Personas_Master].[Persona_Congregacion],
                [Personas_Master].[Persona_Tipo_Secuencia],
                [Personas_Master].[Persona_Nombres],
                [Personas_Master].[Persona_Apellidos],
                [Personas_Master].[Persona_Conyuge_Apellido],
                [Personas_Master].[Persona_Sexo],
                [Personas_Master].[Persona_Correo],
                [Personas_Master].[Persona_Clave],
                [Personas_Master].[Persona_Verificacion_Numero],
                [Personas_Master].[Persona_Estado_Secuencia],
                [Personas_Master].[Registro_Estado],
                [Personas_Master].[Registro_Fecha],
                [Personas_Master].[Registro_Usuario]
    FROM [Personas_Master]
    WHERE 
     ( [Personas_Master].[Persona_Secuencia] = @Persona_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Personas_Master].[Persona_Secuencia],
                [Personas_Master].[Congregacion_Secuencia],
                [Personas_Master].[Persona_Congregacion],
                [Personas_Master].[Persona_Tipo_Secuencia],
                [Personas_Master].[Persona_Nombres],
                [Personas_Master].[Persona_Apellidos],
                [Personas_Master].[Persona_Conyuge_Apellido],
                [Personas_Master].[Persona_Sexo],
                [Personas_Master].[Persona_Correo],
                [Personas_Master].[Persona_Clave],
                [Personas_Master].[Persona_Verificacion_Numero],
                [Personas_Master].[Persona_Estado_Secuencia],
                [Personas_Master].[Registro_Estado],
                [Personas_Master].[Registro_Fecha],
                [Personas_Master].[Registro_Usuario]
    FROM [Personas_Master]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Master_Congregacion]
(
	@Congregacion_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Master].[Persona_Secuencia],
                [Personas_Master].[Congregacion_Secuencia],
                [Personas_Master].[Persona_Congregacion],
                [Personas_Master].[Persona_Tipo_Secuencia],
                [Personas_Master].[Persona_Nombres],
                [Personas_Master].[Persona_Apellidos],
                [Personas_Master].[Persona_Conyuge_Apellido],
                [Personas_Master].[Persona_Sexo],
                [Personas_Master].[Persona_Correo],
                [Personas_Master].[Persona_Clave],
                [Personas_Master].[Persona_Verificacion_Numero],
                [Personas_Master].[Persona_Estado_Secuencia],
                [Personas_Master].[Registro_Estado],
                [Personas_Master].[Registro_Fecha],
                [Personas_Master].[Registro_Usuario]
    FROM [Personas_Master]
      WHERE
        ([Personas_Master].[Congregacion_Secuencia] = @Congregacion_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Master_PersonasTipoCata]
(
	@Persona_Tipo_Secuencia  [Int]  = 1,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Master].[Persona_Secuencia],
                [Personas_Master].[Congregacion_Secuencia],
                [Personas_Master].[Persona_Congregacion],
                [Personas_Master].[Persona_Tipo_Secuencia],
                [Personas_Master].[Persona_Nombres],
                [Personas_Master].[Persona_Apellidos],
                [Personas_Master].[Persona_Conyuge_Apellido],
                [Personas_Master].[Persona_Sexo],
                [Personas_Master].[Persona_Correo],
                [Personas_Master].[Persona_Clave],
                [Personas_Master].[Persona_Verificacion_Numero],
                [Personas_Master].[Persona_Estado_Secuencia],
                [Personas_Master].[Registro_Estado],
                [Personas_Master].[Registro_Fecha],
                [Personas_Master].[Registro_Usuario]
    FROM [Personas_Master]
      WHERE
        ([Personas_Master].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Master_PersonaEstadoCata]
(
	@Persona_Estado_Secuencia  [Int]  = 0,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Master].[Persona_Secuencia],
                [Personas_Master].[Congregacion_Secuencia],
                [Personas_Master].[Persona_Congregacion],
                [Personas_Master].[Persona_Tipo_Secuencia],
                [Personas_Master].[Persona_Nombres],
                [Personas_Master].[Persona_Apellidos],
                [Personas_Master].[Persona_Conyuge_Apellido],
                [Personas_Master].[Persona_Sexo],
                [Personas_Master].[Persona_Correo],
                [Personas_Master].[Persona_Clave],
                [Personas_Master].[Persona_Verificacion_Numero],
                [Personas_Master].[Persona_Estado_Secuencia],
                [Personas_Master].[Registro_Estado],
                [Personas_Master].[Registro_Fecha],
                [Personas_Master].[Registro_Usuario]
    FROM [Personas_Master]
      WHERE
        ([Personas_Master].[Persona_Estado_Secuencia] = @Persona_Estado_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Master_PersonaTipoSecuencia]
(
	@Persona_Tipo_Secuencia  [Int]  = 1
,
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
          [Personas_Master].[Persona_Secuencia],
          [Personas_Master].[Congregacion_Secuencia],
          [Personas_Master].[Persona_Congregacion],
          [Personas_Master].[Persona_Tipo_Secuencia],
          [Personas_Master].[Persona_Nombres],
          [Personas_Master].[Persona_Apellidos],
          [Personas_Master].[Persona_Conyuge_Apellido],
          [Personas_Master].[Persona_Sexo],
          [Personas_Master].[Persona_Correo],
          [Personas_Master].[Persona_Clave],
          [Personas_Master].[Persona_Verificacion_Numero],
          [Personas_Master].[Persona_Estado_Secuencia],
          [Personas_Master].[Registro_Estado],
          [Personas_Master].[Registro_Fecha],
          [Personas_Master].[Registro_Usuario]
    FROM [Personas_Master]
      WHERE
        ([Personas_Master].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia)

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Master_PersonaCorreo]
(
	@Persona_Correo  [VarChar]  (50)
,
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
          [Personas_Master].[Persona_Secuencia],
          [Personas_Master].[Congregacion_Secuencia],
          [Personas_Master].[Persona_Congregacion],
          [Personas_Master].[Persona_Tipo_Secuencia],
          [Personas_Master].[Persona_Nombres],
          [Personas_Master].[Persona_Apellidos],
          [Personas_Master].[Persona_Conyuge_Apellido],
          [Personas_Master].[Persona_Sexo],
          [Personas_Master].[Persona_Correo],
          [Personas_Master].[Persona_Clave],
          [Personas_Master].[Persona_Verificacion_Numero],
          [Personas_Master].[Persona_Estado_Secuencia],
          [Personas_Master].[Registro_Estado],
          [Personas_Master].[Registro_Fecha],
          [Personas_Master].[Registro_Usuario]
    FROM [Personas_Master]
      WHERE
        ([Personas_Master].[Persona_Correo] = @Persona_Correo)

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Personas_Master_Paging]

	@PageIndex 		int,
	@PageSize  		int,
	@SearchString 	varchar (50) = NULL,
    @_orderBy0 [nvarchar] (120) = NULL,
    @_orderByDirection0 [bit] = 0
AS

SET NOCOUNT ON;

DECLARE @StartIndex INT, @EndIndex INT

SET   @PageIndex = @PageIndex - 1
SET   @StartIndex = (@PageIndex * @PageSize) + 1
SET   @EndIndex = @StartIndex + @PageSize - 1



;WITH PagingTable AS
(
		SELECT  
				ROW_NUMBER() OVER ( ORDER BY 		                [pm].[Persona_Secuencia]
 ) AS [RowNumber],
				   pm.Persona_Secuencia , 
				   pm.Congregacion_Secuencia , 
				   pm.Persona_Congregacion , 
				   pm.Persona_Tipo_Secuencia , 
				   pm.Persona_Nombres , 
				   pm.Persona_Apellidos , 
				   pm.Persona_Conyuge_Apellido , 
				   pm.Persona_Sexo , 
				   pm.Persona_Correo , 
				   pm.Persona_Clave , 
				   pm.Persona_Verificacion_Numero , 
				   pm.Persona_Estado_Secuencia , 
				   pm.Registro_Estado , 
				   pm.Registro_Fecha , 
				   pm.Registro_Usuario
		FROM  [dbo].[Personas_Master]	As pm	
			 Inner Join Congregaciones_Master As cm
			   On  cm.Congregacion_Secuencia = pm.Congregacion_Secuencia
			 Inner Join Personas_Tipo_Cata As ptc
			   On  ptc.Persona_Tipo_Secuencia = pm.Persona_Tipo_Secuencia
			 Inner Join Persona_Estado_Cata As pec
			   On  pec.Persona_Estado_Secuencia = pm.Persona_Estado_Secuencia

		   WHERE pm.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(pm.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm.Congregacion_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Congregacion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm.Persona_Tipo_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Nombres LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Apellidos LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Conyuge_Apellido LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Sexo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Correo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Clave LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Verificacion_Numero LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm.Persona_Estado_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Secuencia]' AND @_orderByDirection0 = 0 THEN [Congregacion_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Secuencia]' AND @_orderByDirection0 = 1 THEN [Congregacion_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Congregacion]' AND @_orderByDirection0 = 0 THEN [Persona_Congregacion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Congregacion]' AND @_orderByDirection0 = 1 THEN [Persona_Congregacion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Tipo_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Tipo_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Nombres]' AND @_orderByDirection0 = 0 THEN [Persona_Nombres]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Nombres]' AND @_orderByDirection0 = 1 THEN [Persona_Nombres]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Apellidos]' AND @_orderByDirection0 = 0 THEN [Persona_Apellidos]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Apellidos]' AND @_orderByDirection0 = 1 THEN [Persona_Apellidos]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Conyuge_Apellido]' AND @_orderByDirection0 = 0 THEN [Persona_Conyuge_Apellido]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Conyuge_Apellido]' AND @_orderByDirection0 = 1 THEN [Persona_Conyuge_Apellido]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Sexo]' AND @_orderByDirection0 = 0 THEN [Persona_Sexo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Sexo]' AND @_orderByDirection0 = 1 THEN [Persona_Sexo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Correo]' AND @_orderByDirection0 = 0 THEN [Persona_Correo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Correo]' AND @_orderByDirection0 = 1 THEN [Persona_Correo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Clave]' AND @_orderByDirection0 = 0 THEN [Persona_Clave]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Clave]' AND @_orderByDirection0 = 1 THEN [Persona_Clave]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Verificacion_Numero]' AND @_orderByDirection0 = 0 THEN [Persona_Verificacion_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Verificacion_Numero]' AND @_orderByDirection0 = 1 THEN [Persona_Verificacion_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Estado_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Estado_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Estado]' AND @_orderByDirection0 = 0 THEN [Registro_Estado]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Estado]' AND @_orderByDirection0 = 1 THEN [Registro_Estado]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Fecha]' AND @_orderByDirection0 = 0 THEN [Registro_Fecha]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Fecha]' AND @_orderByDirection0 = 1 THEN [Registro_Fecha]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Usuario]' AND @_orderByDirection0 = 0 THEN [Registro_Usuario]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Usuario]' AND @_orderByDirection0 = 1 THEN [Registro_Usuario]
      END DESC
GO



CREATE PROCEDURE [dbo].[Proc_Personas_Descripciones]

	@Persona_Secuencia  [Int]  = -999 , 
	@Congregacion_Secuencia  [Int]  = -999 , 
	@Zona_Secuencia  [Int]  = -999 , 
	@PageIndex 		int,
	@PageSize  		int,
	@SearchString 	varchar (50) = NULL , 
    @_orderBy0 [nvarchar] (120) = NULL,
    @_orderByDirection0 [bit] = 0,
    @_orderBy1 [nvarchar] (120) = NULL,
    @_orderByDirection1 [bit] = 0
AS

SET NOCOUNT ON;

DECLARE @StartIndex INT, @EndIndex INT, @RowCount int

SET   @RowCount = ISNULL((@PageIndex * 1000), 1000)
SET   @PageIndex = @PageIndex - 1
SET   @StartIndex = (@PageIndex * @PageSize) + 1
SET   @EndIndex = @StartIndex + @PageSize - 1



;WITH PagingTable AS
(
		SELECT  
				   Persona_Secuencia,
				   Congregacion_Secuencia,
				   Persona_Congregacion,
				   Persona_Tipo_Secuencia,
				   Persona_Nombres,
				   Persona_Apellidos,
				   Persona_Conyuge_Apellido,
				   Persona_Sexo,
				   Persona_Correo,
				   Persona_Clave,
				   Persona_Verificacion_Numero,
				   Persona_Estado_Secuencia,
				   Registro_Estado,
				   Registro_Fecha,
				   Registro_Usuario,
				   Congregacion_Nombre,
				   Congregacion_Direccion,
				   Persona_Tipo_Descripcion,
				   Persona_Estado_Descripcion,
				   Persona_Estado_Explicacion,
				   Zona_Descripcion,
				ROW_NUMBER() OVER ( ORDER BY  ) AS [RowNumber]
From (
		SELECT  Distinct Top (@RowCount)
				   pm1.Persona_Secuencia Persona_Secuencia , 
				   pm1.Congregacion_Secuencia Congregacion_Secuencia , 
				   pm1.Persona_Congregacion Persona_Congregacion , 
				   pm1.Persona_Tipo_Secuencia Persona_Tipo_Secuencia , 
				   pm1.Persona_Nombres Persona_Nombres , 
				   pm1.Persona_Apellidos Persona_Apellidos , 
				   pm1.Persona_Conyuge_Apellido Persona_Conyuge_Apellido , 
				   pm1.Persona_Sexo Persona_Sexo , 
				   pm1.Persona_Correo Persona_Correo , 
				   pm1.Persona_Clave Persona_Clave , 
				   pm1.Persona_Verificacion_Numero Persona_Verificacion_Numero , 
				   pm1.Persona_Estado_Secuencia Persona_Estado_Secuencia , 
				   pm1.Registro_Estado Registro_Estado , 
				   pm1.Registro_Fecha Registro_Fecha , 
				   pm1.Registro_Usuario Registro_Usuario , 
				   cm1.Congregacion_Nombre Congregacion_Nombre , 
				   cm1.Congregacion_Direccion Congregacion_Direccion , 
				   ptc1.Persona_Tipo_Descripcion Persona_Tipo_Descripcion , 
				   pec1.Persona_Estado_Descripcion Persona_Estado_Descripcion , 
				   pec1.Persona_Estado_Explicacion Persona_Estado_Explicacion , 
				   zm.Zona_Descripcion Zona_Descripcion
		FROM  [dbo].[Personas_Master]	As pm1	
		 Inner Join   [Congregaciones_Master]	As cm1	
		    On  cm1.Congregacion_Secuencia =	pm1.Congregacion_Secuencia
		 Inner Join   [Personas_Tipo_Cata]	As ptc1	
		    On  ptc1.Persona_Tipo_Secuencia =	pm1.Persona_Tipo_Secuencia
		 Inner Join   [Persona_Estado_Cata]	As pec1	
		    On  pec1.Persona_Estado_Secuencia =	pm1.Persona_Estado_Secuencia
		   WHERE pm1.Registro_Estado = 'A' 			    And  
				   (@Persona_Secuencia = -999 OR pm1.Persona_Secuencia = @Persona_Secuencia )				    And 
				   (@Congregacion_Secuencia = -999 OR pm1.Congregacion_Secuencia = @Congregacion_Secuencia )				    And 
				   (@Zona_Secuencia = -999 OR zm.Zona_Secuencia = @Zona_Secuencia )
			    And ( 
				   (@SearchString Is Null OR LTRIM(pm1.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm1.Congregacion_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Persona_Congregacion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm1.Persona_Tipo_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Persona_Nombres LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Persona_Apellidos LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Persona_Conyuge_Apellido LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Persona_Sexo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Persona_Correo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Persona_Clave LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Persona_Verificacion_Numero LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm1.Persona_Estado_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm1.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Registro_Usuario LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR cm1.Congregacion_Nombre LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR cm1.Congregacion_Direccion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ptc1.Persona_Tipo_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pec1.Persona_Estado_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pec1.Persona_Estado_Explicacion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR zm.Zona_Descripcion LIKE '%' + @SearchString + '%'))
		
			) As X
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Secuencia]' AND @_orderByDirection1 = 0 THEN [Persona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Secuencia]' AND @_orderByDirection1 = 1 THEN [Persona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Secuencia]' AND @_orderByDirection0 = 0 THEN [Congregacion_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Secuencia]' AND @_orderByDirection0 = 1 THEN [Congregacion_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Congregacion_Secuencia]' AND @_orderByDirection1 = 0 THEN [Congregacion_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Congregacion_Secuencia]' AND @_orderByDirection1 = 1 THEN [Congregacion_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Congregacion]' AND @_orderByDirection0 = 0 THEN [Persona_Congregacion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Congregacion]' AND @_orderByDirection0 = 1 THEN [Persona_Congregacion]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Congregacion]' AND @_orderByDirection1 = 0 THEN [Persona_Congregacion]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Congregacion]' AND @_orderByDirection1 = 1 THEN [Persona_Congregacion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Tipo_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Tipo_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection1 = 0 THEN [Persona_Tipo_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection1 = 1 THEN [Persona_Tipo_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Nombres]' AND @_orderByDirection0 = 0 THEN [Persona_Nombres]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Nombres]' AND @_orderByDirection0 = 1 THEN [Persona_Nombres]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Nombres]' AND @_orderByDirection1 = 0 THEN [Persona_Nombres]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Nombres]' AND @_orderByDirection1 = 1 THEN [Persona_Nombres]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Apellidos]' AND @_orderByDirection0 = 0 THEN [Persona_Apellidos]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Apellidos]' AND @_orderByDirection0 = 1 THEN [Persona_Apellidos]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Apellidos]' AND @_orderByDirection1 = 0 THEN [Persona_Apellidos]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Apellidos]' AND @_orderByDirection1 = 1 THEN [Persona_Apellidos]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Conyuge_Apellido]' AND @_orderByDirection0 = 0 THEN [Persona_Conyuge_Apellido]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Conyuge_Apellido]' AND @_orderByDirection0 = 1 THEN [Persona_Conyuge_Apellido]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Conyuge_Apellido]' AND @_orderByDirection1 = 0 THEN [Persona_Conyuge_Apellido]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Conyuge_Apellido]' AND @_orderByDirection1 = 1 THEN [Persona_Conyuge_Apellido]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Sexo]' AND @_orderByDirection0 = 0 THEN [Persona_Sexo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Sexo]' AND @_orderByDirection0 = 1 THEN [Persona_Sexo]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Sexo]' AND @_orderByDirection1 = 0 THEN [Persona_Sexo]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Sexo]' AND @_orderByDirection1 = 1 THEN [Persona_Sexo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Correo]' AND @_orderByDirection0 = 0 THEN [Persona_Correo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Correo]' AND @_orderByDirection0 = 1 THEN [Persona_Correo]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Correo]' AND @_orderByDirection1 = 0 THEN [Persona_Correo]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Correo]' AND @_orderByDirection1 = 1 THEN [Persona_Correo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Clave]' AND @_orderByDirection0 = 0 THEN [Persona_Clave]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Clave]' AND @_orderByDirection0 = 1 THEN [Persona_Clave]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Clave]' AND @_orderByDirection1 = 0 THEN [Persona_Clave]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Clave]' AND @_orderByDirection1 = 1 THEN [Persona_Clave]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Verificacion_Numero]' AND @_orderByDirection0 = 0 THEN [Persona_Verificacion_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Verificacion_Numero]' AND @_orderByDirection0 = 1 THEN [Persona_Verificacion_Numero]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Verificacion_Numero]' AND @_orderByDirection1 = 0 THEN [Persona_Verificacion_Numero]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Verificacion_Numero]' AND @_orderByDirection1 = 1 THEN [Persona_Verificacion_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Estado_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Estado_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Estado_Secuencia]' AND @_orderByDirection1 = 0 THEN [Persona_Estado_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Estado_Secuencia]' AND @_orderByDirection1 = 1 THEN [Persona_Estado_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Estado]' AND @_orderByDirection0 = 0 THEN [Registro_Estado]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Estado]' AND @_orderByDirection0 = 1 THEN [Registro_Estado]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Registro_Estado]' AND @_orderByDirection1 = 0 THEN [Registro_Estado]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Registro_Estado]' AND @_orderByDirection1 = 1 THEN [Registro_Estado]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Fecha]' AND @_orderByDirection0 = 0 THEN [Registro_Fecha]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Fecha]' AND @_orderByDirection0 = 1 THEN [Registro_Fecha]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Registro_Fecha]' AND @_orderByDirection1 = 0 THEN [Registro_Fecha]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Registro_Fecha]' AND @_orderByDirection1 = 1 THEN [Registro_Fecha]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Usuario]' AND @_orderByDirection0 = 0 THEN [Registro_Usuario]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Usuario]' AND @_orderByDirection0 = 1 THEN [Registro_Usuario]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Registro_Usuario]' AND @_orderByDirection1 = 0 THEN [Registro_Usuario]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Registro_Usuario]' AND @_orderByDirection1 = 1 THEN [Registro_Usuario]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Nombre]' AND @_orderByDirection0 = 0 THEN [Congregacion_Nombre]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Nombre]' AND @_orderByDirection0 = 1 THEN [Congregacion_Nombre]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Congregacion_Nombre]' AND @_orderByDirection1 = 0 THEN [Congregacion_Nombre]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Congregacion_Nombre]' AND @_orderByDirection1 = 1 THEN [Congregacion_Nombre]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Direccion]' AND @_orderByDirection0 = 0 THEN [Congregacion_Direccion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Direccion]' AND @_orderByDirection0 = 1 THEN [Congregacion_Direccion]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Congregacion_Direccion]' AND @_orderByDirection1 = 0 THEN [Congregacion_Direccion]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Congregacion_Direccion]' AND @_orderByDirection1 = 1 THEN [Congregacion_Direccion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Descripcion]' AND @_orderByDirection0 = 0 THEN [Persona_Tipo_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Descripcion]' AND @_orderByDirection0 = 1 THEN [Persona_Tipo_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Tipo_Descripcion]' AND @_orderByDirection1 = 0 THEN [Persona_Tipo_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Tipo_Descripcion]' AND @_orderByDirection1 = 1 THEN [Persona_Tipo_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Descripcion]' AND @_orderByDirection0 = 0 THEN [Persona_Estado_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Descripcion]' AND @_orderByDirection0 = 1 THEN [Persona_Estado_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Estado_Descripcion]' AND @_orderByDirection1 = 0 THEN [Persona_Estado_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Estado_Descripcion]' AND @_orderByDirection1 = 1 THEN [Persona_Estado_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Explicacion]' AND @_orderByDirection0 = 0 THEN [Persona_Estado_Explicacion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Explicacion]' AND @_orderByDirection0 = 1 THEN [Persona_Estado_Explicacion]
      END DESC,
      CASE
          WHEN @_orderBy1 = '[Persona_Estado_Explicacion]' AND @_orderByDirection1 = 0 THEN [Persona_Estado_Explicacion]
      END ASC,
      CASE
          WHEN @_orderBy1 = '[Persona_Estado_Explicacion]' AND @_orderByDirection1 = 1 THEN [Persona_Estado_Explicacion]
      END DESC
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Turnos]

	@Persona_Secuencia  [Int]  , 
	@PageIndex 		int,
	@PageSize  		int,
	@SearchString 	varchar (50) = NULL , 
    @_orderBy0 [nvarchar] (120) = NULL,
    @_orderByDirection0 [bit] = 0
AS

SET NOCOUNT ON;

DECLARE @StartIndex INT, @EndIndex INT, @RowCount int

SET   @RowCount = ISNULL((@PageIndex * 1000), 1000)
SET   @PageIndex = @PageIndex - 1
SET   @StartIndex = (@PageIndex * @PageSize) + 1
SET   @EndIndex = @StartIndex + @PageSize - 1



;WITH PagingTable AS
(
		SELECT  
				   Persona_Secuencia,
				   Horario_Turno_Secuencia,
				   Dia_Secuencia,
				   Persona_Turno_HC,
				   Registro_Estado,
				   Registro_Fecha,
				   Registro_Usuario,
				   Persona_Tipo_Secuencia,
				   Persona_Nombres,
				   Persona_Apellidos,
				   Persona_Sexo,
				   Turno_Fecha,
				   Turno_Estado,
				   Turno_Razon_Inactivo,
				   Dia_Descripcion,
				   Dia_Orden,
				   Turno_Descripcion,
				   Turno_Hora_Desde,
				   Turno_Hora_Hasta,
				   Turno_Minutos_Cantidad,
				   Horario_Secuencia,
				   Ruta_Secuencia,
				   Semana_Codigo,
				   Horario_Fecha_Desde,
				   Horario_Fecha_Hasta,
				   Horario_Publicar,
				   Zona_Secuencia,
				   Ruta_Descripcion,
				   Zona_Descripcion,
				   Congregacion_Nombre,
				ROW_NUMBER() OVER ( ORDER BY  ) AS [RowNumber]
From (
		SELECT  Distinct Top (@RowCount)
				   ptt.Persona_Secuencia Persona_Secuencia , 
				   ptt.Horario_Turno_Secuencia Horario_Turno_Secuencia , 
				   ptt.Dia_Secuencia Dia_Secuencia , 
				   ptt.Persona_Turno_HC Persona_Turno_HC , 
				   ptt.Registro_Estado Registro_Estado , 
				   ptt.Registro_Fecha Registro_Fecha , 
				   ptt.Registro_Usuario Registro_Usuario , 
				   pm.Persona_Tipo_Secuencia Persona_Tipo_Secuencia , 
				   pm.Persona_Nombres Persona_Nombres , 
				   pm.Persona_Apellidos Persona_Apellidos , 
				   pm.Persona_Sexo Persona_Sexo , 
				   htdt.Turno_Fecha Turno_Fecha , 
				   htdt.Turno_Estado Turno_Estado , 
				   htdt.Turno_Razon_Inactivo Turno_Razon_Inactivo , 
				   dc.Dia_Descripcion Dia_Descripcion , 
				   dc.Dia_Orden Dia_Orden , 
				   htt.Turno_Descripcion Turno_Descripcion , 
				   htt.Turno_Hora_Desde Turno_Hora_Desde , 
				   htt.Turno_Hora_Hasta Turno_Hora_Hasta , 
				   htt.Turno_Minutos_Cantidad Turno_Minutos_Cantidad , 
				   ht.Horario_Secuencia Horario_Secuencia , 
				   ht.Ruta_Secuencia Ruta_Secuencia , 
				   ht.Semana_Codigo Semana_Codigo , 
				   ht.Horario_Fecha_Desde Horario_Fecha_Desde , 
				   ht.Horario_Fecha_Hasta Horario_Fecha_Hasta , 
				   ht.Horario_Publicar Horario_Publicar , 
				   rm1.Zona_Secuencia Zona_Secuencia , 
				   rm1.Ruta_Descripcion Ruta_Descripcion , 
				   zm.Zona_Descripcion Zona_Descripcion , 
				   cm.Congregacion_Nombre Congregacion_Nombre
		FROM  [dbo].[Personas_Turnos_Trans]	As ptt	
		 Inner Join   [Personas_Master]	As pm	
		    On  pm.Persona_Secuencia =	ptt.Persona_Secuencia
		 Inner Join   [Horario_Turno_Dias_Trans]	As htdt	
		    On  htdt.Horario_Turno_Secuencia =	ptt.Horario_Turno_Secuencia
 htdt.Dia_Secuencia =	ptt.Dia_Secuencia
		 Inner Join   [Dias_Cata]	As dc	
		    On  dc.Dia_Secuencia =	htdt.Dia_Secuencia
		 Inner Join   [Horario_Turno_Trans]	As htt	
		    On  htt.Horario_Turno_Secuencia =	htdt.Horario_Turno_Secuencia
		 Inner Join   [Horario_Trans]	As ht	
		    On  ht.Horario_Secuencia =	htt.Horario_Secuencia
		 Inner Join   [Rutas_Master]	As rm1	
		    On  rm1.Ruta_Secuencia =	ht.Ruta_Secuencia
		 Inner Join   [Congregaciones_Master]	As cm	
		    On  cm.Congregacion_Secuencia =	pm.Congregacion_Secuencia
		   WHERE ptt.Registro_Estado = 'A' 			    And  
				   (@Persona_Secuencia = ptt.Persona_Secuencia)
			    And ( 
				   (@SearchString Is Null OR LTRIM(ptt.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ptt.Horario_Turno_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ptt.Dia_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ptt.Persona_Turno_HC LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ptt.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ptt.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ptt.Registro_Usuario LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm.Persona_Tipo_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Nombres LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Apellidos LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Sexo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htdt.Turno_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htdt.Turno_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htdt.Turno_Razon_Inactivo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR dc.Dia_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(dc.Dia_Orden) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htt.Turno_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htt.Turno_Hora_Desde LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htt.Turno_Hora_Hasta LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htt.Turno_Minutos_Cantidad) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ht.Horario_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ht.Ruta_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ht.Semana_Codigo) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ht.Horario_Fecha_Desde) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ht.Horario_Fecha_Hasta) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ht.Horario_Publicar LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm1.Zona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rm1.Ruta_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR zm.Zona_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR cm.Congregacion_Nombre LIKE '%' + @SearchString + '%'))
		
			) As X
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Turno_Secuencia]' AND @_orderByDirection0 = 0 THEN [Horario_Turno_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Turno_Secuencia]' AND @_orderByDirection0 = 1 THEN [Horario_Turno_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Dia_Secuencia]' AND @_orderByDirection0 = 0 THEN [Dia_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Dia_Secuencia]' AND @_orderByDirection0 = 1 THEN [Dia_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Turno_HC]' AND @_orderByDirection0 = 0 THEN [Persona_Turno_HC]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Turno_HC]' AND @_orderByDirection0 = 1 THEN [Persona_Turno_HC]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Estado]' AND @_orderByDirection0 = 0 THEN [Registro_Estado]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Estado]' AND @_orderByDirection0 = 1 THEN [Registro_Estado]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Fecha]' AND @_orderByDirection0 = 0 THEN [Registro_Fecha]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Fecha]' AND @_orderByDirection0 = 1 THEN [Registro_Fecha]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Usuario]' AND @_orderByDirection0 = 0 THEN [Registro_Usuario]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Usuario]' AND @_orderByDirection0 = 1 THEN [Registro_Usuario]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Tipo_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Tipo_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Nombres]' AND @_orderByDirection0 = 0 THEN [Persona_Nombres]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Nombres]' AND @_orderByDirection0 = 1 THEN [Persona_Nombres]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Apellidos]' AND @_orderByDirection0 = 0 THEN [Persona_Apellidos]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Apellidos]' AND @_orderByDirection0 = 1 THEN [Persona_Apellidos]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Sexo]' AND @_orderByDirection0 = 0 THEN [Persona_Sexo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Sexo]' AND @_orderByDirection0 = 1 THEN [Persona_Sexo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Fecha]' AND @_orderByDirection0 = 0 THEN [Turno_Fecha]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Fecha]' AND @_orderByDirection0 = 1 THEN [Turno_Fecha]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Estado]' AND @_orderByDirection0 = 0 THEN [Turno_Estado]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Estado]' AND @_orderByDirection0 = 1 THEN [Turno_Estado]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Razon_Inactivo]' AND @_orderByDirection0 = 0 THEN [Turno_Razon_Inactivo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Razon_Inactivo]' AND @_orderByDirection0 = 1 THEN [Turno_Razon_Inactivo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Dia_Descripcion]' AND @_orderByDirection0 = 0 THEN [Dia_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Dia_Descripcion]' AND @_orderByDirection0 = 1 THEN [Dia_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Dia_Orden]' AND @_orderByDirection0 = 0 THEN [Dia_Orden]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Dia_Orden]' AND @_orderByDirection0 = 1 THEN [Dia_Orden]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Descripcion]' AND @_orderByDirection0 = 0 THEN [Turno_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Descripcion]' AND @_orderByDirection0 = 1 THEN [Turno_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Hora_Desde]' AND @_orderByDirection0 = 0 THEN [Turno_Hora_Desde]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Hora_Desde]' AND @_orderByDirection0 = 1 THEN [Turno_Hora_Desde]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Hora_Hasta]' AND @_orderByDirection0 = 0 THEN [Turno_Hora_Hasta]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Hora_Hasta]' AND @_orderByDirection0 = 1 THEN [Turno_Hora_Hasta]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Minutos_Cantidad]' AND @_orderByDirection0 = 0 THEN [Turno_Minutos_Cantidad]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Minutos_Cantidad]' AND @_orderByDirection0 = 1 THEN [Turno_Minutos_Cantidad]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Secuencia]' AND @_orderByDirection0 = 0 THEN [Horario_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Secuencia]' AND @_orderByDirection0 = 1 THEN [Horario_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 0 THEN [Ruta_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 1 THEN [Ruta_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Semana_Codigo]' AND @_orderByDirection0 = 0 THEN [Semana_Codigo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Semana_Codigo]' AND @_orderByDirection0 = 1 THEN [Semana_Codigo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Fecha_Desde]' AND @_orderByDirection0 = 0 THEN [Horario_Fecha_Desde]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Fecha_Desde]' AND @_orderByDirection0 = 1 THEN [Horario_Fecha_Desde]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Fecha_Hasta]' AND @_orderByDirection0 = 0 THEN [Horario_Fecha_Hasta]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Fecha_Hasta]' AND @_orderByDirection0 = 1 THEN [Horario_Fecha_Hasta]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Publicar]' AND @_orderByDirection0 = 0 THEN [Horario_Publicar]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Publicar]' AND @_orderByDirection0 = 1 THEN [Horario_Publicar]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Zona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Zona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Zona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Zona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Descripcion]' AND @_orderByDirection0 = 0 THEN [Ruta_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Descripcion]' AND @_orderByDirection0 = 1 THEN [Ruta_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Zona_Descripcion]' AND @_orderByDirection0 = 0 THEN [Zona_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Zona_Descripcion]' AND @_orderByDirection0 = 1 THEN [Zona_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Nombre]' AND @_orderByDirection0 = 0 THEN [Congregacion_Nombre]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Nombre]' AND @_orderByDirection0 = 1 THEN [Congregacion_Nombre]
      END DESC
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Tipo_Consulta]

	@Persona_Tipo_Secuencia  [Int] 
AS

SET NOCOUNT ON;

		SELECT  
				   pm.Persona_Secuencia Persona_Secuencia , 
				   pm.Congregacion_Secuencia Congregacion_Secuencia , 
				   pm.Persona_Congregacion Persona_Congregacion , 
				   pm.Persona_Tipo_Secuencia Persona_Tipo_Secuencia , 
				   pm.Persona_Nombres Persona_Nombres , 
				   pm.Persona_Apellidos Persona_Apellidos , 
				   pm.Persona_Conyuge_Apellido Persona_Conyuge_Apellido , 
				   pm.Persona_Sexo Persona_Sexo , 
				   pm.Persona_Correo Persona_Correo , 
				   pm.Persona_Clave Persona_Clave , 
				   pm.Persona_Verificacion_Numero Persona_Verificacion_Numero , 
				   pm.Persona_Estado_Secuencia Persona_Estado_Secuencia , 
				   pm.Registro_Estado Registro_Estado , 
				   pm.Registro_Fecha Registro_Fecha , 
				   pm.Registro_Usuario Registro_Usuario
		FROM  [dbo].[Personas_Master]	As pm	
		   WHERE pm.Registro_Estado = 'A' 			    And  
				   (@Persona_Tipo_Secuencia = pm.Persona_Tipo_Secuencia)
		
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Role]

	@Role_Numero  [Int] 
AS

SET NOCOUNT ON;

		SELECT  
				   pm.Persona_Secuencia Persona_Secuencia , 
				   pm.Congregacion_Secuencia Congregacion_Secuencia , 
				   pm.Persona_Congregacion Persona_Congregacion , 
				   pm.Persona_Tipo_Secuencia Persona_Tipo_Secuencia , 
				   pm.Persona_Nombres Persona_Nombres , 
				   pm.Persona_Apellidos Persona_Apellidos , 
				   pm.Persona_Conyuge_Apellido Persona_Conyuge_Apellido , 
				   pm.Persona_Sexo Persona_Sexo , 
				   pm.Persona_Correo Persona_Correo , 
				   pm.Persona_Clave Persona_Clave , 
				   pm.Persona_Verificacion_Numero Persona_Verificacion_Numero , 
				   pm.Persona_Estado_Secuencia Persona_Estado_Secuencia , 
				   pm.Registro_Estado Registro_Estado , 
				   pm.Registro_Fecha Registro_Fecha , 
				   pm.Registro_Usuario Registro_Usuario
		FROM  [dbo].[Personas_Master]	As pm	
		 Inner Join   [Persona_Roles_Trans]	As prt	
		    On  prt.Persona_Secuencia =	pm.Persona_Secuencia
		   WHERE pm.Registro_Estado = 'A' 			    And  
				   (@Role_Numero = prt.Role_Numero)
		
GO
