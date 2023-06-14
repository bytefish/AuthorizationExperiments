CREATE PROCEDURE [Application].[usp_TemporalTables_DeactivateTemporalTables]
AS BEGIN
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[TaskStatus]'), 'TableTemporalType') = 2
    BEGIN
	    PRINT 'Deactivate Temporal Table for [Application].[TaskStatus]'

	    ALTER TABLE [Application].[TaskStatus] SET (SYSTEM_VERSIONING = OFF);
	    ALTER TABLE [Application].[TaskStatus] DROP PERIOD FOR SYSTEM_TIME;
    END

    IF OBJECTPROPERTY(OBJECT_ID('[Application].[TaskPriority]'), 'TableTemporalType') = 2
    BEGIN
	    PRINT 'Deactivate Temporal Table for [Application].[TaskPriority]'

	    ALTER TABLE [Application].[TaskPriority] SET (SYSTEM_VERSIONING = OFF);
	    ALTER TABLE [Application].[TaskPriority] DROP PERIOD FOR SYSTEM_TIME;
    END 
    
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[Task]'), 'TableTemporalType') = 2
    BEGIN
	    PRINT 'Deactivate Temporal Table for [Application].[Task]'

	    ALTER TABLE [Application].[Task] SET (SYSTEM_VERSIONING = OFF);
	    ALTER TABLE [Application].[Task] DROP PERIOD FOR SYSTEM_TIME;
    END 
END