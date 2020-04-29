using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using MySql.Data.MySqlClient;
using WebApiCore3._1WithSwagger.DbAccess;
using WebApiCore3._1WithSwagger.Repository.DbAccess.Interface;

namespace WebApiCore3._1WithSwagger.Repository.DbAccess
{
    public class DbAccess : IDbAccess, IDisposable
    {
        private readonly IDbConnection _connection;
        private readonly string _conString;
        private readonly int _timeOut;

        /// <summary>
        /// </summary>
        /// <param name="conString">The Connectionstring</param>
        /// <param name="connectionType">MsSQL or MySql</param>
        /// <param name="timeOut">timneout in Secounds = 10 </param>
        public DbAccess(string conString, DatabaseType connectionType, int timeOut = 10)
        {
            _conString = conString ?? throw new ArgumentNullException(nameof(conString));
            _timeOut = timeOut;
            _connection = connectionType == DatabaseType.MariaDb
                ? (IDbConnection) new MySqlConnection(conString)
                : new SqlConnection(conString);
        }


        public int ExecuteSql(string sql)
        {
            return _connection.Execute(sql, null, null, _timeOut);
        }

        public int ExecuteSql(string sql, IEnumerable<SqlParam> sqlParams)
        {
            var parameter = new DynamicParameters();
            foreach (var p in sqlParams) parameter.Add(p.Name, p.Value, p.ValueType);

            return _connection.Execute(sql, parameter, null, _timeOut);
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return _connection.Query<T>(sql, null, null, commandTimeout: _timeOut);
        }

        public IEnumerable<T> Query<T>(string sql, IEnumerable<SqlParam> sqlParams)
        {
            var parameter = new DynamicParameters();
            foreach (var p in sqlParams) parameter.Add(p.Name, p.Value, p.ValueType);

            return _connection.Query<T>(sql, null, null, commandTimeout: _timeOut);
        }

        public void Dispose()
        {
            _connection?.Close();
        }
    }
}