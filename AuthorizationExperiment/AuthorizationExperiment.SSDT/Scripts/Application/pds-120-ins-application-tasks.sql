PRINT 'Inserting [Application].[Task] ...'

-----------------------------------------------
-- Global Parameters
-----------------------------------------------
DECLARE @ValidFrom datetime2(7) = '20130101'
DECLARE @ValidTo datetime2(7) =  '99991231 23:59:59.9999999'

-----------------------------------------------
-- [Application].[Task]
-----------------------------------------------
MERGE INTO [Application].[Task] AS [Target]
USING (VALUES 
     (323, 'Task #323', 'Description for Task #323', NULL, NULL, NULL, NULL, 2, 1, 1, @ValidFrom, @ValidTo)
    ,(152, 'Task #152', 'Description for Task #152', NULL, NULL, NULL, NULL, 3, 1, 1, @ValidFrom, @ValidTo)
) AS [Source] ([TaskID], [Title], [Description], [DueDateTime], [ReminderDateTime], [CompletedDateTime],[AssignedTo], [TaskPriorityID], [TaskStatusID], [LastEditedBy], [ValidFrom], [ValidTo])
ON ([Target].[TaskID] = [Source].[TaskID])
WHEN NOT MATCHED BY TARGET THEN
	INSERT 
		([TaskID], [Title], [Description], [DueDateTime], [ReminderDateTime], [CompletedDateTime],[AssignedTo], [TaskPriorityID], [TaskStatusID], [LastEditedBy], [ValidFrom], [ValidTo])
	VALUES 
		([Source].[TaskID], [Source].[Title], [Source].[Description], [Source].[DueDateTime], [Source].[ReminderDateTime], [Source].[CompletedDateTime],[Source].[AssignedTo], [Source].[TaskPriorityID], [Source].[TaskStatusID], [Source].[LastEditedBy], [Source].[ValidFrom], [Source].[ValidTo]);
