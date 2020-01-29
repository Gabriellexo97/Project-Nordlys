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

        public MessageHandler(ILogger<MessageHandler> logger)
        {
            this.logger = logger;

            messageEvents = new Dictionary<short, IMessageEvent>();
        }

        public void RegisterEvents(ServiceProvider serviceProvider)
        {
            // TODO: Finish this off
            logger.LogDebug("Loaded {0} message events", messageEvents.Count);
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
