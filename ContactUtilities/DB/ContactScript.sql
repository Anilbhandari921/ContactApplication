DECLARE @Name VARCHAR(MAX), @Query VARCHAR(MAX) 
SELECT @Name = 'tblContact'
IF EXISTS (SELECT * FROM sys.tables WHERE name like @Name)
BEGIN
SET @query = 'DROP TABLE ' + @Name
EXEC (@query)
END
Go

CREATE TABLE [dbo].[tblContact]
(  
    [ContactId] [bigint] NOT NULL Identity,  
    [ContactName] [nvarchar](50)NULL,  
    [ContactEmail] [nvarchar](50)NOT NULL,  
    [ContactCity] [nvarchar](256)NULL,  
    [ContactPhone] [nvarchar](50)NULL,  
CONSTRAINT [PK_tblContact] PRIMARY KEY CLUSTERED  
(  [ContactId] ASC)WITH (PAD_INDEX=OFF,STATISTICS_NORECOMPUTE=OFF,IGNORE_DUP_KEY=OFF,ALLOW_ROW_LOCKS=ON,ALLOW_PAGE_LOCKS=ON)ON [PRIMARY]  
)ON [PRIMARY]  
  
GO 


DECLARE @StoredProcedureName VARCHAR(MAX), @Query VARCHAR(MAX) 
SELECT @StoredProcedureName = 'UspGetContacts'

IF EXISTS (SELECT * FROM sys.procedures WHERE name like @StoredProcedureName)
BEGIN
SET @query = 'DROP PROC ' + @StoredProcedureName
EXEC (@query)
END
Go
CREATE PROCEDURE [dbo].[UspGetContacts]  
   AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    SET NOCOUNT ON;  
-- Select statements for procedure here  
  
   
        SELECT * FROM [dbo].[tblContact]  
        ORDER BY ContactId DESC  
      
        
  
END

GO

DECLARE @StoredProcedureName VARCHAR(MAX), @Query VARCHAR(MAX) 
SELECT @StoredProcedureName = 'UspCreateContact'

IF EXISTS (SELECT * FROM sys.procedures WHERE name like @StoredProcedureName)
BEGIN
SET @query = 'DROP PROC ' + @StoredProcedureName
EXEC (@query)
END
Go
CREATE PROCEDURE [dbo].[UspCreateContact]  
    -- Add the parameters for the stored procedure here  
(  
     @ContactName  NVarchar(50)  
    ,@ContactEmail NVarchar(50)  
    ,@ContactCity NVarchar(256)  
    ,@ContactPhone  NVarchar(50)  
)  
AS  
BEGIN  
    ---- SET NOCOUNT ON added to prevent extra result sets from  
    SET NOCOUNT ON;  
  
    ---- Try Catch--  
    BEGIN TRY  
        BEGIN TRANSACTION  
  
       
  
        -- Insert statements for procedure here  
        INSERT INTO [dbo].[tblContact]([ContactName],[ContactEmail],[ContactCity],[ContactPhone])  
        VALUES(@ContactName,@ContactEmail,@ContactCity,@ContactPhone)  
        SELECT 1  
        COMMIT TRANSACTION  
    END TRY  
    BEGIN CATCH  
            DECLARE @ErrorMessage NVARCHAR(4000),@ErrorSeverity INT,@ErrorState INT;  
            SELECT @ErrorMessage =ERROR_MESSAGE(),@ErrorSeverity =ERROR_SEVERITY(),@ErrorState =ERROR_STATE();  
            RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);  
        ROLLBACK TRANSACTION  
    END CATCH  
  
END  

GO

DECLARE @StoredProcedureName VARCHAR(MAX), @Query VARCHAR(MAX) 
SELECT @StoredProcedureName = 'UspUpdateContact'

IF EXISTS (SELECT * FROM sys.procedures WHERE name like @StoredProcedureName)
BEGIN
SET @query = 'DROP PROC ' + @StoredProcedureName
EXEC (@query)
END

Go

CREATE PROCEDURE [dbo].[UspUpdateContact]  
    -- Add the parameters for the stored procedure here  
     @ContactId BIGINT  
    ,@ContactName NVarchar(50)  
    ,@ContactEmail NVarchar(50)  
    ,@ContactCity NVarchar(256)  
    ,@ContactPhone  NVarchar(50)  
AS  
BEGIN  
    ---- SET NOCOUNT ON added to prevent extra result sets from  
    SET NOCOUNT ON;  
  
    ---- Try Catch--  
    BEGIN TRY  
        BEGIN TRANSACTION  
  
        -- Update statements for procedure here  
        UPDATE [dbo].[tblContact]  
        SET [ContactName] = @ContactName,  
            [ContactCity] = @ContactCity,  
            [ContactPhone] = @ContactPhone,
			[ContactEmail] = @ContactEmail
        WHERE [ContactId] = @ContactId
        SELECT 1  
        COMMIT TRANSACTION  
    END TRY  
    BEGIN CATCH  
            DECLARE @ErrorMessage NVARCHAR(4000),@ErrorSeverity INT,@ErrorState INT;  
            SELECT @ErrorMessage =ERROR_MESSAGE(),@ErrorSeverity =ERROR_SEVERITY(),@ErrorState =ERROR_STATE();  
            RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);  
        ROLLBACK TRANSACTION  
    END CATCH  
  
END

Go

DECLARE @StoredProcedureName VARCHAR(MAX), @Query VARCHAR(MAX) 
SELECT @StoredProcedureName = 'UspDeleteContact'

IF EXISTS (SELECT * FROM sys.procedures WHERE name like @StoredProcedureName)
BEGIN
SET @query = 'DROP PROC ' + @StoredProcedureName
EXEC (@query)
END

Go

CREATE PROCEDURE [dbo].[UspDeleteContact]  
    -- Add the parameters for the stored procedure here  
      @ContactId BIGINT  
AS  
BEGIN  
    ---- SET NOCOUNT ON added to prevent extra result sets from  
    SET NOCOUNT ON;  
  
    ---- Try Catch--  
    BEGIN TRY  
        BEGIN TRANSACTION  
  
        -- Delete statements for procedure here  
        DELETE [dbo].[tblContact]  
        WHERE [ContactId] = @ContactId   
        SELECT 1  
        COMMITTRANSACTION  
    END TRY  
    BEGIN CATCH  
            DECLARE @ErrorMessage NVARCHAR(4000),@ErrorSeverity INT,@ErrorState INT;  
            SELECT @ErrorMessage =ERROR_MESSAGE(),@ErrorSeverity =ERROR_SEVERITY(),@ErrorState =ERROR_STATE();  
            RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);  
        ROLLBACK TRANSACTION  
    END CATCH  
  
END
Go

DECLARE @StoredProcedureName VARCHAR(MAX), @Query VARCHAR(MAX) 
SELECT @StoredProcedureName = 'uspGetContactDetails'

IF EXISTS (SELECT * FROM sys.procedures WHERE name like @StoredProcedureName)
BEGIN
SET @query = 'DROP PROC ' + @StoredProcedureName
EXEC (@query)
END

Go

CREATE PROCEDURE [dbo].[uspGetContactDetails]  
    -- Add the parameters for the stored procedure here  
    @ContactId BIGINT  
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    SET NOCOUNT ON;  
-- Select statements for procedure here  
  
    SELECT*FROM [dbo].[tblContact]  
    WHERE [ContactId] = @ContactId   
END
Go