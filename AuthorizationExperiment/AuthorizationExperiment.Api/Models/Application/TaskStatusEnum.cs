// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AuthorizationExperiment.Api.Models.Application
{
    /// <summary>
    /// Status of a Task, such as "Assigned", "Completed", ...
    /// </summary>
    public enum TaskStatusEnum
    {
        /// <summary>
        /// No Task Status.
        /// </summary>
        None = 0,

        /// <summary>
        /// Task has not been started.
        /// </summary>
        NotStarted = 1,

        /// <summary>
        /// Task is in progress.
        /// </summary>
        InProgress = 2,
        
        /// <summary>
        /// Task has been completed.
        /// </summary>
        Completed = 3,

        /// <summary>
        /// Task is waiting on others.
        /// </summary>
        WaitingOnOthers = 4,

        /// <summary>
        /// Task has been deferred.
        /// </summary>
        Deferred = 5,
    }
}
