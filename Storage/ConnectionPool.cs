using Nordlys.DependencyInjection;
using System.Collections.Generic;

namespace Nordlys.Storage
{
    public class ConnectionPool
    {
        private Stack<DatabaseConnection> connections;
        private readonly string _connectionString =
            "Server=127.0.0.1;" +
            "Port=3306; " +
            "Uid=root; " +
            "Password=1234; " +
            "Database=nordlys_db; " +
            "Pooling=true;" +
            "MinimumPoolSize=5; " +
            "MaximumPoolSize=15";

        public ConnectionPool()
        {
            connections = new Stack<DatabaseConnection>();
        }

        public DatabaseConnection PopConnection()
        {
            if (connections.Count == 0)
                return new DatabaseConnection(_connectionString, this);
            DatabaseConnection connection = connections.Pop();
            connection.Open();
            return connection;
        }

        public void ReturnConnection(DatabaseConnection con)
        {
            connections.Push(con);
        }
    }
}
