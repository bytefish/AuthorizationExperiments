PRINT 'Inserting [Application].[TaskStatus] ...'

-----------------------------------------------
-- Global Parameters
-----------------------------------------------
DECLARE @ValidFrom datetime2(7) = '20130101'
DECLARE @ValidTo datetime2(7) =  '99991231 23:59:59.9999999'

-----------------------------------------------
-- [Application].[TaskStatus]
-----------------------------------------------
MERGE INTO [Application].[TaskStatus] AS [Target]
USING (VALUES 
			  (1, 'Not Started', 1, @ValidFrom, @ValidTo)
			, (2, 'In Progress', 1, @ValidFrom, @ValidTo)
			, (3, 'Completed', 1, @ValidFrom, @ValidTo)
			, (4, 'Waiting On Others', 1, @ValidFrom, @ValidTo)
			, (5, 'Deferred', 1, @ValidFrom, @ValidTo)
		) AS [Source]([TaskStatusID], [Name], [LastEditedBy], [ValidFrom], [ValidTo])
ON ([Target].[TaskStatusID] = [Source].[TaskStatusID])
WHEN NOT MATCHED BY TARGET THEN
	INSERT 
		([TaskStatusID], [Name], [LastEditedBy], [ValidFrom], [ValidTo])
	VALUES 
		([Source].[TaskStatusID], [Source].[Name], [Source].[LastEditedBy], [Source].[ValidFrom], [Source].[ValidTo]);
