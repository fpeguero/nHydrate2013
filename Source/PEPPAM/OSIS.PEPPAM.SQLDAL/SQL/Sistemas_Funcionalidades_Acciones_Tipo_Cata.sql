-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_Editar]
(
	@Funcionalidad_Accion_Tipo_Descripcion  [VarChar]  (50),
	@Funcionalidad_Accion_Tipo_Explicacion  [VarChar]  (500),
	@Registro_Estado  [Char]  (1) = 'A',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (150),
	@Funcionalidad_Accion_Tipo_Secuencia  [Int] 

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
	[dbo].[Sistemas_Funcionalidades_Acciones_Tipo_Cata] 
SET
	[Funcionalidad_Accion_Tipo_Descripcion] = @Funcionalidad_Accion_Tipo_Descripcion,
	[Funcionalidad_Accion_Tipo_Explicacion] = @Funcionalidad_Accion_Tipo_Explicacion,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Funcionalidad_Accion_Tipo_Secuencia] = @Funcionalidad_Accion_Tipo_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Sistemas_Funcionalidades_Acciones_Tipo_Cata]
(
	[Funcionalidad_Accion_Tipo_Descripcion],
	[Funcionalidad_Accion_Tipo_Explicacion],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Funcionalidad_Accion_Tipo_Descripcion,
	@Funcionalidad_Accion_Tipo_Explicacion,
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
    SELECT DISTINCT @Funcionalidad_Accion_Tipo_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Funcionalidad_Accion_Tipo_Secuencia AS 'Funcionalidad_Accion_Tipo_Secuencia' 
        FROM [Sistemas_Funcionalidades_Acciones_Tipo_Cata]
        WHERE ([Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Funcionalidad_Accion_Tipo_Secuencia] = @Funcionalidad_Accion_Tipo_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_Borrar]
(
	@Funcionalidad_Accion_Tipo_Secuencia  [Int] 

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


  DELETE FROM [Sistemas_Funcionalidades_Acciones_Tipo_Cata]
    WHERE 
      ([Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Funcionalidad_Accion_Tipo_Secuencia] = @Funcionalidad_Accion_Tipo_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata]
(
	@Funcionalidad_Accion_Tipo_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Funcionalidad_Accion_Tipo_Secuencia],
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Funcionalidad_Accion_Tipo_Descripcion],
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Funcionalidad_Accion_Tipo_Explicacion],
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Registro_Estado],
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Registro_Fecha],
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Acciones_Tipo_Cata]
    WHERE 
     ( [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Funcionalidad_Accion_Tipo_Secuencia] = @Funcionalidad_Accion_Tipo_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Funcionalidad_Accion_Tipo_Secuencia],
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Funcionalidad_Accion_Tipo_Descripcion],
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Funcionalidad_Accion_Tipo_Explicacion],
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Registro_Estado],
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Registro_Fecha],
                [Sistemas_Funcionalidades_Acciones_Tipo_Cata].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Acciones_Tipo_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Tipo_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [sfatc].[Funcionalidad_Accion_Tipo_Secuencia]
 ) AS [RowNumber],
				   sfatc.Funcionalidad_Accion_Tipo_Secuencia , 
				   sfatc.Funcionalidad_Accion_Tipo_Descripcion , 
				   sfatc.Funcionalidad_Accion_Tipo_Explicacion , 
				   sfatc.Registro_Estado , 
				   sfatc.Registro_Fecha , 
				   sfatc.Registro_Usuario
		FROM  [dbo].[Sistemas_Funcionalidades_Acciones_Tipo_Cata]	As sfatc	

		   WHERE sfatc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(sfatc.Funcionalidad_Accion_Tipo_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfatc.Funcionalidad_Accion_Tipo_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfatc.Funcionalidad_Accion_Tipo_Explicacion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfatc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sfatc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfatc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Tipo_Secuencia]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Tipo_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Tipo_Secuencia]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Tipo_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Tipo_Descripcion]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Tipo_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Tipo_Descripcion]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Tipo_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Tipo_Explicacion]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Tipo_Explicacion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Tipo_Explicacion]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Tipo_Explicacion]
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

