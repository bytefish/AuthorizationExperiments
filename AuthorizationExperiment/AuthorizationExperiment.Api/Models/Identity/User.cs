// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace AuthorizationExperiment.Api.Models.Identity
{
    /// <summary>
    /// A User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Full Name.
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Preferred Name.
        /// </summary>
        public string PreferredName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Is Permitted To Logon.
        /// </summary>
        public bool IsPermittedToLogon { get; set; }

        /// <summary>
        /// Gets or sets the Logon Name.
        /// </summary>
        public string? LogonName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Hashed Password.
        /// </summary>
        public string? HashedPassword { get; set; } = null!;

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
