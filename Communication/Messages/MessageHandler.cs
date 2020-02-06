using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nordlys.DependencyInjection;
using Nordlys.Game.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Nordlys.Communication.Messages
{
    public class MessageHandler
    {
        private readonly Dictionary<short, IMessageEvent> messageEvents;
        private readonly ILogger<MessageHandler> logger;

        public MessageHandler(ILogger<MessageHandler> logger, IEnumerable<IMessageEvent> messageEvents)
        {
            this.logger = logger;

            this.messageEvents = messageEvents.ToDictionary(messageEvent => messageEvent.Header);

            logger.LogDebug("Loaded {0} message events", this.messageEvents.Count);
        }

        public async Task TryHandleAsync(Session session, ClientMessage message)
        {
            if (messageEvents.TryGetValue(message.Id, out IMessageEvent messageEvent))
            {
                await messageEvent.RunAsync(session, message);
            }
            else
            {
                logger.LogWarning("Unregistered header {0}", message.Id);
            }
        }
    }
}
