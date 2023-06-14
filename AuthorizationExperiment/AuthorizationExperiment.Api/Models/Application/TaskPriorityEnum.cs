// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AuthorizationExperiment.Api.Models.Application
{
    /// <summary>
    /// The Priority of a Task, such as Low, Normal, High.
    /// </summary>
    public enum TaskPriorityEnum
    {
        /// <summary>
        /// No Priority.
        /// </summary>
        None = 0,

        /// <summary>
        /// Low Priority.
        /// </summary>
        Low = 1,

        /// <summary>
        /// Normal Priority.
        /// </summary>
        Normal = 2,

        /// <summary>
        /// High Priority.
        /// </summary>
        High = 3,
    }
}
