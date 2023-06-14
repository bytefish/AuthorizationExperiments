CREATE PROCEDURE [Application].[usp_Task_ReadTasks]
    @UserID INT
AS
BEGIN TRY
    SET NOCOUNT ON;
    
    IF @UserID IS NULL
        THROW 50000, N'UserID is required', 16;

    IF (SELECT 1 FROM [Identity].[User] WHERE [UserID] = @UserID) IS NULL
        THROW 50000, N'User for UserID was not found', 16;

    SELECT 
        *
    FROM 
        [Application].[Task] t
            CROSS APPLY [Identity].[tvf_RelationTuples_ListObjects]('task', 'viewer', 'user', @UserID) o
    WHERE
        o.ObjectKey = t.TaskID

END TRY
BEGIN CATCH
    IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN;

    THROW;
END CATCH
