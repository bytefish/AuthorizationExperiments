PRINT 'Inserting [Application].[TaskPriority] ...'

-----------------------------------------------
-- Global Parameters
-----------------------------------------------
DECLARE @ValidFrom datetime2(7) = '20130101'
DECLARE @ValidTo datetime2(7) =  '99991231 23:59:59.9999999'

-----------------------------------------------
-- [Application].[TaskPriority]
-----------------------------------------------
MERGE INTO [Application].[TaskPriority] AS [Target]
USING (VALUES 
			  (1, 'Low', 1, @ValidFrom, @ValidTo)
			, (2, 'Normal', 1, @ValidFrom, @ValidTo)
			, (3, 'High', 1, @ValidFrom, @ValidTo)
		) AS [Source]([TaskPriorityID], [Name], [LastEditedBy], [ValidFrom], [ValidTo])
ON ([Target].[TaskPriorityID] = [Source].[TaskPriorityID])
WHEN NOT MATCHED BY TARGET THEN
	INSERT 
		([TaskPriorityID], [Name], [LastEditedBy], [ValidFrom], [ValidTo]) 
	VALUES 
		([Source].[TaskPriorityID], [Source].[Name], [Source].[LastEditedBy], [Source].[ValidFrom], [Source].[ValidTo]);

