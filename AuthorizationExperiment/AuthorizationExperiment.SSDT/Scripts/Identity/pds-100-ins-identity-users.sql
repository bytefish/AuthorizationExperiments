PRINT 'Inserting [Identity].[User] ...'

-----------------------------------------------
-- Global Parameters
-----------------------------------------------
DECLARE @ValidFrom datetime2(7) = '20130101'
DECLARE @ValidTo datetime2(7) =  '99991231 23:59:59.9999999'

-----------------------------------------------
-- [Identity].[User]
-----------------------------------------------
MERGE INTO [Identity].[User] AS [Target]
USING (VALUES 
     (1, 'Data Conversion Only', 'Data Conversion Only', 0, NULL, NULL, 1, @ValidFrom, @ValidTo)
    ,(2, 'Philipp Wagner', 'Philipp Wagner', 0, NULL, NULL, 1, @ValidFrom, @ValidTo)
    ,(3, 'Hannes Wolf ', 'Hannes Wolf', 0, NULL, NULL, 1, @ValidFrom, @ValidTo)
    ,(4, 'Alexander Meier', 'Alex Meier', 0, NULL, NULL, 1, @ValidFrom, @ValidTo)
) AS [Source]([UserID], [FullName], [PreferredName], [IsPermittedToLogon], [LogonName], [HashedPassword], [LastEditedBy], [ValidFrom], [ValidTo])
ON ([Target].[UserID] = [Source].[UserID])
WHEN NOT MATCHED BY TARGET THEN
    INSERT 
        ([UserID], [FullName], [PreferredName], [IsPermittedToLogon], [LogonName], [HashedPassword], [LastEditedBy], [ValidFrom], [ValidTo])
    VALUES 
        ([Source].[UserID], [Source].[FullName], [Source].[PreferredName], [Source].[IsPermittedToLogon], [Source].[LogonName], [Source].[HashedPassword], [Source].[LastEditedBy], [Source].[ValidFrom], [Source].[ValidTo]);
