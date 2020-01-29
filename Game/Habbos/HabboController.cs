using Nordlys.DependencyInjection;
using System.Collections.Generic;

namespace Nordlys.Game.Habbos
{
    public class HabboController
    {
        private readonly Dictionary<int, Habbo> habbos;
        private readonly HabboDao dao;

        public HabboController(HabboDao dao)
        {
            this.dao = dao;

            habbos = new Dictionary<int, Habbo>();
        }

        //public Habbo GetHabbo(int id)
        //{
        //    if (habbos.TryGetValue(id, out Habbo habbo))
        //    {
        //        return habbo;
        //    }

        //    return dao.
        //}

        public Habbo Authenticate(string sso)
        {
            Habbo habbo = dao.Authenticate(sso);
            
            if (habbo != null && habbos.ContainsKey(habbo.Id))
            {
                habbos[habbo.Id] = habbo;
            }

            return habbo;
        }
    }
}
