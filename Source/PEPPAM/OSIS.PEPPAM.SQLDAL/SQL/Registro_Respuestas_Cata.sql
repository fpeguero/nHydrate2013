-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Respuestas_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Respuestas_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Respuestas_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Respuestas_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Respuestas_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Respuestas_Cata_RegistroRespuetaCategoriasCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata_RegistroRespuetaCategoriasCata]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Respuesta_Categoria_Secuencia  [Int] ,
	@Respuesta_Descripcion  [VarChar]  (150),
	@Respuesta_Secuencia  [Int] 

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
	[dbo].[Registro_Respuestas_Cata] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Respuesta_Categoria_Secuencia] = @Respuesta_Categoria_Secuencia,
	[Respuesta_Descripcion] = @Respuesta_Descripcion

WHERE
	[dbo].[Registro_Respuestas_Cata].[Respuesta_Secuencia] = @Respuesta_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Registro_Respuestas_Cata]
(
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Respuesta_Categoria_Secuencia],
	[Respuesta_Descripcion]
)
VALUES
(
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Respuesta_Categoria_Secuencia,
	@Respuesta_Descripcion
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Respuesta_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Respuesta_Secuencia AS 'Respuesta_Secuencia' 
        FROM [Registro_Respuestas_Cata]
        WHERE ([Registro_Respuestas_Cata].[Respuesta_Secuencia] = @Respuesta_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata_Borrar]
(
	@Respuesta_Secuencia  [Int] 

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

    UPDATE [Registro_Preguntas_Cata] SET
     [Registro_Preguntas_Cata].[Respuesta_Secuencia] = NULL
    WHERE     ([Registro_Preguntas_Cata].[Respuesta_Secuencia] = @Respuesta_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Registro_Respuestas_Cata]
    WHERE 
      ([Registro_Respuestas_Cata].[Respuesta_Secuencia] = @Respuesta_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata]
(
	@Respuesta_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Registro_Respuestas_Cata].[Respuesta_Secuencia],
                [Registro_Respuestas_Cata].[Respuesta_Categoria_Secuencia],
                [Registro_Respuestas_Cata].[Respuesta_Descripcion],
                [Registro_Respuestas_Cata].[Registro_Estado],
                [Registro_Respuestas_Cata].[Registro_Fecha],
                [Registro_Respuestas_Cata].[Registro_Usuario]
    FROM [Registro_Respuestas_Cata]
    WHERE 
     ( [Registro_Respuestas_Cata].[Respuesta_Secuencia] = @Respuesta_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Registro_Respuestas_Cata].[Respuesta_Secuencia],
                [Registro_Respuestas_Cata].[Respuesta_Categoria_Secuencia],
                [Registro_Respuestas_Cata].[Respuesta_Descripcion],
                [Registro_Respuestas_Cata].[Registro_Estado],
                [Registro_Respuestas_Cata].[Registro_Fecha],
                [Registro_Respuestas_Cata].[Registro_Usuario]
    FROM [Registro_Respuestas_Cata]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata_RegistroRespuetaCategoriasCata]
(
	@Respuesta_Categoria_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Registro_Respuestas_Cata].[Respuesta_Secuencia],
                [Registro_Respuestas_Cata].[Respuesta_Categoria_Secuencia],
                [Registro_Respuestas_Cata].[Respuesta_Descripcion],
                [Registro_Respuestas_Cata].[Registro_Estado],
                [Registro_Respuestas_Cata].[Registro_Fecha],
                [Registro_Respuestas_Cata].[Registro_Usuario]
    FROM [Registro_Respuestas_Cata]
      WHERE
        ([Registro_Respuestas_Cata].[Respuesta_Categoria_Secuencia] = @Respuesta_Categoria_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Registro_Respuestas_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [rrc].[Respuesta_Secuencia]
 ) AS [RowNumber],
				   rrc.Respuesta_Secuencia , 
				   rrc.Respuesta_Categoria_Secuencia , 
				   rrc.Respuesta_Descripcion , 
				   rrc.Registro_Estado , 
				   rrc.Registro_Fecha , 
				   rrc.Registro_Usuario
		FROM  [dbo].[Registro_Respuestas_Cata]	As rrc	
			 Inner Join Registro_Respueta_Categorias_Cata As rrcc
			   On  rrcc.Respuesta_Categoria_Secuencia = rrc.Respuesta_Categoria_Secuencia

		   WHERE rrc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(rrc.Respuesta_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rrc.Respuesta_Categoria_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rrc.Respuesta_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rrc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rrc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rrc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Respuesta_Secuencia]' AND @_orderByDirection0 = 0 THEN [Respuesta_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Respuesta_Secuencia]' AND @_orderByDirection0 = 1 THEN [Respuesta_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Respuesta_Categoria_Secuencia]' AND @_orderByDirection0 = 0 THEN [Respuesta_Categoria_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Respuesta_Categoria_Secuencia]' AND @_orderByDirection0 = 1 THEN [Respuesta_Categoria_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Respuesta_Descripcion]' AND @_orderByDirection0 = 0 THEN [Respuesta_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Respuesta_Descripcion]' AND @_orderByDirection0 = 1 THEN [Respuesta_Descripcion]
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

