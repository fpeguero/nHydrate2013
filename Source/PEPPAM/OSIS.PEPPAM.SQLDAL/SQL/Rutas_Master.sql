-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Rutas_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Rutas_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Rutas_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Rutas_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Rutas_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Rutas_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Rutas_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Rutas_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Rutas_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Rutas_Master_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Rutas_Master_PersonasMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Rutas_Master_PersonasMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Rutas_Master_PersonasMasterRutaPersonaAuxiliar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Rutas_Master_PersonasMasterRutaPersonaAuxiliar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Rutas_Master_ZonasMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Rutas_Master_ZonasMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Rutas_Master_LoadPersona]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Rutas_Master_LoadPersona]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Rutas_Master_LoadZona]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Rutas_Master_LoadZona]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Rutas_Master_LoadEncargadoAuxiliar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Rutas_Master_LoadEncargadoAuxiliar]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Rutas_Master_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Ruta_Carros_Cantidad  [Int] ,
	@Ruta_Descripcion  [VarChar]  (150),
	@Ruta_Mapa_Url  [VarChar]  (50) = null,
	@Ruta_Persona_Auxiliar  [Int] ,
	@Ruta_Persona_Encargado  [Int] ,
	@Ruta_Publicadores_Cantidad  [Int] ,
	@Zona_Secuencia  [Int] ,
	@Ruta_Secuencia  [Int] 

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
	[dbo].[Rutas_Master] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Ruta_Carros_Cantidad] = @Ruta_Carros_Cantidad,
	[Ruta_Descripcion] = @Ruta_Descripcion,
	[Ruta_Mapa_Url] = @Ruta_Mapa_Url,
	[Ruta_Persona_Auxiliar] = @Ruta_Persona_Auxiliar,
	[Ruta_Persona_Encargado] = @Ruta_Persona_Encargado,
	[Ruta_Publicadores_Cantidad] = @Ruta_Publicadores_Cantidad,
	[Zona_Secuencia] = @Zona_Secuencia

WHERE
	[dbo].[Rutas_Master].[Ruta_Secuencia] = @Ruta_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Rutas_Master]
