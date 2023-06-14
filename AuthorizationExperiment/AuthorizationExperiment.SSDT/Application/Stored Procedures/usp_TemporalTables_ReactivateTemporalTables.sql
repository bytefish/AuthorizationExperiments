CREATE PROCEDURE [Application].[usp_TemporalTables_ReactivateTemporalTables]
AS BEGIN
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[TaskStatus]'), 'TableTemporalType') = 0
    BEGIN
	    PRINT 'Reactivate Temporal Table for [Application].[TaskStatus]'

	    ALTER TABLE [Application].[TaskStatus] ADD PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo]);
	    ALTER TABLE [Application].[TaskStatus] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[TaskStatusHistory], DATA_CONSISTENCY_CHECK = ON));
    END

    IF OBJECTPROPERTY(OBJECT_ID('[Application].[TaskPriority]'), 'TableTemporalType') = 0
    BEGIN
	    PRINT 'Reactivate Temporal Table for [Application].[TaskPriority]'

	    ALTER TABLE [Application].[TaskPriority] ADD PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo]);
	    ALTER TABLE [Application].[TaskPriority] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[TaskPriorityHistory], DATA_CONSISTENCY_CHECK = ON));
    END
    
    IF OBJECTPROPERTY(OBJECT_ID('[Application].[Task]'), 'TableTemporalType') = 0
    BEGIN
	    PRINT 'Reactivate Temporal Table for [Application].[Task]'

	    ALTER TABLE [Application].[Task] ADD PERIOD FOR SYSTEM_TIME([ValidFrom], [ValidTo]);
	    ALTER TABLE [Application].[Task] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Application].[TaskHistory], DATA_CONSISTENCY_CHECK = ON));
    END
END