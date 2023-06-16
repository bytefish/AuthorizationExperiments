// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthorizationExperiment.Api.Base.Query
{
    /// <summary>
    /// SQL Server Extensions for the <see cref="SqlQuery"/>.
    /// </summary>
    public static class SqlQueryExtensions
    {
        /// <summary>
        /// Sets the Command Text for the <see cref="SqlQuery"/>.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static SqlQuery Sql(this SqlQuery query, string commandText, int commandTimeOutInSeconds = 60)
        {
            var cmd = new SqlCommand()
            {
                CommandText = commandText,
                CommandType = CommandType.Text,
                CommandTimeout = commandTimeOutInSeconds
            };

            return query.SetCommand(cmd);
        }

        /// <summary>
        /// Sets the Command Text for the <see cref="SqlQuery"/>.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static SqlQuery Proc(this SqlQuery query, string storedProcedureName, int commandTimeOutInSeconds = 60)
        {
            var cmd = new SqlCommand()
            {
                CommandText = storedProcedureName,
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = commandTimeOutInSeconds
            };

            return query.SetCommand(cmd);
        }

        /// <summary>
        /// Add a parameter with specified value to the mapper.
        /// </summary>
        /// <param name="mapper">Mapper where the parameter will be added.</param>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="value">Value of the parameter.</param>
        /// <returns>Mapper object.</returns>
        public static SqlQuery Param(this SqlQuery query, string name, object? value)
        {
            if (value == null)
            {
                value = DBNull.Value;
            }

            if (query.Command is SqlCommand command)
            {
                var p = command.Parameters.AddWithValue(name, value);

                if (p.SqlDbType == SqlDbType.NVarChar
                    || p.SqlDbType == SqlDbType.VarChar)
                {
                    p.Size = 100 * (value.ToString()!.Length / 100 + 1);
                }
            }

            return query;
        }
    }
}
