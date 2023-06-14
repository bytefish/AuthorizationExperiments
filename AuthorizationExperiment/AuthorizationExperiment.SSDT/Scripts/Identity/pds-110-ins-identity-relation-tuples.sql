PRINT 'Inserting [Identity].[RelationTuple] ...'

-----------------------------------------------
-- Global Parameters
-----------------------------------------------
DECLARE @ValidFrom datetime2(7) = '20130101'
DECLARE @ValidTo datetime2(7) =  '99991231 23:59:59.9999999'

-----------------------------------------------
-- [Identity].[RelationTuple]
-----------------------------------------------
MERGE INTO [Identity].[RelationTuple] AS [Target]
USING (VALUES 
      (1, 'task', 323, 'owner', 'user',   2, NULL, 1, @ValidFrom, @ValidTo)
     ,(2, 'task', 323, 'viewer', 'org',   1, 'member', 1, @ValidFrom, @ValidTo)
     ,(3, 'task', 152, 'viewer', 'org',   2, 'member', 1, @ValidFrom, @ValidTo)
     ,(4, 'task', 152, 'viewer', 'org',   1, 'member', 1, @ValidFrom, @ValidTo)
     ,(5, 'org',  1,   'member', 'user',  2, NULL, 1, @ValidFrom, @ValidTo)
     ,(6, 'org',  1,   'member', 'user',  3, NULL, 1, @ValidFrom, @ValidTo)
     ,(7, 'org',  2,   'member', 'user',  4, NULL, 1, @ValidFrom, @ValidTo)
) AS [Source]
(
     [RelationTupleID] 
    ,[ObjectNamespace] 
    ,[ObjectKey]       
    ,[ObjectRelation]  
    ,[SubjectNamespace]
    ,[SubjectKey]      
    ,[SubjectRelation] 
    ,[LastEditedBy]    
    ,[ValidFrom]       
    ,[ValidTo]         
)
ON (
    [Target].[RelationTupleID] = [Source].[RelationTupleID]
)
WHEN NOT MATCHED BY TARGET THEN
    INSERT 
        (
             [RelationTupleID]
            ,[ObjectNamespace]
            ,[ObjectKey]
            ,[ObjectRelation]
            ,[SubjectNamespace]
            ,[SubjectKey]
            ,[SubjectRelation]
            ,[LastEditedBy]
            ,[ValidFrom]
            ,[ValidTo]
        )
    VALUES 
        (
             [Source].[RelationTupleID]
            ,[Source].[ObjectNamespace]
            ,[Source].[ObjectKey]
            ,[Source].[ObjectRelation]
            ,[Source].[SubjectNamespace]
            ,[Source].[SubjectKey]
            ,[Source].[SubjectRelation]
            ,[Source].[LastEditedBy]
            ,[Source].[ValidFrom]
            ,[Source].[ValidTo]
        );
