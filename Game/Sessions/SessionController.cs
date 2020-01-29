using DotNetty.Transport.Channels;
using Nordlys.DependencyInjection;
using System.Collections.Generic;

namespace Nordlys.Game.Sessions
{
    public class SessionController
    {
        private readonly Dictionary<IChannelId, Session> sessions;

        public SessionController()
        {
            sessions = new Dictionary<IChannelId, Session>();
        }

        public void AddSession(Session session)
        {
            sessions.Add(session.Channel.Id, session);
        }

        public void RemoveSession(IChannel channel)
        {
            sessions.Remove(channel.Id);
        }

        public void RemoveSession(Session session)
        {
            sessions.Remove(session.Channel.Id);
        }

        public Session GetSession(IChannel channel)
        {
            if (sessions.TryGetValue(channel.Id, out Session session))
            {
                return session;
            }

            return null;
        }
    }
}
