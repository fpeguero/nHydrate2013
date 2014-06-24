-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Slides_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Slides_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Slides_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Slides_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Slides_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Slides_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Slides_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Slides_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Slides_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Slides_Master_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Sistemas_Slides_Master_Editar]
(
	@Registro_Estado  [Char]  (1) = 'A',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (150),
	@Slide_Contenido  [VarChar]  (5000),
	@Slide_Css  [VarChar]  (1500) = 'N',
	@Slide_Fijo  [Char]  (1) = 'N',
	@Slide_Image  [VarChar]  (250),
	@Slide_Image_Abajo  [VarChar]  (250) = 'N',
	@Slide_Image_Publicar  [Char]  (1) = 'N',
	@Slide_Vigencia_Desde  [DateTime] ,
	@Slide_Vigencia_Hasta  [DateTime] ,
	@Slide_Secuencia  [Int] 

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
	[dbo].[Sistemas_Slides_Master] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Slide_Contenido] = @Slide_Contenido,
	[Slide_Css] = @Slide_Css,
	[Slide_Fijo] = @Slide_Fijo,
	[Slide_Image] = @Slide_Image,
	[Slide_Image_Abajo] = @Slide_Image_Abajo,
	[Slide_Image_Publicar] = @Slide_Image_Publicar,
	[Slide_Vigencia_Desde] = @Slide_Vigencia_Desde,
	[Slide_Vigencia_Hasta] = @Slide_Vigencia_Hasta

WHERE
	[dbo].[Sistemas_Slides_Master].[Slide_Secuencia] = @Slide_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Sistemas_Slides_Master]
(
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Slide_Contenido],
	[Slide_Css],
	[Slide_Fijo],
	[Slide_Image],
	[Slide_Image_Abajo],
	[Slide_Image_Publicar],
	[Slide_Vigencia_Desde],
	[Slide_Vigencia_Hasta]
)
VALUES
(
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Slide_Contenido,
	@Slide_Css,
	@Slide_Fijo,
	@Slide_Image,
	@Slide_Image_Abajo,
	@Slide_Image_Publicar,
	@Slide_Vigencia_Desde,
	@Slide_Vigencia_Hasta
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Slide_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Slide_Secuencia AS 'Slide_Secuencia' 
        FROM [Sistemas_Slides_Master]
        WHERE ([Sistemas_Slides_Master].[Slide_Secuencia] = @Slide_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Sistemas_Slides_Master_Borrar]
(
	@Slide_Secuencia  [Int] 

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


  DELETE FROM [Sistemas_Slides_Master]
    WHERE 
      ([Sistemas_Slides_Master].[Slide_Secuencia] = @Slide_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Slides_Master]
(
	@Slide_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Sistemas_Slides_Master].[Slide_Secuencia],
                [Sistemas_Slides_Master].[Slide_Image],
                [Sistemas_Slides_Master].[Slide_Contenido],
                [Sistemas_Slides_Master].[Slide_Vigencia_Desde],
                [Sistemas_Slides_Master].[Slide_Vigencia_Hasta],
                [Sistemas_Slides_Master].[Slide_Fijo],
                [Sistemas_Slides_Master].[Slide_Image_Abajo],
                [Sistemas_Slides_Master].[Slide_Css],
                [Sistemas_Slides_Master].[Slide_Image_Publicar],
                [Sistemas_Slides_Master].[Registro_Estado],
                [Sistemas_Slides_Master].[Registro_Fecha],
                [Sistemas_Slides_Master].[Registro_Usuario]
    FROM [Sistemas_Slides_Master]
    WHERE 
     ( [Sistemas_Slides_Master].[Slide_Secuencia] = @Slide_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Slides_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Sistemas_Slides_Master].[Slide_Secuencia],
                [Sistemas_Slides_Master].[Slide_Image],
                [Sistemas_Slides_Master].[Slide_Contenido],
                [Sistemas_Slides_Master].[Slide_Vigencia_Desde],
                [Sistemas_Slides_Master].[Slide_Vigencia_Hasta],
                [Sistemas_Slides_Master].[Slide_Fijo],
                [Sistemas_Slides_Master].[Slide_Image_Abajo],
                [Sistemas_Slides_Master].[Slide_Css],
                [Sistemas_Slides_Master].[Slide_Image_Publicar],
                [Sistemas_Slides_Master].[Registro_Estado],
                [Sistemas_Slides_Master].[Registro_Fecha],
                [Sistemas_Slides_Master].[Registro_Usuario]
    FROM [Sistemas_Slides_Master]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Sistemas_Slides_Master_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [ssm].[Slide_Secuencia]
 ) AS [RowNumber],
				   ssm.Slide_Secuencia , 
				   ssm.Slide_Image , 
				   ssm.Slide_Contenido , 
				   ssm.Slide_Vigencia_Desde , 
				   ssm.Slide_Vigencia_Hasta , 
				   ssm.Slide_Fijo , 
				   ssm.Slide_Image_Abajo , 
				   ssm.Slide_Css , 
				   ssm.Slide_Image_Publicar , 
				   ssm.Registro_Estado , 
				   ssm.Registro_Fecha , 
				   ssm.Registro_Usuario
		FROM  [dbo].[Sistemas_Slides_Master]	As ssm	

		   WHERE ssm.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(ssm.Slide_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ssm.Slide_Image LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ssm.Slide_Contenido LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ssm.Slide_Vigencia_Desde) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ssm.Slide_Vigencia_Hasta) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ssm.Slide_Fijo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ssm.Slide_Image_Abajo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ssm.Slide_Css LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ssm.Slide_Image_Publicar LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ssm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ssm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ssm.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Slide_Secuencia]' AND @_orderByDirection0 = 0 THEN [Slide_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Slide_Secuencia]' AND @_orderByDirection0 = 1 THEN [Slide_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Slide_Image]' AND @_orderByDirection0 = 0 THEN [Slide_Image]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Slide_Image]' AND @_orderByDirection0 = 1 THEN [Slide_Image]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Slide_Contenido]' AND @_orderByDirection0 = 0 THEN [Slide_Contenido]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Slide_Contenido]' AND @_orderByDirection0 = 1 THEN [Slide_Contenido]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Slide_Vigencia_Desde]' AND @_orderByDirection0 = 0 THEN [Slide_Vigencia_Desde]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Slide_Vigencia_Desde]' AND @_orderByDirection0 = 1 THEN [Slide_Vigencia_Desde]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Slide_Vigencia_Hasta]' AND @_orderByDirection0 = 0 THEN [Slide_Vigencia_Hasta]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Slide_Vigencia_Hasta]' AND @_orderByDirection0 = 1 THEN [Slide_Vigencia_Hasta]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Slide_Fijo]' AND @_orderByDirection0 = 0 THEN [Slide_Fijo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Slide_Fijo]' AND @_orderByDirection0 = 1 THEN [Slide_Fijo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Slide_Image_Abajo]' AND @_orderByDirection0 = 0 THEN [Slide_Image_Abajo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Slide_Image_Abajo]' AND @_orderByDirection0 = 1 THEN [Slide_Image_Abajo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Slide_Css]' AND @_orderByDirection0 = 0 THEN [Slide_Css]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Slide_Css]' AND @_orderByDirection0 = 1 THEN [Slide_Css]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Slide_Image_Publicar]' AND @_orderByDirection0 = 0 THEN [Slide_Image_Publicar]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Slide_Image_Publicar]' AND @_orderByDirection0 = 1 THEN [Slide_Image_Publicar]
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

