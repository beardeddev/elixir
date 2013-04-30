using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

namespace Elixir.Data.Fluent
{
    using Elixir.Data.Packages.Dapper;
    
    public interface IDbManager
    {
        #region Fluent
        IDbManager AddParameter(string name, object value, DbType dbType, ParameterDirection direction, int size);
        void BeginTransaction();
        void BeginTransaction(IsolationLevel IsolationLevel);
        void CommitTransaction();
        IDbCommand DbCommand { get; }
        IDbConnection DbConnection { get; }
        void Dispose();
        object Execute();
        IEnumerable<T> ExecuteList<T>() where T : class;
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> ExecuteMultiple<T1, T2, T3>();
        Tuple<IEnumerable<T1>, IEnumerable<T2>> ExecuteMultiple<T1, T2>();
        int ExecuteNonQuery();
        T ExecuteObject<T>() where T : class;
        IDataReader ExecuteReader();
        IDataReader ExecuteReader(CommandBehavior behavior);
        IDictionary Parameters { get; }
        void RollbackTransaction();
        IDbManager SetCommand(string commandText);
        IDbManager SetCommand(string commandText, object parameters);
        IDbManager SetSpCommand(string commandText);
        IDbManager SetSpCommand(string commandText, object parameters);
        IDbTransaction Transaction { get; } 
        #endregion
    }
}