(
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Ruta_Carros_Cantidad],
	[Ruta_Descripcion],
	[Ruta_Mapa_Url],
	[Ruta_Persona_Auxiliar],
	[Ruta_Persona_Encargado],
	[Ruta_Publicadores_Cantidad],
	[Zona_Secuencia]
)
VALUES
(
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Ruta_Carros_Cantidad,
	@Ruta_Descripcion,
	@Ruta_Mapa_Url,
	@Ruta_Persona_Auxiliar,
	@Ruta_Persona_Encargado,
	@Ruta_Publicadores_Cantidad,
	@Zona_Secuencia
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Ruta_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Ruta_Secuencia AS 'Ruta_Secuencia' 
        FROM [Rutas_Master]
        WHERE ([Rutas_Master].[Ruta_Secuencia] = @Ruta_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Rutas_Master_Borrar]
(
	@Ruta_Secuencia  [Int] 

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

    UPDATE [Horarios_Master] SET
     [Horarios_Master].[Ruta_Secuencia] = NULL
    WHERE     ([Horarios_Master].[Ruta_Secuencia] = @Ruta_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Horario_Trans] SET
     [Horario_Trans].[Ruta_Secuencia] = NULL
    WHERE     ([Horario_Trans].[Ruta_Secuencia] = @Ruta_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Notificaciones_Objetivo_Trans] SET
     [Notificaciones_Objetivo_Trans].[Ruta_Secuencia] = NULL
    WHERE     ([Notificaciones_Objetivo_Trans].[Ruta_Secuencia] = @Ruta_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Documentos_Objetivos_Trans] SET
     [Documentos_Objetivos_Trans].[Ruta_Secuencia] = NULL
    WHERE     ([Documentos_Objetivos_Trans].[Ruta_Secuencia] = @Ruta_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Rutas_Master]
    WHERE 
      ([Rutas_Master].[Ruta_Secuencia] = @Ruta_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Rutas_Master]
(
	@Ruta_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Rutas_Master].[Ruta_Secuencia],
                [Rutas_Master].[Zona_Secuencia],
                [Rutas_Master].[Ruta_Descripcion],
                [Rutas_Master].[Ruta_Persona_Encargado],
                [Rutas_Master].[Ruta_Persona_Auxiliar],
                [Rutas_Master].[Ruta_Mapa_Url],
                [Rutas_Master].[Ruta_Carros_Cantidad],
                [Rutas_Master].[Ruta_Publicadores_Cantidad],
                [Rutas_Master].[Registro_Estado],
                [Rutas_Master].[Registro_Fecha],
                [Rutas_Master].[Registro_Usuario]
    FROM [Rutas_Master]
    WHERE 
     ( [Rutas_Master].[Ruta_Secuencia] = @Ruta_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Rutas_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Rutas_Master].[Ruta_Secuencia],
                [Rutas_Master].[Zona_Secuencia],
                [Rutas_Master].[Ruta_Descripcion],
                [Rutas_Master].[Ruta_Persona_Encargado],
                [Rutas_Master].[Ruta_Persona_Auxiliar],
                [Rutas_Master].[Ruta_Mapa_Url],
                [Rutas_Master].[Ruta_Carros_Cantidad],
                [Rutas_Master].[Ruta_Publicadores_Cantidad],
                [Rutas_Master].[Registro_Estado],
                [Rutas_Master].[Registro_Fecha],
                [Rutas_Master].[Registro_Usuario]
    FROM [Rutas_Master]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Rutas_Master_PersonasMaster]
(
	@Ruta_Persona_Encargado  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Rutas_Master].[Ruta_Secuencia],
                [Rutas_Master].[Zona_Secuencia],
                [Rutas_Master].[Ruta_Descripcion],
                [Rutas_Master].[Ruta_Persona_Encargado],
                [Rutas_Master].[Ruta_Persona_Auxiliar],
                [Rutas_Master].[Ruta_Mapa_Url],
                [Rutas_Master].[Ruta_Carros_Cantidad],
                [Rutas_Master].[Ruta_Publicadores_Cantidad],
                [Rutas_Master].[Registro_Estado],
                [Rutas_Master].[Registro_Fecha],
                [Rutas_Master].[Registro_Usuario]
    FROM [Rutas_Master]
      WHERE
        ([Rutas_Master].[Ruta_Persona_Encargado] = @Ruta_Persona_Encargado)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Rutas_Master_PersonasMasterRutaPersonaAuxiliar]
(
	@Ruta_Persona_Auxiliar  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Rutas_Master].[Ruta_Secuencia],
                [Rutas_Master].[Zona_Secuencia],
                [Rutas_Master].[Ruta_Descripcion],
                [Rutas_Master].[Ruta_Persona_Encargado],
                [Rutas_Master].[Ruta_Persona_Auxiliar],
                [Rutas_Master].[Ruta_Mapa_Url],
                [Rutas_Master].[Ruta_Carros_Cantidad],
                [Rutas_Master].[Ruta_Publicadores_Cantidad],
                [Rutas_Master].[Registro_Estado],
                [Rutas_Master].[Registro_Fecha],
                [Rutas_Master].[Registro_Usuario]
    FROM [Rutas_Master]
      WHERE
        ([Rutas_Master].[Ruta_Persona_Auxiliar] = @Ruta_Persona_Auxiliar)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Rutas_Master_ZonasMaster]
(
	@Zona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Rutas_Master].[Ruta_Secuencia],
                [Rutas_Master].[Zona_Secuencia],
                [Rutas_Master].[Ruta_Descripcion],
                [Rutas_Master].[Ruta_Persona_Encargado],
                [Rutas_Master].[Ruta_Persona_Auxiliar],
                [Rutas_Master].[Ruta_Mapa_Url],
                [Rutas_Master].[Ruta_Carros_Cantidad],
                [Rutas_Master].[Ruta_Publicadores_Cantidad],
                [Rutas_Master].[Registro_Estado],
                [Rutas_Master].[Registro_Fecha],
                [Rutas_Master].[Registro_Usuario]
    FROM [Rutas_Master]
      WHERE
        ([Rutas_Master].[Zona_Secuencia] = @Zona_Secuencia)


RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Rutas_Master_LoadPersona]
(
    @Persona_Secuencia [int] ,
		@PageIndex 		int = 1,
		@PageSize  		int = 1000000,
    @_orderBy0 [nvarchar] (120) = NULL,
    @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
DECLARE @StartIndex INT, @EndIndex INT

SET   @PageIndex = @PageIndex - 1
SET   @StartIndex = (@PageIndex * @PageSize) + 1
SET   @EndIndex = @StartIndex + @PageSize - 1



;WITH PagingTable AS
(
SELECT 				ROW_NUMBER() OVER ( ORDER BY 		                [Rutas_Master].[Ruta_Secuencia]
 ) AS [RowNumber],

          [Rutas_Master].[Ruta_Secuencia],
          [Rutas_Master].[Zona_Secuencia],
          [Rutas_Master].[Ruta_Descripcion],
          [Rutas_Master].[Ruta_Persona_Encargado],
          [Rutas_Master].[Ruta_Persona_Auxiliar],
          [Rutas_Master].[Ruta_Mapa_Url],
          [Rutas_Master].[Ruta_Carros_Cantidad],
          [Rutas_Master].[Ruta_Publicadores_Cantidad],
          [Rutas_Master].[Registro_Estado],
          [Rutas_Master].[Registro_Fecha],
          [Rutas_Master].[Registro_Usuario]
    FROM [Rutas_Master]
		LEFT OUTER JOIN [Congregaciones_Master]
			On              [Zonas_Master].[Zona_Secuencia] =  [Congregaciones_Master].[Zona_Secuencia]
		LEFT OUTER JOIN [Personas_Master]
			On              [Congregaciones_Master].[Congregacion_Secuencia] =  [Personas_Master].[Congregacion_Secuencia]
		LEFT OUTER JOIN [Zonas_Master]
			On              [Zonas_Master].[Zona_Secuencia] =  [Rutas_Master].[Zona_Secuencia]
      WHERE Rutas_Master.Registro_Estado = 'A'
      AND 
         [Personas_Master].[Persona_Secuencia] = @persona_secuencia
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Rutas_Master_LoadZona]
(
    @Zona_Secuencia [Int] ,
		@PageIndex 		int = 1,
		@PageSize  		int = 1000000,
    @_orderBy0 [nvarchar] (120) = NULL,
    @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
DECLARE @StartIndex INT, @EndIndex INT

SET   @PageIndex = @PageIndex - 1
SET   @StartIndex = (@PageIndex * @PageSize) + 1
SET   @EndIndex = @StartIndex + @PageSize - 1



;WITH PagingTable AS
(
SELECT 				ROW_NUMBER() OVER ( ORDER BY 		                [Rutas_Master].[Ruta_Secuencia]
 ) AS [RowNumber],

          [Rutas_Master].[Ruta_Secuencia],
          [Rutas_Master].[Zona_Secuencia],
          [Rutas_Master].[Ruta_Descripcion],
          [Rutas_Master].[Ruta_Persona_Encargado],
          [Rutas_Master].[Ruta_Persona_Auxiliar],
          [Rutas_Master].[Ruta_Mapa_Url],
          [Rutas_Master].[Ruta_Carros_Cantidad],
          [Rutas_Master].[Ruta_Publicadores_Cantidad],
          [Rutas_Master].[Registro_Estado],
          [Rutas_Master].[Registro_Fecha],
          [Rutas_Master].[Registro_Usuario]
    FROM [Rutas_Master]
      WHERE Rutas_Master.Registro_Estado = 'A'
      AND 
          [Rutas_Master].[Zona_Secuencia] = @zona_secuencia
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Rutas_Master_LoadEncargadoAuxiliar]
(
    @Persona_Secuencia [int] ,
		@PageIndex 		int = 1,
		@PageSize  		int = 1000000,
    @_orderBy0 [nvarchar] (120) = NULL,
    @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
DECLARE @StartIndex INT, @EndIndex INT

SET   @PageIndex = @PageIndex - 1
SET   @StartIndex = (@PageIndex * @PageSize) + 1
SET   @EndIndex = @StartIndex + @PageSize - 1



;WITH PagingTable AS
(
SELECT 				ROW_NUMBER() OVER ( ORDER BY 		                [Rutas_Master].[Ruta_Secuencia]
 ) AS [RowNumber],

          [Rutas_Master].[Ruta_Secuencia],
          [Rutas_Master].[Zona_Secuencia],
          [Rutas_Master].[Ruta_Descripcion],
          [Rutas_Master].[Ruta_Persona_Encargado],
          [Rutas_Master].[Ruta_Persona_Auxiliar],
          [Rutas_Master].[Ruta_Mapa_Url],
          [Rutas_Master].[Ruta_Carros_Cantidad],
          [Rutas_Master].[Ruta_Publicadores_Cantidad],
          [Rutas_Master].[Registro_Estado],
          [Rutas_Master].[Registro_Fecha],
          [Rutas_Master].[Registro_Usuario]
    FROM [Rutas_Master]
      WHERE Rutas_Master.Registro_Estado = 'A'
      AND 
         [Rutas_Master].[Ruta_Persona_Encargado] = @persona_secuencia
 OR  [Rutas_Master].[Ruta_Persona_Auxiliar] = @persona_secuencia
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Rutas_Master_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [rm].[Ruta_Secuencia]
 ) AS [RowNumber],
				   rm.Ruta_Secuencia , 
				   rm.Zona_Secuencia , 
				   rm.Ruta_Descripcion , 
				   rm.Ruta_Persona_Encargado , 
				   rm.Ruta_Persona_Auxiliar , 
				   rm.Ruta_Mapa_Url , 
				   rm.Ruta_Carros_Cantidad , 
				   rm.Ruta_Publicadores_Cantidad , 
				   rm.Registro_Estado , 
				   rm.Registro_Fecha , 
				   rm.Registro_Usuario
		FROM  [dbo].[Rutas_Master]	As rm	
			 Inner Join Personas_Master As pm
			   On  pm.Persona_Secuencia = rm.Ruta_Persona_Encargado
			 Inner Join Personas_Master As pm1
			   On  pm1.Persona_Secuencia = rm.Ruta_Persona_Auxiliar
			 Inner Join Zonas_Master As zm
			   On  zm.Zona_Secuencia = rm.Zona_Secuencia

		   WHERE rm.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(rm.Ruta_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Zona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rm.Ruta_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Ruta_Persona_Encargado) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Ruta_Persona_Auxiliar) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rm.Ruta_Mapa_Url LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Ruta_Carros_Cantidad) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Ruta_Publicadores_Cantidad) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rm.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 0 THEN [Ruta_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 1 THEN [Ruta_Secuencia]
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
          WHEN @_orderBy0 = '[Ruta_Persona_Encargado]' AND @_orderByDirection0 = 0 THEN [Ruta_Persona_Encargado]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Persona_Encargado]' AND @_orderByDirection0 = 1 THEN [Ruta_Persona_Encargado]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Persona_Auxiliar]' AND @_orderByDirection0 = 0 THEN [Ruta_Persona_Auxiliar]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Persona_Auxiliar]' AND @_orderByDirection0 = 1 THEN [Ruta_Persona_Auxiliar]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Mapa_Url]' AND @_orderByDirection0 = 0 THEN [Ruta_Mapa_Url]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Mapa_Url]' AND @_orderByDirection0 = 1 THEN [Ruta_Mapa_Url]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Carros_Cantidad]' AND @_orderByDirection0 = 0 THEN [Ruta_Carros_Cantidad]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Carros_Cantidad]' AND @_orderByDirection0 = 1 THEN [Ruta_Carros_Cantidad]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Publicadores_Cantidad]' AND @_orderByDirection0 = 0 THEN [Ruta_Publicadores_Cantidad]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Publicadores_Cantidad]' AND @_orderByDirection0 = 1 THEN [Ruta_Publicadores_Cantidad]
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



