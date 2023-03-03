using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Infra.CrossCutting.WebSocketService
{
    public interface IWebSocketCalls
    {
        Task Echo(System.Net.WebSockets.WebSocket webSocket);
    }
}
