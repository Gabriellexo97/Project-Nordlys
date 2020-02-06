using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Nordlys.Game.Habbos
{
    public class HabboController
    {
        private readonly HabboDbContext dbContext;

        public HabboController(HabboDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Habbo GetHabbo(int id)
        {
            return dbContext.Find<Habbo>(id);
        }

        public Habbo Authenticate(string sso)
        {
            return dbContext.Habbos.Where(habbo => habbo.AuthenticationTicket == sso).FirstOrDefault();
        }
    }
}
