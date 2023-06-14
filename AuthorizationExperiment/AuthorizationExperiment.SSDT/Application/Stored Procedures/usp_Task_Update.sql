CREATE PROCEDURE [Application].[usp_Task_Update]
    @TaskID                 INT,
    @Title                  NVARCHAR(50),
    @Description            NVARCHAR(2000),
    @DueDateTime            DATETIME2(7),
    @ReminderDateTime       DATETIME2(7),
    @CompletedDateTime      DATETIME2(7),
    @AssignedTo             INT,
    @TaskPriorityID         INT,
    @TaskStatusID           INT,
    @LastEditedBy           INT,
    @RowVersion             VARBINARY(8)
AS
BEGIN TRY
BEGIN TRANSACTION
    SET NOCOUNT ON;

    -- The Task for the UPDATE needs to exist
    IF (SELECT 1 FROM [Application].[Task] WHERE [TaskID] = @TaskID) IS NULL
        THROW 60000, N'No Task found', 16;

    -- The User for the LastEditedBy audit has to exist
    IF (SELECT 1 FROM [Identity].[User] WHERE [UserID] = @LastEditedBy) IS NULL
        THROW 50000, N'No User found', 16;

    -- If the Task should be assigned to a User, the user has to exist
    IF @AssignedTo IS NOT NULL AND (SELECT 1 FROM [Identity].[User] WHERE [UserID] = @AssignedTo) IS NULL
        THROW 50000, N'No User found', 16;

    -- Required: Title
    IF @Title IS NULL
        THROW 60000, N'Title is required', 16;

    -- Required: Description
    IF @Description IS NULL
        THROW 60000, N'Description is required', 16;
        
    IF (@ReminderDateTime > @DueDateTime)
        THROW 60000, 'The Reminder Date must be before the Due Date', 16;

    -- Updates the given Task. We expect the Authentication and Authorization 
    -- to be defined by the Application Layer, so we won't check it here.
    UPDATE 
        [Application].[Task]
    SET
        [Title] = @Title, 
        [Description] = @Description,
        [DueDateTime] = @DueDateTime,
        [ReminderDateTime] = @ReminderDateTime,
        [CompletedDateTime] = @CompletedDateTime,
        [AssignedTo] = @AssignedTo,
        [TaskPriorityID] = @TaskPriorityID,
        [TaskStatusID] = @TaskStatusID,
        [LastEditedBy] = @LastEditedBy
    OUTPUT
       inserted.*
    WHERE 
        [TaskID] = @TaskID AND [RowVersion] = @RowVersion;

    -- We expected the UPDATE to affect at least one row. This most likely happens due 
    -- to a mismatch with the supplied Row Version. The data has been edited by a different 
    -- user and the caller needs to react.
    IF @@ROWCOUNT = 0 
        THROW 99999, N'The row has been modified by a different user', 16;

COMMIT TRANSACTION
END TRY
BEGIN CATCH
    IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN;

    THROW;
END CATCH
