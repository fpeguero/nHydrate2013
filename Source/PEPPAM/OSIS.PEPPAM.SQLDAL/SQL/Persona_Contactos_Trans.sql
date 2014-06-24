-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Contactos_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Contactos_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Contactos_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Contactos_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Contactos_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Contactos_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Contactos_Trans_ContactoTipo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_ContactoTipo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Contactos_Trans_Persona]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_Persona]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_Editar]
(
	@Persona_Contacto_Informacion  [VarChar]  (150),
	@Persona_Contacto_Nota  [VarChar]  (500) = null,
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Contacto_Tipo_Secuencia  [Int] ,
	@Persona_Contacto_Secuencia  [Int] ,
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
	[dbo].[Persona_Contactos_Trans] 
SET
	[Persona_Contacto_Informacion] = @Persona_Contacto_Informacion,
	[Persona_Contacto_Nota] = @Persona_Contacto_Nota,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Persona_Contactos_Trans].[Contacto_Tipo_Secuencia] = @Contacto_Tipo_Secuencia AND
	[dbo].[Persona_Contactos_Trans].[Persona_Contacto_Secuencia] = @Persona_Contacto_Secuencia AND
	[dbo].[Persona_Contactos_Trans].[Persona_Secuencia] = @Persona_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Persona_Contactos_Trans]
(
	[Contacto_Tipo_Secuencia],
	[Persona_Contacto_Informacion],
	[Persona_Contacto_Nota],
	[Persona_Secuencia],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Contacto_Tipo_Secuencia,
	@Persona_Contacto_Informacion,
	@Persona_Contacto_Nota,
	@Persona_Secuencia,
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
    SELECT DISTINCT @Persona_Contacto_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Persona_Contacto_Secuencia AS 'Persona_Contacto_Secuencia' 
        FROM [Persona_Contactos_Trans]
        WHERE ([Persona_Contactos_Trans].[Persona_Contacto_Secuencia] = @Persona_Contacto_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_Borrar]
(
	@Contacto_Tipo_Secuencia  [Int] ,
	@Persona_Contacto_Secuencia  [Int] ,
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


  DELETE FROM [Persona_Contactos_Trans]
    WHERE 
      ([Persona_Contactos_Trans].[Persona_Contacto_Secuencia] = @Persona_Contacto_Secuencia)
     AND       ([Persona_Contactos_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND       ([Persona_Contactos_Trans].[Contacto_Tipo_Secuencia] = @Contacto_Tipo_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Persona_Contactos_Trans]
(
	@Contacto_Tipo_Secuencia  [Int] ,
	@Persona_Contacto_Secuencia  [Int] ,
	@Persona_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Persona_Contactos_Trans].[Persona_Contacto_Secuencia],
                [Persona_Contactos_Trans].[Persona_Secuencia],
                [Persona_Contactos_Trans].[Contacto_Tipo_Secuencia],
                [Persona_Contactos_Trans].[Persona_Contacto_Informacion],
                [Persona_Contactos_Trans].[Persona_Contacto_Nota],
                [Persona_Contactos_Trans].[Registro_Estado],
                [Persona_Contactos_Trans].[Registro_Fecha],
                [Persona_Contactos_Trans].[Registro_Usuario]
    FROM [Persona_Contactos_Trans]
    WHERE 
     ( [Persona_Contactos_Trans].[Persona_Contacto_Secuencia] = @Persona_Contacto_Secuencia)
     AND      ( [Persona_Contactos_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND      ( [Persona_Contactos_Trans].[Contacto_Tipo_Secuencia] = @Contacto_Tipo_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Persona_Contactos_Trans].[Persona_Contacto_Secuencia],
                [Persona_Contactos_Trans].[Persona_Secuencia],
                [Persona_Contactos_Trans].[Contacto_Tipo_Secuencia],
                [Persona_Contactos_Trans].[Persona_Contacto_Informacion],
                [Persona_Contactos_Trans].[Persona_Contacto_Nota],
                [Persona_Contactos_Trans].[Registro_Estado],
                [Persona_Contactos_Trans].[Registro_Fecha],
                [Persona_Contactos_Trans].[Registro_Usuario]
    FROM [Persona_Contactos_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_ContactoTipo]
(
	@Contacto_Tipo_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Persona_Contactos_Trans].[Persona_Contacto_Secuencia],
                [Persona_Contactos_Trans].[Persona_Secuencia],
                [Persona_Contactos_Trans].[Contacto_Tipo_Secuencia],
                [Persona_Contactos_Trans].[Persona_Contacto_Informacion],
                [Persona_Contactos_Trans].[Persona_Contacto_Nota],
                [Persona_Contactos_Trans].[Registro_Estado],
                [Persona_Contactos_Trans].[Registro_Fecha],
                [Persona_Contactos_Trans].[Registro_Usuario]
    FROM [Persona_Contactos_Trans]
      WHERE
        ([Persona_Contactos_Trans].[Contacto_Tipo_Secuencia] = @Contacto_Tipo_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_Persona]
(
	@Persona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Persona_Contactos_Trans].[Persona_Contacto_Secuencia],
                [Persona_Contactos_Trans].[Persona_Secuencia],
                [Persona_Contactos_Trans].[Contacto_Tipo_Secuencia],
                [Persona_Contactos_Trans].[Persona_Contacto_Informacion],
                [Persona_Contactos_Trans].[Persona_Contacto_Nota],
                [Persona_Contactos_Trans].[Registro_Estado],
                [Persona_Contactos_Trans].[Registro_Fecha],
                [Persona_Contactos_Trans].[Registro_Usuario]
    FROM [Persona_Contactos_Trans]
      WHERE
        ([Persona_Contactos_Trans].[Persona_Secuencia] = @Persona_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Persona_Contactos_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [pct].[Persona_Contacto_Secuencia],
		                [pct].[Persona_Secuencia],
		                [pct].[Contacto_Tipo_Secuencia]
 ) AS [RowNumber],
				   pct.Persona_Contacto_Secuencia , 
				   pct.Persona_Secuencia , 
				   pct.Contacto_Tipo_Secuencia , 
				   pct.Persona_Contacto_Informacion , 
				   pct.Persona_Contacto_Nota , 
				   pct.Registro_Estado , 
				   pct.Registro_Fecha , 
				   pct.Registro_Usuario
		FROM  [dbo].[Persona_Contactos_Trans]	As pct	
			 Inner Join Contacto_Tipo_Cata As ctc
			   On  ctc.Contacto_Tipo_Secuencia = pct.Contacto_Tipo_Secuencia
			 Inner Join Personas_Master As pm
			   On  pm.Persona_Secuencia = pct.Persona_Secuencia

		   WHERE pct.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(pct.Persona_Contacto_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pct.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pct.Contacto_Tipo_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pct.Persona_Contacto_Informacion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pct.Persona_Contacto_Nota LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pct.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pct.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pct.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Persona_Contacto_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Contacto_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Contacto_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Contacto_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Contacto_Tipo_Secuencia]' AND @_orderByDirection0 = 0 THEN [Contacto_Tipo_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Contacto_Tipo_Secuencia]' AND @_orderByDirection0 = 1 THEN [Contacto_Tipo_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Contacto_Informacion]' AND @_orderByDirection0 = 0 THEN [Persona_Contacto_Informacion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Contacto_Informacion]' AND @_orderByDirection0 = 1 THEN [Persona_Contacto_Informacion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Contacto_Nota]' AND @_orderByDirection0 = 0 THEN [Persona_Contacto_Nota]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Contacto_Nota]' AND @_orderByDirection0 = 1 THEN [Persona_Contacto_Nota]
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

