-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Dias_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Dias_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Dias_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Dias_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Dias_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Dias_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Dias_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Dias_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Dias_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Dias_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Dias_Cata_Editar]
(
	@Dia_Descripcion  [VarChar]  (50),
	@Dia_Orden  [Int] ,
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Dia_Secuencia  [Int] 

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
	[dbo].[Dias_Cata] 
SET
	[Dia_Descripcion] = @Dia_Descripcion,
	[Dia_Orden] = @Dia_Orden,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Dias_Cata].[Dia_Secuencia] = @Dia_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Dias_Cata]
(
	[Dia_Descripcion],
	[Dia_Orden],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Dia_Descripcion,
	@Dia_Orden,
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
    SELECT DISTINCT @Dia_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Dia_Secuencia AS 'Dia_Secuencia' 
        FROM [Dias_Cata]
        WHERE ([Dias_Cata].[Dia_Secuencia] = @Dia_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Dias_Cata_Borrar]
(
	@Dia_Secuencia  [Int] 

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

    UPDATE [Horario_Turno_Dias_Trans] SET
     [Horario_Turno_Dias_Trans].[Dia_Secuencia] = NULL
    WHERE     ([Horario_Turno_Dias_Trans].[Dia_Secuencia] = @Dia_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Turnos_Dias_Trans] SET
     [Turnos_Dias_Trans].[Dia_Secuencia] = NULL
    WHERE     ([Turnos_Dias_Trans].[Dia_Secuencia] = @Dia_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Personas_Diponibilidad] SET
     [Personas_Diponibilidad].[Dia_Secuencia] = NULL
    WHERE     ([Personas_Diponibilidad].[Dia_Secuencia] = @Dia_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Dias_Cata]
    WHERE 
      ([Dias_Cata].[Dia_Secuencia] = @Dia_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Dias_Cata]
(
	@Dia_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Dias_Cata].[Dia_Secuencia],
                [Dias_Cata].[Dia_Descripcion],
                [Dias_Cata].[Dia_Orden],
                [Dias_Cata].[Registro_Estado],
                [Dias_Cata].[Registro_Fecha],
                [Dias_Cata].[Registro_Usuario]
    FROM [Dias_Cata]
    WHERE 
     ( [Dias_Cata].[Dia_Secuencia] = @Dia_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Dias_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Dias_Cata].[Dia_Secuencia],
                [Dias_Cata].[Dia_Descripcion],
                [Dias_Cata].[Dia_Orden],
                [Dias_Cata].[Registro_Estado],
                [Dias_Cata].[Registro_Fecha],
                [Dias_Cata].[Registro_Usuario]
    FROM [Dias_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Dias_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [dc].[Dia_Secuencia]
 ) AS [RowNumber],
				   dc.Dia_Secuencia , 
				   dc.Dia_Descripcion , 
				   dc.Dia_Orden , 
				   dc.Registro_Estado , 
				   dc.Registro_Fecha , 
				   dc.Registro_Usuario
		FROM  [dbo].[Dias_Cata]	As dc	

		   WHERE dc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(dc.Dia_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR dc.Dia_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(dc.Dia_Orden) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR dc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(dc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR dc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Dia_Secuencia]' AND @_orderByDirection0 = 0 THEN [Dia_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Dia_Secuencia]' AND @_orderByDirection0 = 1 THEN [Dia_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Dia_Descripcion]' AND @_orderByDirection0 = 0 THEN [Dia_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Dia_Descripcion]' AND @_orderByDirection0 = 1 THEN [Dia_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Dia_Orden]' AND @_orderByDirection0 = 0 THEN [Dia_Orden]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Dia_Orden]' AND @_orderByDirection0 = 1 THEN [Dia_Orden]
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

