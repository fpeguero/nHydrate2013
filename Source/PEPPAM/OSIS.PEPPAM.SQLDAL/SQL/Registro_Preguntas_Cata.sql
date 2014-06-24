-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Preguntas_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Preguntas_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Preguntas_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Preguntas_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Preguntas_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Registro_Preguntas_Cata_RegistroRespuestasCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata_RegistroRespuestasCata]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata_Editar]
(
	@Pregunta_Descripcion  [VarChar]  (500),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Respuesta_Secuencia  [Int]  = 1,
	@Pregunta_Secuencia  [Int] 

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
	[dbo].[Registro_Preguntas_Cata] 
SET
	[Pregunta_Descripcion] = @Pregunta_Descripcion,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Respuesta_Secuencia] = @Respuesta_Secuencia

WHERE
	[dbo].[Registro_Preguntas_Cata].[Pregunta_Secuencia] = @Pregunta_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Registro_Preguntas_Cata]
(
	[Pregunta_Descripcion],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Respuesta_Secuencia]
)
VALUES
(
	@Pregunta_Descripcion,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Respuesta_Secuencia
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Pregunta_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Pregunta_Secuencia AS 'Pregunta_Secuencia' 
        FROM [Registro_Preguntas_Cata]
        WHERE ([Registro_Preguntas_Cata].[Pregunta_Secuencia] = @Pregunta_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata_Borrar]
(
	@Pregunta_Secuencia  [Int] 

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


  DELETE FROM [Registro_Preguntas_Cata]
    WHERE 
      ([Registro_Preguntas_Cata].[Pregunta_Secuencia] = @Pregunta_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata]
(
	@Pregunta_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Registro_Preguntas_Cata].[Pregunta_Secuencia],
                [Registro_Preguntas_Cata].[Respuesta_Secuencia],
                [Registro_Preguntas_Cata].[Pregunta_Descripcion],
                [Registro_Preguntas_Cata].[Registro_Estado],
                [Registro_Preguntas_Cata].[Registro_Fecha],
                [Registro_Preguntas_Cata].[Registro_Usuario]
    FROM [Registro_Preguntas_Cata]
    WHERE 
     ( [Registro_Preguntas_Cata].[Pregunta_Secuencia] = @Pregunta_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Registro_Preguntas_Cata].[Pregunta_Secuencia],
                [Registro_Preguntas_Cata].[Respuesta_Secuencia],
                [Registro_Preguntas_Cata].[Pregunta_Descripcion],
                [Registro_Preguntas_Cata].[Registro_Estado],
                [Registro_Preguntas_Cata].[Registro_Fecha],
                [Registro_Preguntas_Cata].[Registro_Usuario]
    FROM [Registro_Preguntas_Cata]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata_RegistroRespuestasCata]
(
	@Respuesta_Secuencia  [Int]  = 1,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Registro_Preguntas_Cata].[Pregunta_Secuencia],
                [Registro_Preguntas_Cata].[Respuesta_Secuencia],
                [Registro_Preguntas_Cata].[Pregunta_Descripcion],
                [Registro_Preguntas_Cata].[Registro_Estado],
                [Registro_Preguntas_Cata].[Registro_Fecha],
                [Registro_Preguntas_Cata].[Registro_Usuario]
    FROM [Registro_Preguntas_Cata]
      WHERE
        ([Registro_Preguntas_Cata].[Respuesta_Secuencia] = @Respuesta_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Registro_Preguntas_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [rpc].[Pregunta_Secuencia]
 ) AS [RowNumber],
				   rpc.Pregunta_Secuencia , 
				   rpc.Respuesta_Secuencia , 
				   rpc.Pregunta_Descripcion , 
				   rpc.Registro_Estado , 
				   rpc.Registro_Fecha , 
				   rpc.Registro_Usuario
		FROM  [dbo].[Registro_Preguntas_Cata]	As rpc	
			 Inner Join Registro_Respuestas_Cata As rrc
			   On  rrc.Respuesta_Secuencia = rpc.Respuesta_Secuencia

		   WHERE rpc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(rpc.Pregunta_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rpc.Respuesta_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rpc.Pregunta_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rpc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rpc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rpc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Pregunta_Secuencia]' AND @_orderByDirection0 = 0 THEN [Pregunta_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Pregunta_Secuencia]' AND @_orderByDirection0 = 1 THEN [Pregunta_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Respuesta_Secuencia]' AND @_orderByDirection0 = 0 THEN [Respuesta_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Respuesta_Secuencia]' AND @_orderByDirection0 = 1 THEN [Respuesta_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Pregunta_Descripcion]' AND @_orderByDirection0 = 0 THEN [Pregunta_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Pregunta_Descripcion]' AND @_orderByDirection0 = 1 THEN [Pregunta_Descripcion]
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

