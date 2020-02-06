using Microsoft.Extensions.Logging;
using Nordlys.Game.Sessions;
using System.Threading.Tasks;

namespace Nordlys.Communication.Messages.Incoming.Handshake
{
    class ReadReleaseMessageEvent : IMessageEvent
    {
        public short Header => 4000;

        private ILogger<ReadReleaseMessageEvent> logger;

        public ReadReleaseMessageEvent(ILogger<ReadReleaseMessageEvent> logger)
        {
            this.logger = logger;
        }

        public Task RunAsync(Session session, ClientMessage message)
        {
            logger.LogDebug("Client {0} connected to release {1}", session.SessionId, message.ReadString());
            return Task.CompletedTask;
        }
    }
}
