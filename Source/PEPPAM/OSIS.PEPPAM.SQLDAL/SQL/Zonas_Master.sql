-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Master_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Zonas_Master_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Zona_Descripcion  [VarChar]  (150),
	@Zona_Nota  [VarChar]  (500),
	@Zona_Secuencia  [Int] 

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
	[dbo].[Zonas_Master] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Zona_Descripcion] = @Zona_Descripcion,
	[Zona_Nota] = @Zona_Nota

WHERE
	[dbo].[Zonas_Master].[Zona_Secuencia] = @Zona_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Zonas_Master]
(
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Zona_Descripcion],
	[Zona_Nota]
)
VALUES
(
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Zona_Descripcion,
	@Zona_Nota
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Zona_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Zona_Secuencia AS 'Zona_Secuencia' 
        FROM [Zonas_Master]
        WHERE ([Zonas_Master].[Zona_Secuencia] = @Zona_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Zonas_Master_Borrar]
(
	@Zona_Secuencia  [Int] 

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

    UPDATE [Rutas_Master] SET
     [Rutas_Master].[Zona_Secuencia] = NULL
    WHERE     ([Rutas_Master].[Zona_Secuencia] = @Zona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Zonas_Encargados_Trans] SET
     [Zonas_Encargados_Trans].[Zona_Secuencia] = NULL
    WHERE     ([Zonas_Encargados_Trans].[Zona_Secuencia] = @Zona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Congregaciones_Master] SET
     [Congregaciones_Master].[Zona_Secuencia] = NULL
    WHERE     ([Congregaciones_Master].[Zona_Secuencia] = @Zona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Notificaciones_Objetivo_Trans] SET
     [Notificaciones_Objetivo_Trans].[Zona_Secuencia] = NULL
    WHERE     ([Notificaciones_Objetivo_Trans].[Zona_Secuencia] = @Zona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Documentos_Objetivos_Trans] SET
     [Documentos_Objetivos_Trans].[Zona_Secuencia] = NULL
    WHERE     ([Documentos_Objetivos_Trans].[Zona_Secuencia] = @Zona_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Zonas_Master]
    WHERE 
      ([Zonas_Master].[Zona_Secuencia] = @Zona_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Zonas_Master]
(
	@Zona_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Zonas_Master].[Zona_Secuencia],
                [Zonas_Master].[Zona_Descripcion],
                [Zonas_Master].[Zona_Nota],
                [Zonas_Master].[Registro_Estado],
                [Zonas_Master].[Registro_Fecha],
                [Zonas_Master].[Registro_Usuario]
    FROM [Zonas_Master]
    WHERE 
     ( [Zonas_Master].[Zona_Secuencia] = @Zona_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Zonas_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Zonas_Master].[Zona_Secuencia],
                [Zonas_Master].[Zona_Descripcion],
                [Zonas_Master].[Zona_Nota],
                [Zonas_Master].[Registro_Estado],
                [Zonas_Master].[Registro_Fecha],
                [Zonas_Master].[Registro_Usuario]
    FROM [Zonas_Master]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Zonas_Master_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [zm].[Zona_Secuencia]
 ) AS [RowNumber],
				   zm.Zona_Secuencia , 
				   zm.Zona_Descripcion , 
				   zm.Zona_Nota , 
				   zm.Registro_Estado , 
				   zm.Registro_Fecha , 
				   zm.Registro_Usuario
		FROM  [dbo].[Zonas_Master]	As zm	

		   WHERE zm.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(zm.Zona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR zm.Zona_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR zm.Zona_Nota LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR zm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(zm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR zm.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Zona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Zona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Zona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Zona_Secuencia]
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

