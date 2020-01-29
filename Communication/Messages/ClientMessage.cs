using DotNetty.Buffers;
using System.Text;

namespace Nordlys.Communication.Messages
{
    public class ClientMessage
    {
        private readonly IByteBuffer buf;

        public short Id { get; }

        public ClientMessage(IByteBuffer buf)
        {
            this.buf = buf;
            Id = ReadInt16();
        }

        public short ReadInt16()
        {
            return buf.ReadShort();
        }

        public int ReadInt32()
        {
            return buf.ReadInt();
        }

        public bool ReadBoolean()
        {
            return buf.ReadBoolean();
        }

        public string ReadString()
        {
            return buf.ReadString(ReadInt16(), Encoding.UTF8);
        }
    }
}