CREATE PROCEDURE [dbo].[Proc_Rutas_Relacionados_Descripcion]

	@Ruta_Secuencia  [Int]  = 0 , 
	@Zona_Secuencia  [Int]  = 0 , 
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
				   Ruta_Secuencia,
				   Zona_Secuencia,
				   Ruta_Descripcion,
				   Ruta_Persona_Encargado,
				   Ruta_Persona_Auxiliar,
				   Ruta_Mapa_Url,
				   Ruta_Carros_Cantidad,
				   Ruta_Publicadores_Cantidad,
				   Registro_Estado,
				   Registro_Fecha,
				   Registro_Usuario,
				   Encargado_Persona_Secuencia,
				   Encargado_Congregacion_Secuencia,
				   Encargado_Persona_Nombres,
				   Encargado_Persona_Apellidos,
				   Auxiliar_Persona_Secuencia,
				   Auxiliar_Congregacion_Secuencia,
				   Auxiliar_Persona_Nombres,
				   Auxiliar_Persona_Apellidos,
				   Zona_Descripcion,
				   Zona_Nota,
				ROW_NUMBER() OVER ( ORDER BY  ) AS [RowNumber]
From (
		SELECT  Distinct Top (@RowCount)
				   rm.Ruta_Secuencia Ruta_Secuencia , 
				   rm.Zona_Secuencia Zona_Secuencia , 
				   rm.Ruta_Descripcion Ruta_Descripcion , 
				   rm.Ruta_Persona_Encargado Ruta_Persona_Encargado , 
				   rm.Ruta_Persona_Auxiliar Ruta_Persona_Auxiliar , 
				   rm.Ruta_Mapa_Url Ruta_Mapa_Url , 
				   rm.Ruta_Carros_Cantidad Ruta_Carros_Cantidad , 
				   rm.Ruta_Publicadores_Cantidad Ruta_Publicadores_Cantidad , 
				   rm.Registro_Estado Registro_Estado , 
				   rm.Registro_Fecha Registro_Fecha , 
				   rm.Registro_Usuario Registro_Usuario , 
				   pm.Persona_Secuencia Encargado_Persona_Secuencia , 
				   pm.Congregacion_Secuencia Encargado_Congregacion_Secuencia , 
				   pm.Persona_Nombres Encargado_Persona_Nombres , 
				   pm.Persona_Apellidos Encargado_Persona_Apellidos , 
				   pm1.Persona_Secuencia Auxiliar_Persona_Secuencia , 
				   pm1.Congregacion_Secuencia Auxiliar_Congregacion_Secuencia , 
				   pm1.Persona_Nombres Auxiliar_Persona_Nombres , 
				   pm1.Persona_Apellidos Auxiliar_Persona_Apellidos , 
				   zm.Zona_Descripcion Zona_Descripcion , 
				   zm.Zona_Nota Zona_Nota
		FROM  [dbo].[Rutas_Master]	As rm	
		 Left Join   [Personas_Master]	As pm	
		    On  pm.Persona_Secuencia =	rm.Ruta_Persona_Encargado
		 Left Join   [Personas_Master]	As pm1	
		    On  pm1.Persona_Secuencia =	rm.Ruta_Persona_Auxiliar
		 Inner Join   [Zonas_Master]	As zm	
		    On  zm.Zona_Secuencia =	rm.Zona_Secuencia
		   WHERE rm.Registro_Estado = 'A' 			    And  
				   (@Ruta_Secuencia = 0 OR rm.Ruta_Secuencia = @Ruta_Secuencia )				    And 
				   (@Zona_Secuencia = 0 OR rm.Zona_Secuencia = @Zona_Secuencia )
			    And ( 
				   (@SearchString Is Null OR LTRIM(rm.Ruta_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Zona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rm.Ruta_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Ruta_Persona_Encargado) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Ruta_Persona_Auxiliar) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rm.Ruta_Mapa_Url LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Ruta_Carros_Cantidad) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Ruta_Publicadores_Cantidad) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rm.Registro_Usuario LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm.Congregacion_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Nombres LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm.Persona_Apellidos LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm1.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pm1.Congregacion_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Persona_Nombres LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pm1.Persona_Apellidos LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR zm.Zona_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR zm.Zona_Nota LIKE '%' + @SearchString + '%'))
		
			) As X
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 0 THEN [Ruta_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 1 THEN [Ruta_Secuencia]
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
          WHEN @_orderBy0 = '[Ruta_Persona_Encargado]' AND @_orderByDirection0 = 0 THEN [Ruta_Persona_Encargado]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Persona_Encargado]' AND @_orderByDirection0 = 1 THEN [Ruta_Persona_Encargado]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Persona_Auxiliar]' AND @_orderByDirection0 = 0 THEN [Ruta_Persona_Auxiliar]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Persona_Auxiliar]' AND @_orderByDirection0 = 1 THEN [Ruta_Persona_Auxiliar]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Mapa_Url]' AND @_orderByDirection0 = 0 THEN [Ruta_Mapa_Url]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Mapa_Url]' AND @_orderByDirection0 = 1 THEN [Ruta_Mapa_Url]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Carros_Cantidad]' AND @_orderByDirection0 = 0 THEN [Ruta_Carros_Cantidad]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Carros_Cantidad]' AND @_orderByDirection0 = 1 THEN [Ruta_Carros_Cantidad]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Publicadores_Cantidad]' AND @_orderByDirection0 = 0 THEN [Ruta_Publicadores_Cantidad]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Publicadores_Cantidad]' AND @_orderByDirection0 = 1 THEN [Ruta_Publicadores_Cantidad]
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
          WHEN @_orderBy0 = '[Encargado_Persona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Encargado_Persona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Encargado_Persona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Encargado_Persona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Encargado_Congregacion_Secuencia]' AND @_orderByDirection0 = 0 THEN [Encargado_Congregacion_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Encargado_Congregacion_Secuencia]' AND @_orderByDirection0 = 1 THEN [Encargado_Congregacion_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Encargado_Persona_Nombres]' AND @_orderByDirection0 = 0 THEN [Encargado_Persona_Nombres]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Encargado_Persona_Nombres]' AND @_orderByDirection0 = 1 THEN [Encargado_Persona_Nombres]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Encargado_Persona_Apellidos]' AND @_orderByDirection0 = 0 THEN [Encargado_Persona_Apellidos]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Encargado_Persona_Apellidos]' AND @_orderByDirection0 = 1 THEN [Encargado_Persona_Apellidos]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Auxiliar_Persona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Auxiliar_Persona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Auxiliar_Persona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Auxiliar_Persona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Auxiliar_Congregacion_Secuencia]' AND @_orderByDirection0 = 0 THEN [Auxiliar_Congregacion_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Auxiliar_Congregacion_Secuencia]' AND @_orderByDirection0 = 1 THEN [Auxiliar_Congregacion_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Auxiliar_Persona_Nombres]' AND @_orderByDirection0 = 0 THEN [Auxiliar_Persona_Nombres]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Auxiliar_Persona_Nombres]' AND @_orderByDirection0 = 1 THEN [Auxiliar_Persona_Nombres]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Auxiliar_Persona_Apellidos]' AND @_orderByDirection0 = 0 THEN [Auxiliar_Persona_Apellidos]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Auxiliar_Persona_Apellidos]' AND @_orderByDirection0 = 1 THEN [Auxiliar_Persona_Apellidos]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Zona_Descripcion]' AND @_orderByDirection0 = 0 THEN [Zona_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Zona_Descripcion]' AND @_orderByDirection0 = 1 THEN [Zona_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Zona_Nota]' AND @_orderByDirection0 = 0 THEN [Zona_Nota]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Zona_Nota]' AND @_orderByDirection0 = 1 THEN [Zona_Nota]
      END DESC
GO
