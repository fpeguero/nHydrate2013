-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Circuitos_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Circuitos_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Circuitos_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Circuitos_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Circuitos_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Circuitos_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Circuitos_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Circuitos_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Circuitos_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Circuitos_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Circuitos_Cata_Editar]
(
	@Circuito_Descripcion  [VarChar]  (50),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Circuito_Numero  [Int] 

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
	[dbo].[Circuitos_Cata] 
SET
	[Circuito_Descripcion] = @Circuito_Descripcion,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Circuitos_Cata].[Circuito_Numero] = @Circuito_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Circuitos_Cata]
(
	[Circuito_Descripcion],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Circuito_Descripcion,
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
    SELECT DISTINCT @Circuito_Numero = SCOPE_IDENTITY() 
    SELECT DISTINCT @Circuito_Numero AS 'Circuito_Numero' 
        FROM [Circuitos_Cata]
        WHERE ([Circuitos_Cata].[Circuito_Numero] = @Circuito_Numero)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Circuitos_Cata_Borrar]
(
	@Circuito_Numero  [Int] 

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

    UPDATE [Congregaciones_Master] SET
     [Congregaciones_Master].[Circuito_Numero] = NULL
    WHERE     ([Congregaciones_Master].[Circuito_Numero] = @Circuito_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Circuitos_Cata]
    WHERE 
      ([Circuitos_Cata].[Circuito_Numero] = @Circuito_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Circuitos_Cata]
(
	@Circuito_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Circuitos_Cata].[Circuito_Numero],
                [Circuitos_Cata].[Circuito_Descripcion],
                [Circuitos_Cata].[Registro_Estado],
                [Circuitos_Cata].[Registro_Fecha],
                [Circuitos_Cata].[Registro_Usuario]
    FROM [Circuitos_Cata]
    WHERE 
     ( [Circuitos_Cata].[Circuito_Numero] = @Circuito_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Circuitos_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Circuitos_Cata].[Circuito_Numero],
                [Circuitos_Cata].[Circuito_Descripcion],
                [Circuitos_Cata].[Registro_Estado],
                [Circuitos_Cata].[Registro_Fecha],
                [Circuitos_Cata].[Registro_Usuario]
    FROM [Circuitos_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Circuitos_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [cc].[Circuito_Numero]
 ) AS [RowNumber],
				   cc.Circuito_Numero , 
				   cc.Circuito_Descripcion , 
				   cc.Registro_Estado , 
				   cc.Registro_Fecha , 
				   cc.Registro_Usuario
		FROM  [dbo].[Circuitos_Cata]	As cc	

		   WHERE cc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(cc.Circuito_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR cc.Circuito_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR cc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(cc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR cc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Circuito_Numero]' AND @_orderByDirection0 = 0 THEN [Circuito_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Circuito_Numero]' AND @_orderByDirection0 = 1 THEN [Circuito_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Circuito_Descripcion]' AND @_orderByDirection0 = 0 THEN [Circuito_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Circuito_Descripcion]' AND @_orderByDirection0 = 1 THEN [Circuito_Descripcion]
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

