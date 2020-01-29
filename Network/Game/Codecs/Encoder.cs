using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Nordlys.Communication.Messages;
using System.Collections.Generic;
using System.Text;

namespace Nordlys.Network.Game.Codecs
{
    public class Encoder : MessageToMessageEncoder<object>
    {
        protected override void Encode(IChannelHandlerContext context, object message, List<object> output)
        {
            if (message is string)
            {
                output.Add(Unpooled.WrappedBuffer(Encoding.UTF8.GetBytes(message.ToString())));
            }
        }
    }
}
