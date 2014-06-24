-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Contacto_Tipo_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Contacto_Tipo_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Contacto_Tipo_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Contacto_Tipo_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Contacto_Tipo_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Contacto_Tipo_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Contacto_Tipo_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Contacto_Tipo_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Contacto_Tipo_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Contacto_Tipo_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Contacto_Tipo_Cata_Editar]
(
	@Contacto_Tipo_Descripcion  [VarChar]  (50),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Contacto_Tipo_Secuencia  [Int] 

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
	[dbo].[Contacto_Tipo_Cata] 
SET
	[Contacto_Tipo_Descripcion] = @Contacto_Tipo_Descripcion,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Contacto_Tipo_Cata].[Contacto_Tipo_Secuencia] = @Contacto_Tipo_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Contacto_Tipo_Cata]
(
	[Contacto_Tipo_Descripcion],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Contacto_Tipo_Descripcion,
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
    SELECT DISTINCT @Contacto_Tipo_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Contacto_Tipo_Secuencia AS 'Contacto_Tipo_Secuencia' 
        FROM [Contacto_Tipo_Cata]
        WHERE ([Contacto_Tipo_Cata].[Contacto_Tipo_Secuencia] = @Contacto_Tipo_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Contacto_Tipo_Cata_Borrar]
(
	@Contacto_Tipo_Secuencia  [Int] 

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
     [Persona_Contactos_Trans].[Contacto_Tipo_Secuencia] = NULL
    WHERE     ([Persona_Contactos_Trans].[Contacto_Tipo_Secuencia] = @Contacto_Tipo_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Contacto_Tipo_Cata]
    WHERE 
      ([Contacto_Tipo_Cata].[Contacto_Tipo_Secuencia] = @Contacto_Tipo_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Contacto_Tipo_Cata]
(
	@Contacto_Tipo_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Contacto_Tipo_Cata].[Contacto_Tipo_Secuencia],
                [Contacto_Tipo_Cata].[Contacto_Tipo_Descripcion],
                [Contacto_Tipo_Cata].[Registro_Estado],
                [Contacto_Tipo_Cata].[Registro_Fecha],
                [Contacto_Tipo_Cata].[Registro_Usuario]
    FROM [Contacto_Tipo_Cata]
    WHERE 
     ( [Contacto_Tipo_Cata].[Contacto_Tipo_Secuencia] = @Contacto_Tipo_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Contacto_Tipo_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Contacto_Tipo_Cata].[Contacto_Tipo_Secuencia],
                [Contacto_Tipo_Cata].[Contacto_Tipo_Descripcion],
                [Contacto_Tipo_Cata].[Registro_Estado],
                [Contacto_Tipo_Cata].[Registro_Fecha],
                [Contacto_Tipo_Cata].[Registro_Usuario]
    FROM [Contacto_Tipo_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Contacto_Tipo_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [ctc].[Contacto_Tipo_Secuencia]
 ) AS [RowNumber],
				   ctc.Contacto_Tipo_Secuencia , 
				   ctc.Contacto_Tipo_Descripcion , 
				   ctc.Registro_Estado , 
				   ctc.Registro_Fecha , 
				   ctc.Registro_Usuario
		FROM  [dbo].[Contacto_Tipo_Cata]	As ctc	

		   WHERE ctc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(ctc.Contacto_Tipo_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ctc.Contacto_Tipo_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ctc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ctc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ctc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Contacto_Tipo_Secuencia]' AND @_orderByDirection0 = 0 THEN [Contacto_Tipo_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Contacto_Tipo_Secuencia]' AND @_orderByDirection0 = 1 THEN [Contacto_Tipo_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Contacto_Tipo_Descripcion]' AND @_orderByDirection0 = 0 THEN [Contacto_Tipo_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Contacto_Tipo_Descripcion]' AND @_orderByDirection0 = 1 THEN [Contacto_Tipo_Descripcion]
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

