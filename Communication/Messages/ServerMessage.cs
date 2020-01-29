using DotNetty.Buffers;
using System.Text;

namespace Nordlys.Communication.Messages
{
    public class ServerMessage
    {
        private IByteBuffer buffer;

        public ServerMessage(short header)
        {
            buffer = Unpooled.Buffer();
            WriteInt16(header);
        }

        public void WriteInt16(short value)
        {
            buffer.WriteShort(value);
        }

        public void WriteInt32(int value)
        {
            buffer.WriteInt(value);
        }

        public void WriteBoolean(bool value)
        {
            buffer.WriteBoolean(value);
        }

        public void WriteString(string value)
        {
            buffer.WriteString(value, Encoding.UTF8);
        }

        public IByteBuffer GetPacket()
        {
            IByteBuffer buffer = Unpooled.CopiedBuffer(this.buffer);
            buffer.SetInt(0, buffer.Capacity - 4);
            return buffer;
        }
    }
}
