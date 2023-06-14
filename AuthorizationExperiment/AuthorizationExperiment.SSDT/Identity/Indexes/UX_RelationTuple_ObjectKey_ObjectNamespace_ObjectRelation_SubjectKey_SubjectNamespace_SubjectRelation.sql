CREATE UNIQUE INDEX [UX_RelationTuple_ObjectKey_ObjectNamespace_ObjectRelation_SubjectKey_SubjectNamespace_SubjectRelation] ON [Identity].[RelationTuple] 
(
     [ObjectKey]       
    ,[ObjectNamespace] 
    ,[ObjectRelation]  
    ,[SubjectKey]      
    ,[SubjectNamespace]
    ,[SubjectRelation] 
)