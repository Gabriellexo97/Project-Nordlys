using Nordlys.DependencyInjection;
using Nordlys.Storage;
using System.Data;

namespace Nordlys.Game.Habbos
{
    public class HabboDao
    {
        private readonly ConnectionPool connectionPool;

        public HabboDao(ConnectionPool connectionPool)
        {
            this.connectionPool = connectionPool;
        }

        public Habbo Authenticate(string sso)
        {
            using DatabaseConnection databaseConnection = connectionPool.PopConnection();

            databaseConnection.SetQuery("SELECT * FROM users WHERE ssoticket = @sso LIMIT 1");
            databaseConnection.AddParameter("@sso", sso);

            DataRow row = databaseConnection.GetRow();

            if (row != null)
            {
                return new Habbo(row);
            }

            return null;
        }
    }
}
