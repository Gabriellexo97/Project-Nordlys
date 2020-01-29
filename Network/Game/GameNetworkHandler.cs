using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using Nordlys.Communication.Messages;
using Nordlys.Game.Sessions;
using System;

namespace Nordlys.Network.Game
{
    public class GameNetworkHandler : SimpleChannelInboundHandler<ClientMessage>
    {
        private readonly ILogger<GameNetworkHandler> logger;
        private readonly SessionFactory sessionFactory;
        private readonly SessionController sessionController;
        private readonly MessageHandler messageHandler;

        public GameNetworkHandler(ILogger<GameNetworkHandler> logger, SessionFactory sessionFactory, SessionController sessionController, MessageHandler messageHandler)
        {
            this.logger = logger;
            this.sessionFactory = sessionFactory;
            this.sessionController = sessionController;
            this.messageHandler = messageHandler;
        }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            Session session = sessionFactory.CreateSession(context.Channel);
            sessionController.AddSession(session);

            logger.LogInformation("New connection from {0}", session.Channel.RemoteAddress);
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            sessionController.RemoveSession(context.Channel);

            logger.LogInformation("New connection from {0}", context.Channel.RemoteAddress);
        }

        protected override async void ChannelRead0(IChannelHandlerContext ctx, ClientMessage msg)
        {
            Session session = sessionController.GetSession(ctx.Channel);

            await messageHandler.TryHandleAsync(session, msg);
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            throw exception;
        }
    }
}
