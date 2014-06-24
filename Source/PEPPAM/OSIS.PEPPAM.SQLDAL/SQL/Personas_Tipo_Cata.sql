-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipo_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipo_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipo_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipo_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipo_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipo_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipo_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipo_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipo_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipo_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Personas_Tipo_Cata_Editar]
(
	@Persona_Tipo_Descripcion  [VarChar]  (50),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Persona_Tipo_Secuencia  [Int] 

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
	[dbo].[Personas_Tipo_Cata] 
SET
	[Persona_Tipo_Descripcion] = @Persona_Tipo_Descripcion,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Personas_Tipo_Cata].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Personas_Tipo_Cata]
(
	[Persona_Tipo_Descripcion],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Persona_Tipo_Descripcion,
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
    SELECT DISTINCT @Persona_Tipo_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Persona_Tipo_Secuencia AS 'Persona_Tipo_Secuencia' 
        FROM [Personas_Tipo_Cata]
        WHERE ([Personas_Tipo_Cata].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Personas_Tipo_Cata_Borrar]
(
	@Persona_Tipo_Secuencia  [Int] 

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

    UPDATE [Personas_Master] SET
     [Personas_Master].[Persona_Tipo_Secuencia] = NULL
    WHERE     ([Personas_Master].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Personas_Tipos_Trans] SET
     [Personas_Tipos_Trans].[Persona_Tipo_Secuencia] = NULL
    WHERE     ([Personas_Tipos_Trans].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Personas_Tipo_Cata]
    WHERE 
      ([Personas_Tipo_Cata].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Tipo_Cata]
(
	@Persona_Tipo_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Personas_Tipo_Cata].[Persona_Tipo_Secuencia],
                [Personas_Tipo_Cata].[Persona_Tipo_Descripcion],
                [Personas_Tipo_Cata].[Registro_Estado],
                [Personas_Tipo_Cata].[Registro_Fecha],
                [Personas_Tipo_Cata].[Registro_Usuario]
    FROM [Personas_Tipo_Cata]
    WHERE 
     ( [Personas_Tipo_Cata].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Tipo_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Personas_Tipo_Cata].[Persona_Tipo_Secuencia],
                [Personas_Tipo_Cata].[Persona_Tipo_Descripcion],
                [Personas_Tipo_Cata].[Registro_Estado],
                [Personas_Tipo_Cata].[Registro_Fecha],
                [Personas_Tipo_Cata].[Registro_Usuario]
    FROM [Personas_Tipo_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Personas_Tipo_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [ptc].[Persona_Tipo_Secuencia]
 ) AS [RowNumber],
				   ptc.Persona_Tipo_Secuencia , 
				   ptc.Persona_Tipo_Descripcion , 
				   ptc.Registro_Estado , 
				   ptc.Registro_Fecha , 
				   ptc.Registro_Usuario
		FROM  [dbo].[Personas_Tipo_Cata]	As ptc	

		   WHERE ptc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(ptc.Persona_Tipo_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ptc.Persona_Tipo_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ptc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ptc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ptc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Tipo_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Tipo_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Descripcion]' AND @_orderByDirection0 = 0 THEN [Persona_Tipo_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Descripcion]' AND @_orderByDirection0 = 1 THEN [Persona_Tipo_Descripcion]
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

