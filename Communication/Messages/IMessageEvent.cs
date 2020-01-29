using Nordlys.Game.Sessions;
using System.Threading.Tasks;

namespace Nordlys.Communication.Messages
{
    public interface IMessageEvent
    {
        Task RunAsync(Session session, ClientMessage message);
    }
}
