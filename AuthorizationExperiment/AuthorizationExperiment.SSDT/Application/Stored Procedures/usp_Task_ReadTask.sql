CREATE PROCEDURE [Application].[usp_Task_ReadTask]
     @TaskID INT
    ,@UserID INT
AS
BEGIN TRY
    SET NOCOUNT ON;
    
    IF @TaskID IS NULL
        THROW 50000, N'TaskID is required', 16;

    IF @UserID IS NULL
        THROW 50000, N'UserID is required', 16;

    IF (SELECT 1 FROM [Identity].[User] WHERE [UserID] = @UserID) IS NULL
        THROW 50000, N'User for UserID was not found', 16;

    IF (SELECT 1 FROM [Application].[Task] WHERE [TaskID] = @TaskID) IS NULL
        THROW 50000, N'Task for TaskID was not found', 16;

    IF (SELECT [Identity].[udf_RelationTuples_Check]('task', @TaskID, 'viewer', 'user', @UserID)) = 0
        THROW 50000, 'Insufficient Permissions', 16

    SELECT 
        *
    FROM 
        [Application].[Task]
    WHERE
        TaskID = @TaskID;

END TRY
BEGIN CATCH
    IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN;

    THROW;
END CATCH
