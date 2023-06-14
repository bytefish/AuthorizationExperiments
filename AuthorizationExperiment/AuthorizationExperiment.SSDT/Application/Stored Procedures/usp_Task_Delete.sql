CREATE PROCEDURE [Application].[usp_Task_Delete]
     @TaskID INT
    ,@UserID INT
AS
BEGIN TRY
BEGIN TRANSACTION
    SET NOCOUNT ON;

    IF @TaskID IS NULL
        THROW 50000, N'TaskID is required', 16;

    IF @UserID IS NULL
        THROW 50000, N'UserID is required', 16;

    IF (SELECT 1 FROM [Identity].[User] WHERE [UserID] = @UserID) IS NULL
        THROW 50000, N'User for UserID was not found', 16;

    IF (SELECT 1 FROM [Application].[Task] WHERE [TaskID] = @TaskID) IS NULL
        THROW 50000, N'Task for TaskID was not found', 16;

    IF (SELECT [Identity].[udf_RelationTuples_Check]('task', @TaskID, 'owner', 'user', @UserID)) = 0
        THROW 50000, 'Insufficient Permissions', 16

    DELETE FROM
        [Application].[Task]
    WHERE 
        [TaskID] = @TaskID;

    IF @@ROWCOUNT = 0 
        THROW 99999, N'The row has been modified by a different user', 16;

COMMIT TRANSACTION
END TRY
BEGIN CATCH
    IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN;

    THROW;
END CATCH
