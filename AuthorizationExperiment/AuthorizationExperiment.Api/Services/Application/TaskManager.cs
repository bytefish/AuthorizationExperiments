using AuthorizationExperiment.Api.Base.Connections;
using AuthorizationExperiment.Api.Base.Extensions;
using AuthorizationExperiment.Api.Base.Query;
using System.Data;
using System.Data.Common;

namespace AuthorizationExperiment.Api.Services.Application
{
    public class TaskManager
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public TaskManager(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task CreateTaskAsync(Models.Application.Task task, int userId, CancellationToken cancellationToken)
        {
            using (var connection = await _connectionFactory.GetDbConnectionAsync(cancellationToken).ConfigureAwait(false))
            {
                var query = new SqlQuery(connection).Proc("[Application].[usp_Task_Create]")
                    .Param("Title", task.Title)
                    .Param("Description", task.Description)
                    .Param("AssignedTo", task.AssignedTo)
                    .Param("DueDateTime", task.DueDateTime)
                    .Param("ReminderDateTime", task.ReminderDateTime)
                    .Param("TaskPriorityID", (int)task.TaskPriority)
                    .Param("TaskStatusID", (int)task.TaskStatus)
                    .Param("UserID", userId);

                var results = await query
                    .ExecuteDataTableAsync(cancellationToken)
                    .ConfigureAwait(false);

                if (results.Rows.Count != 1)
                {
                    throw new Exception($"Expected '1' row, but got '{results.Rows.Count}'");
                }

                ConvertTask(results.Rows[0], task);
            }
        }

        public async Task<Models.Application.Task?> ReadTaskAsync(int taskId, int userId, CancellationToken cancellationToken)
        {
            using (var connection = await _connectionFactory.GetDbConnectionAsync(cancellationToken).ConfigureAwait(false))
            {
                var query = new SqlQuery(connection).Proc("[Application].[usp_Task_Read]")
                    .Param("TaskID", taskId)
                    .Param("UserID", userId);

                var results = await query
                    .ExecuteDataTableAsync(cancellationToken)
                    .ConfigureAwait(false);

                if (results.Rows.Count != 1)
                {
                    throw new Exception($"Expected '1' row, but got '{results.Rows.Count}'");
                }

                var task = new Models.Application.Task();

                ConvertTask(results.Rows[0], task);

                return task;
            }
        }

        public async Task<List<Models.Application.Task>> ReadTasksAsync(int userId, CancellationToken cancellationToken)
        {
            using (var connection = await _connectionFactory.GetDbConnectionAsync(cancellationToken).ConfigureAwait(false))
            {
                var query = new SqlQuery(connection).Proc("[Application].[usp_Tasks_Read]")
                    .Param("UserID", userId);

                var results = await query
                    .ExecuteDataTableAsync(cancellationToken)
                    .ConfigureAwait(false);

                var tasks = new List<Models.Application.Task>();

                foreach (DataRow row in results.Rows)
                {
                    var task = new Models.Application.Task();

                    ConvertTask(row, task);

                    tasks.Add(task);
                }

                return tasks;
            }
        }

        public async Task UpdateTaskAsync(Models.Application.Task task, int lastEditedBy, CancellationToken cancellationToken)
        {
            using (var connection = await _connectionFactory.GetDbConnectionAsync(cancellationToken).ConfigureAwait(false))
            {
                var query = new SqlQuery(connection).Proc("[Application].[usp_Task_Update]")
                    .Param("TaskID", task.Id)
                    .Param("Title", task.Title)
                    .Param("Description", task.Description)
                    .Param("AssignedTo", task.AssignedTo)
                    .Param("DueDateTime", task.DueDateTime)
                    .Param("ReminderDateTime", task.ReminderDateTime)
                    .Param("CompletedDateTime", task.CompletedDateTime)
                    .Param("TaskPriorityID", (int)task.TaskPriority)
                    .Param("TaskStatusID", (int)task.TaskStatus)
                    .Param("RowVersion", task.RowVersion)
                    .Param("UserID", lastEditedBy);

                var results = await query
                    .ExecuteDataTableAsync(cancellationToken)
                    .ConfigureAwait(false);

                if (results.Rows.Count != 1)
                {
                    throw new Exception($"Expected '1' row, but got '{results.Rows.Count}'");
                }

                ConvertTask(results.Rows[0], task);
            }
        }

        public async Task<int> DeleteTaskAsync(int taskId, int userId, CancellationToken cancellationToken)
        {
            using (var connection = await _connectionFactory.GetDbConnectionAsync(cancellationToken).ConfigureAwait(false))
            {
                var query = new SqlQuery(connection).Proc("[Application].[usp_Task_Delete]")
                    .Param("TaskID", taskId)
                    .Param("UserID", userId);

                int numberOfRowsAffected = await query.ExecuteNonQueryAsync(cancellationToken);

                if (numberOfRowsAffected != 1)
                {
                    throw new Exception($"Query affected '{numberOfRowsAffected}', but expected '1'");
                }

                return numberOfRowsAffected;
            }
        }

        private static void ConvertTask(DataRow row, Models.Application.Task task)
        {
            task.Id = row.GetInt32("TaskID");
            task.Title = row.GetString("Title");
            task.Description = row.GetString("Description");
            task.TaskPriority = (Models.Application.TaskPriorityEnum)row.GetInt32("TaskPriorityID");
            task.TaskStatus = (Models.Application.TaskStatusEnum)row.GetInt32("TaskStatusID");
            task.AssignedTo = row.GetNullableInt32("AssignedTo");
            task.DueDateTime = row.GetNullableDateTime("DueDateTime");
            task.CompletedDateTime = row.GetNullableDateTime("CompletedDateTime");
            task.ReminderDateTime = row.GetNullableDateTime("ReminderDateTime");
            task.RowVersion = row.GetByteArray("RowVersion");
            task.LastEditedBy = row.GetInt32("LastEditedBy");
            task.ValidFrom = row.GetDateTime("ValidFrom");
            task.ValidTo = row.GetDateTime("ValidTo");
        }
    }
}
