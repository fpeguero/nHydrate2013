-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Mensaje_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Mensaje_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Mensaje_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Mensaje_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Mensaje_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Mensaje_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Mensaje_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Mensaje_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Mensaje_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Mensaje_Trans_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Sistemas_Mensaje_Trans_Editar]
(
	@Mensaje_Descripcion  [VarChar]  (500),
	@Registro_Estado  [Char]  (1) = 'A',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (150),
	@Mensaje_Codigo  [VarChar]  (150)

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
	[dbo].[Sistemas_Mensaje_Trans] 
SET
	[Mensaje_Descripcion] = @Mensaje_Descripcion,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Sistemas_Mensaje_Trans].[Mensaje_Codigo] = @Mensaje_Codigo



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Sistemas_Mensaje_Trans]
(
	[Mensaje_Codigo],
	[Mensaje_Descripcion],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Mensaje_Codigo,
	@Mensaje_Descripcion,
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
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Sistemas_Mensaje_Trans_Borrar]
(
	@Mensaje_Codigo  [VarChar]  (150)

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


  DELETE FROM [Sistemas_Mensaje_Trans]
    WHERE 
      ([Sistemas_Mensaje_Trans].[Mensaje_Codigo] = @Mensaje_Codigo)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Mensaje_Trans]
(
	@Mensaje_Codigo  [VarChar]  (150)

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Sistemas_Mensaje_Trans].[Mensaje_Codigo],
                [Sistemas_Mensaje_Trans].[Mensaje_Descripcion],
                [Sistemas_Mensaje_Trans].[Registro_Estado],
                [Sistemas_Mensaje_Trans].[Registro_Fecha],
                [Sistemas_Mensaje_Trans].[Registro_Usuario]
    FROM [Sistemas_Mensaje_Trans]
    WHERE 
     ( [Sistemas_Mensaje_Trans].[Mensaje_Codigo] = @Mensaje_Codigo)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Mensaje_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Sistemas_Mensaje_Trans].[Mensaje_Codigo],
                [Sistemas_Mensaje_Trans].[Mensaje_Descripcion],
                [Sistemas_Mensaje_Trans].[Registro_Estado],
                [Sistemas_Mensaje_Trans].[Registro_Fecha],
                [Sistemas_Mensaje_Trans].[Registro_Usuario]
    FROM [Sistemas_Mensaje_Trans]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Sistemas_Mensaje_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [smt].[Mensaje_Codigo]
 ) AS [RowNumber],
				   smt.Mensaje_Codigo , 
				   smt.Mensaje_Descripcion , 
				   smt.Registro_Estado , 
				   smt.Registro_Fecha , 
				   smt.Registro_Usuario
		FROM  [dbo].[Sistemas_Mensaje_Trans]	As smt	

		   WHERE smt.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR smt.Mensaje_Codigo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR smt.Mensaje_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR smt.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(smt.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR smt.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Mensaje_Codigo]' AND @_orderByDirection0 = 0 THEN [Mensaje_Codigo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Mensaje_Codigo]' AND @_orderByDirection0 = 1 THEN [Mensaje_Codigo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Mensaje_Descripcion]' AND @_orderByDirection0 = 0 THEN [Mensaje_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Mensaje_Descripcion]' AND @_orderByDirection0 = 1 THEN [Mensaje_Descripcion]
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

