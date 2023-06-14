CREATE PROCEDURE [Application].[usp_Task_Create]
    @Title                  NVARCHAR(50),
    @Description            NVARCHAR(2000),
    @DueDateTime            DATETIME2(7),
    @ReminderDateTime       DATETIME2(7),
    @AssignedTo             INT,
    @TaskPriorityID         INT,
    @TaskStatusID           INT,
    @UserID                 INT
AS
BEGIN TRY
BEGIN TRANSACTION
    SET NOCOUNT ON;

    IF @Title IS NULL
        THROW 50000, N'Title is required', 16;

    IF @Description IS NULL
        THROW 50000, N'Description is required', 16;

    IF @UserID IS NULL
        THROW 50000, N'UserID is required', 16;

    IF (SELECT 1 FROM [Identity].[User] WHERE [UserID] = @UserID) IS NULL
        THROW 50000, N'User for UserID was not found', 16;

    IF (@ReminderDateTime > @DueDateTime)
        THROW 50000, 'The Reminder Date must be before the Due Date', 16;

    IF @AssignedTo IS NOT NULL AND (SELECT 1 FROM [Identity].[User] WHERE [UserID] = @AssignedTo) IS NULL
        THROW 50000, N'User for Task Assignment was not found', 16;

    IF (SELECT 1 FROM [Application].[TaskPriority] WHERE [TaskPriorityID] = @TaskPriorityID) IS NULL
        THROW 50000, N'No TaskPriority with the given ID found', 16;
    
    IF (SELECT 1 FROM [Application].[TaskStatus] WHERE [TaskStatusID] = @TaskStatusID) IS NULL
        THROW 50000, N'No TaskStatus with the given ID found', 16;

    -- Inserts a given Task. We expect the Authentication and Authorization 
    -- to be defined by the Application Layer, so we won't check it here.
    INSERT INTO 
        [Application].[Task]([Title], [Description], [DueDateTime], [ReminderDateTime], [AssignedTo], [TaskPriorityID], [TaskStatusID], [LastEditedBy])
    OUTPUT 
        inserted.*
    VALUES
        (@Title, @Description, @DueDateTime, @ReminderDateTime, @AssignedTo, @TaskPriorityID, @TaskStatusID, @UserID);

COMMIT TRANSACTION
END TRY
BEGIN CATCH
    IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN;

    THROW;
END CATCH
