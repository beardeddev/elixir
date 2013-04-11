using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Collections;

namespace Elixir.Data.Fluent
{
    using Elixir.Data.Packages.Dapper;
        
    /// <summary>
    /// 
    /// </summary>
    public class DbContextManager : IDbContextManager
    {
        private bool _Disposed;
        private DynamicParameters _Parameters;
        public int? commandTimeout;

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public IDictionary Parameters
        {
            get
            {
                IDictionary temp = new Dictionary<string, object>();
                foreach(string name in this._Parameters.ParameterNames)
                {
                    var o = this._Parameters.Get<object>(name);
                    temp.Add(name, o);
                }

                return temp;
            }
        }

        /// <summary>
        /// Gets the transaction.
        /// </summary>
        public IDbTransaction Transaction { get; private set; }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        public IDbConnection DbConnection { get; private set; }

        /// <summary>
        /// Gets the db command.
        /// </summary>
        public IDbCommand DbCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextManager"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public DbContextManager(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            if (connection.State != ConnectionState.Open)
                connection.Open();

            this.DbConnection = connection;
            this.DbCommand = connection.CreateCommand();
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        public virtual void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="IsolationLevel">The isolation level.</param>
        public virtual void BeginTransaction(IsolationLevel IsolationLevel)
        {
            this.Transaction = this.DbConnection.BeginTransaction();
        }

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        public virtual void CommitTransaction()
        {
            if (Transaction != null)
                Transaction.Commit();

            Transaction = null;
        }


        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        public virtual void RollbackTransaction()
        {
            if (Transaction != null)
                Transaction.Rollback();

            Transaction = null;
        }

        /// <summary>
        /// Sets the command.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public virtual IDbContextManager SetCommand(string commandText)
        {
            this.DbCommand.CommandText = commandText;
            this.DbCommand.CommandType = CommandType.Text;
            this._Parameters = new DynamicParameters();
            return this;
        }

        /// <summary>
        /// Sets the sp command.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public virtual IDbContextManager SetSpCommand(string commandText)
        {
            this.DbCommand.CommandText = commandText;
            this.DbCommand.CommandType = CommandType.StoredProcedure;
            return this;
        }

        /// <summary>
        /// Sets the command.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public virtual IDbContextManager SetCommand(string commandText, object parameters)
        {
            this._Parameters = this.CreateParameters(parameters);
            return SetCommand(commandText);
        }

        /// <summary>
        /// Sets the sp command.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public virtual IDbContextManager SetSpCommand(string commandText, object parameters)
        {
            this._Parameters = this.CreateParameters(parameters);
            return SetSpCommand(commandText);
        }        

        /// <summary>
        /// Queries the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IEnumerable<T> ExecuteList<T>()
            where T : class
        {
            return this.DbConnection.Query<T>(DbCommand.CommandText, _Parameters, Transaction, true, null, DbCommand.CommandType);
        }

        /// <summary>
        /// Queries the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T ExecuteObject<T>()
            where T : class
        {
            return this.DbConnection.Query<T>(DbCommand.CommandText, _Parameters, Transaction, true, null, DbCommand.CommandType).FirstOrDefault();
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <returns></returns>
        public virtual int ExecuteNonQuery()
        {
            return this.DbCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="behavior">The behavior.</param>
        /// <returns></returns>
        public virtual IDataReader ExecuteReader(CommandBehavior behavior)
        {
            return this.DbCommand.ExecuteReader(behavior);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <returns></returns>
        public virtual IDataReader ExecuteReader()
        {
            return ExecuteReader(CommandBehavior.Default);
        }

        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <returns></returns>
        public virtual object Execute()
        {
            return this.DbConnection.Query<Object>(DbCommand.CommandText, _Parameters, Transaction, true, null, DbCommand.CommandType).FirstOrDefault();
        }

        /// <summary>
        /// Queries the multiple.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <returns></returns>
        public virtual Tuple<IEnumerable<T1>, IEnumerable<T2>> ExecuteMultiple<T1, T2>()
        {
            using (var rs = this.DbConnection.QueryMultiple(DbCommand.CommandText, _Parameters, Transaction, null, DbCommand.CommandType))
            {
                IEnumerable<T1> item1 = rs.Read<T1>();
                IEnumerable<T2> item2 = rs.Read<T2>();

                return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
            }
        }

        /// <summary>
        /// Queries the multiple.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <typeparam name="T3">The type of the 3.</typeparam>
        /// <returns></returns>
        public virtual Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> ExecuteMultiple<T1, T2, T3>()
        {
            using (var rs = this.DbConnection.QueryMultiple(DbCommand.CommandText, _Parameters, Transaction, null, DbCommand.CommandType))
            {
                IEnumerable<T1> item1 = rs.Read<T1>();
                IEnumerable<T2> item2 = rs.Read<T2>();
                IEnumerable<T3> item3 = rs.Read<T3>();

                return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(item1, item2, item3);
            }
        }

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public virtual IDbContextManager AddParameter(string name, object value, DbType dbType, ParameterDirection direction, int size)
        {
            this._Parameters.Add(name, value, dbType, direction, size);
            return this;
        }        

        #region IDisposable members
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing)
                {
                    if (this.DbConnection != null)
                    {
                        if(this.DbConnection.State == ConnectionState.Open)
                            this.DbConnection.Close();

                        this.DbConnection.Dispose();
                    }
                }
                _Disposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="DbContextManager"/> is reclaimed by garbage collection.
        /// </summary>
        ~DbContextManager()
        {
            Dispose(false);
        } 
        #endregion

        /// <summary>
        /// Creates the parameters.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private DynamicParameters CreateParameters(object value)
        {
            return new DynamicParameters(value);
        }
    }
}
