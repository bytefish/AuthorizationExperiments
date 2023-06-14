// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AuthorizationExperiment.Api.Models.Application
{
    /// <summary>
    /// A Task to be processed.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Priority.
        /// </summary>
        public TaskPriorityEnum TaskPriority { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        public TaskStatusEnum TaskStatus { get; set; }

        /// <summary>
        /// Gets or sets the Due Date.
        /// </summary>
        public DateTime? DueDateTime { get; set; }

        /// <summary>
        /// Gets or sets the Reminder Date.
        /// </summary>
        public DateTime? ReminderDateTime { get; set; }

        /// <summary>
        /// Gets or sets the Completed Date.
        /// </summary>
        public DateTime? CompletedDateTime { get; set; }

        /// <summary>
        /// Gets or sets Assigned To.
        /// </summary>
        public int? AssignedTo { get; set; }

        /// <summary>
        /// Gets or sets the Row Version.
        /// </summary>
        public byte[] RowVersion { get; set; } = null!;

        /// <summary>
        /// Gets or sets Last Edited By.
        /// </summary>
        public int LastEditedBy { get; set; }

        /// <summary>
        /// Gets or sets Valid From.
        /// </summary>
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Gets or sets Valid To.
        /// </summary>
        public DateTime ValidTo { get; set; }
    }
}
