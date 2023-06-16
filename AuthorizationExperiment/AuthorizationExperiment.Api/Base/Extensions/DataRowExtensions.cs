// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Data;

namespace AuthorizationExperiment.Api.Base.Extensions
{
    /// <summary>
    /// Extension methods on a <see cref="DataRow"/> to handle nullable and 
    /// not nullable fields in a safe way.
    /// </summary>
    public static class DataRowExtensions
    {
        #region Generic

        public static T GetField<T>(DataRow row, string columnName)
        {
            var value = row.Field<T>(columnName);

            if(value == null)
            {
                throw new Exception($"Column '{columnName}' is null");
            }

            return value;
        }

        public static T? GetNullableField<T>(DataRow row, string columnName)
        {
            return row.Field<T>(columnName);
        }

        #endregion Generic

        #region Binary

        /// <summary>
        /// Returns a <see cref="byte[]"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a byte array</returns>
        public static byte[] GetByteArray(this DataRow row, string columnName)
        {
            var value = GetField<object>(row, columnName);

            return (byte[])value;
        }

        /// <summary>
        /// Returns a <see cref="byte[]"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a byte array</returns>
        public static byte[]? GetNullableByteArray(this DataRow row, string columnName)
        {
            var value = GetNullableField<object?>(row, columnName);

            if(value == null )
            {
                return null;
            }

            return (byte[])value;
        }


        #endregion Binary

        #region Boolean

        /// <summary>
        /// Returns the <see cref="bool"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="bool"/></returns>
        public static bool GetBool(this DataRow row, string columnName)
        {
            return GetField<bool>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="bool"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="bool"/></returns>
        public static bool? GetNullableBool(this DataRow row, string columnName)
        {
            return GetNullableField<bool?>(row, columnName);
        }

        #endregion Boolean

        #region Temporal


        /// <summary>
        /// Returns the <see cref="DateTimeOffset"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="DateTimeOffset"/></returns>
        public static DateTimeOffset GetDateTimeOffset(this DataRow row, string columnName)
        {
            return GetField<DateTimeOffset>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="DateTimeOffset"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="DateTimeOffset"/></returns>
        public static DateTimeOffset? GetNullableDateTimeOffset(this DataRow row, string columnName)
        {
            return GetNullableField<DateTimeOffset?>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="DateTime"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="DateTime"/></returns>
        public static DateTime GetDateTime(this DataRow row, string columnName)
        {
            return GetField<DateTime>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="DateTime"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="DateTime"/></returns>
        public static DateTime? GetNullableDateTime(this DataRow row, string columnName)
        {
            return GetNullableField<DateTime?>(row, columnName);
        }

        #endregion Temporal

        #region Numeric

        /// <summary>
        /// Returns the <see cref="byte"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="byte"/></returns>
        public static byte GetByte(this DataRow row, string columnName)
        {
            return GetField<byte>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="byte"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="byte"/></returns>
        public static byte? GetNullableByte(this DataRow row, string columnName)
        {
            return GetNullableField<byte?>(row, columnName);
        }


        /// <summary>
        /// Returns the <see cref="short"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="short"/></returns>
        public static short GetInt16(this DataRow row, string columnName)
        {
            return GetField<short>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="short"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="short"/></returns>
        public static short? GetNullableInt16(this DataRow row, string columnName)
        {
            return GetNullableField<short?>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="int"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="int"/></returns>
        public static int GetInt32(this DataRow row, string columnName)
        {
            return GetField<int>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="int"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="int"/></returns>
        public static int? GetNullableInt32(this DataRow row, string columnName)
        {
            return GetNullableField<int?>(row, columnName);
        }


        /// <summary>
        /// Returns the <see cref="long"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="int"/></returns>
        public static long GetInt64(this DataRow row, string columnName)
        {
            return GetField<long>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="long"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="int"/></returns>
        public static long? GetNullableInt64(this DataRow row, string columnName)
        {
            return GetNullableField<long?>(row, columnName);
        }


        /// <summary>
        /// Returns the <see cref="decimal"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="int"/></returns>
        public static decimal GetDecimal(this DataRow row, string columnName)
        {
            return GetField<decimal>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="decimal"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="int"/></returns>
        public static decimal? GetNullableDecimal(this DataRow row, string columnName)
        {
            return GetNullableField<decimal?>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="float"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="int"/></returns>
        public static float GetSingle(this DataRow row, string columnName)
        {
            return GetField<float>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="float"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="int"/></returns>
        public static float? GetNullableSingle(this DataRow row, string columnName)
        {
            return GetNullableField<float?>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="double"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="int"/></returns>
        public static float GetDouble(this DataRow row, string columnName)
        {
            return GetField<float>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="float"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="int"/></returns>
        public static float? GetNullableDouble(this DataRow row, string columnName)
        {
            return GetNullableField<float?>(row, columnName);
        }


        #endregion Numeric

        #region Text
        /// <summary>
        /// Returns the <see cref="char"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="char"/></returns>
        public static char GetChar(this DataRow row, string columnName)
        {
            return GetField<char>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="char"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="char"/></returns>
        public static char? GetNullableChar(this DataRow row, string columnName)
        {
            return GetNullableField<char?>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="string"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a <see cref="string"/></returns>
        public static string GetString(this DataRow row, string columnName)
        {
            return GetField<string>(row, columnName);
        }

        /// <summary>
        /// Returns the <see cref="string"/> or <see cref="null"/> for a given column.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with the given column</param>
        /// <param name="columnName">Column name</param>
        /// <returns>The column value as a nullable <see cref="string"/></returns>
        public static string? GetNullableString(this DataRow row, string columnName)
        {
            return GetNullableField<string?>(row, columnName);
        }

        #endregion Text
    }
}
