using DotNetty.Transport.Channels;
using Nordlys.DependencyInjection;
using System.Threading;

namespace Nordlys.Game.Sessions
{
    public class SessionFactory
    {
        private int sessionIdCounter;

        public SessionFactory()
        {
            sessionIdCounter = 0;
        }

        public Session CreateSession(IChannel channel)
        {
            return new Session(channel, Interlocked.Increment(ref sessionIdCounter));
        }
    }
}
