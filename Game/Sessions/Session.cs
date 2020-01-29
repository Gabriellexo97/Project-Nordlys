using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nordlys.Game.Sessions
{
    public class Session
    {
        public IChannel Channel { get; }
        public int SessionId { get; }

        public Session(IChannel channel, int sessionId)
        {
            Channel = channel;
            SessionId = sessionId;
        }
    }

}
