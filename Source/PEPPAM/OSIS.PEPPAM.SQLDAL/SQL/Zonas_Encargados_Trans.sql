-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Encargados_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Encargados_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Encargados_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Encargados_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Encargados_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Encargados_Trans_Persona]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_Persona]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Zonas_Encargados_Trans_Zona]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_Zona]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Persona_Secuencia  [Int] ,
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
	[dbo].[Zonas_Encargados_Trans] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Zonas_Encargados_Trans].[Persona_Secuencia] = @Persona_Secuencia AND
	[dbo].[Zonas_Encargados_Trans].[Zona_Secuencia] = @Zona_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Zonas_Encargados_Trans]
(
	[Persona_Secuencia],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Zona_Secuencia]
)
VALUES
(
	@Persona_Secuencia,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Zona_Secuencia
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_Borrar]
(
	@Persona_Secuencia  [Int] ,
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


  DELETE FROM [Zonas_Encargados_Trans]
    WHERE 
      ([Zonas_Encargados_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND       ([Zonas_Encargados_Trans].[Zona_Secuencia] = @Zona_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans]
(
	@Persona_Secuencia  [Int] ,
	@Zona_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Zonas_Encargados_Trans].[Persona_Secuencia],
                [Zonas_Encargados_Trans].[Zona_Secuencia],
                [Zonas_Encargados_Trans].[Registro_Estado],
                [Zonas_Encargados_Trans].[Registro_Fecha],
                [Zonas_Encargados_Trans].[Registro_Usuario]
    FROM [Zonas_Encargados_Trans]
    WHERE 
     ( [Zonas_Encargados_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND      ( [Zonas_Encargados_Trans].[Zona_Secuencia] = @Zona_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Zonas_Encargados_Trans].[Persona_Secuencia],
                [Zonas_Encargados_Trans].[Zona_Secuencia],
                [Zonas_Encargados_Trans].[Registro_Estado],
                [Zonas_Encargados_Trans].[Registro_Fecha],
                [Zonas_Encargados_Trans].[Registro_Usuario]
    FROM [Zonas_Encargados_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_Persona]
(
	@Persona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Zonas_Encargados_Trans].[Persona_Secuencia],
                [Zonas_Encargados_Trans].[Zona_Secuencia],
                [Zonas_Encargados_Trans].[Registro_Estado],
                [Zonas_Encargados_Trans].[Registro_Fecha],
                [Zonas_Encargados_Trans].[Registro_Usuario]
    FROM [Zonas_Encargados_Trans]
      WHERE
        ([Zonas_Encargados_Trans].[Persona_Secuencia] = @Persona_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_Zona]
(
	@Zona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Zonas_Encargados_Trans].[Persona_Secuencia],
                [Zonas_Encargados_Trans].[Zona_Secuencia],
                [Zonas_Encargados_Trans].[Registro_Estado],
                [Zonas_Encargados_Trans].[Registro_Fecha],
                [Zonas_Encargados_Trans].[Registro_Usuario]
    FROM [Zonas_Encargados_Trans]
      WHERE
        ([Zonas_Encargados_Trans].[Zona_Secuencia] = @Zona_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Zonas_Encargados_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [zet].[Persona_Secuencia],
		                [zet].[Zona_Secuencia]
 ) AS [RowNumber],
				   zet.Persona_Secuencia , 
				   zet.Zona_Secuencia , 
				   zet.Registro_Estado , 
				   zet.Registro_Fecha , 
				   zet.Registro_Usuario
		FROM  [dbo].[Zonas_Encargados_Trans]	As zet	
			 Inner Join Personas_Master As pm
			   On  pm.Persona_Secuencia = zet.Persona_Secuencia
			 Inner Join Zonas_Master As zm
			   On  zm.Zona_Secuencia = zet.Zona_Secuencia

		   WHERE zet.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(zet.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(zet.Zona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR zet.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(zet.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR zet.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
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
          WHEN @_orderBy0 = '[Zona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Zona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Zona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Zona_Secuencia]
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

