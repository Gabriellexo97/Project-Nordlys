using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Nordlys.Storage
{
    public class DatabaseConnection : IDisposable
    {
        private readonly MySqlConnection connection;
        private readonly MySqlCommand command;

        private MySqlTransaction transaction;

        private readonly ConnectionPool connectionPool;

        public DatabaseConnection(string connectionString, ConnectionPool connectionPool)
        {
            connection = new MySqlConnection(connectionString);
            command = connection.CreateCommand();
            Open();
        }

        public void Open()
        {
            connection.Open();
        }

        public bool IsOpen()
        {
            return connection.State == ConnectionState.Open;
        }

        /// <summary>
        /// Adds a parameter to the MySqlCommand.
        /// </summary>
        /// <param name="parameter">The parameter with prefixed with an '@'</param>
        /// <param name="value">The value of the parameter.</param>
        public void AddParameter(string parameter, object value)
        {
            command.Parameters.AddWithValue(parameter, value);
        }

        public void AddParameters(MySqlParameter[] parameters)
        {
            command.Parameters.AddRange(parameters);
        }

        public void SetQuery(string query)
        {
            command.CommandText = query;
        }

        /// <summary>
        /// Executes a query.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        public int Execute()
        {
            try
            {
                return command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                command.CommandText = string.Empty;
                command.Parameters.Clear();
            }
        }

        public MySqlDataReader ExecuteReader()
        {
            try
            {
                return command.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                command.CommandText = string.Empty;
                command.Parameters.Clear();
            }
        }

        public DataTable GetTable()
        {
            DataTable table = new DataTable();

            using MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);

            return table;
        }

        public DataRow GetRow()
        {
            DataTable table = GetTable();

            return table.Rows.Count > 0 ? table.Rows[0] : null;
        }

        public string GetString()
        {
            try
            {
                return command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetInt()
        {
            return (int)command.ExecuteScalar();
        }

        /// <summary>
        /// Executes an 'insert'-query. Instead of 'Execute', it returns the inserted ID rather than the amount of affected rows.
        /// </summary>
        /// <returns>The inserted ID.</returns>
        public int Insert()
        {
            try
            {
                command.ExecuteNonQuery();

                return (int)command.LastInsertedId;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                command.CommandText = string.Empty;
                command.Parameters.Clear();
            }
        }

        public void Dispose()
        {
            transaction = connection.BeginTransaction();
            transaction.Commit();

            if (IsOpen())
                connection.Close();

            command.Parameters?.Clear();
            transaction?.Dispose();
            command.Dispose();
            connectionPool.ReturnConnection(this);
            GC.SuppressFinalize(this);
        }
    }
}
