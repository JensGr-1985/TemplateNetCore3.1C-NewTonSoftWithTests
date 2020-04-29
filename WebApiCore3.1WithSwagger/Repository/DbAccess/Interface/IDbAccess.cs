using System.Collections.Generic;
using WebApiCore3._1WithSwagger.DbAccess;

namespace WebApiCore3._1WithSwagger.Repository.DbAccess.Interface
{
    /// <summary>
    ///     This is a Wrapper for Dapper
    /// </summary>
    public interface IDbAccess
    {
        /// <summary>
        ///     Executes a SQL and Returns the number of affected rows
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteSql(string sql);

        /// <summary>
        ///     Executes a SQL with given Parameters and Returns the number of affected rows
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams">Parameters</param>
        /// <returns></returns>
        int ExecuteSql(string sql, IEnumerable<SqlParam> sqlParams);

        /// <summary>
        ///     Executes a SQL and returns the the Rows as an IEnumerable of T
        /// </summary>
        /// <typeparam name="T">Class or Struct holding the return rows of the SQL</typeparam>
        /// <param name="sql">The SQL</param>
        /// <returns></returns>
        IEnumerable<T> Query<T>(string sql);

        /// <summary>
        ///     Executes a SQL and returns the the Rows as an IEnumerable of T with the given Parameters
        /// </summary>
        /// <typeparam name="T">Class or Struct holding the return rows of the SQL</typeparam>
        /// <param name="sql">The SQL</param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        IEnumerable<T> Query<T>(string sql, IEnumerable<SqlParam> sqlParams);
    }
}