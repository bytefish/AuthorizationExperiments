CREATE UNIQUE INDEX [UX_RelationTuple_UniqueTuple] ON [Identity].[RelationTuple] 
(
     [ObjectKey]       
    ,[ObjectNamespace] 
    ,[ObjectRelation]  
    ,[SubjectKey]      
    ,[SubjectNamespace]
    ,[SubjectRelation] 
)