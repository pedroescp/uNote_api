using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace uNotes.Infra.CrossCutting.WebSocketService
{
    public class WebSocketCalls : IWebSocketCalls
    {
        public async Task Echo(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!receiveResult.CloseStatus.HasValue)
            {
                await HandleMessages(webSocket);
            }
            
            await webSocket.CloseAsync(
            receiveResult.CloseStatus.Value,
            receiveResult.CloseStatusDescription,
            CancellationToken.None);
        }

        private static async Task HandleMessages(WebSocket ws)
        {
            try
            {
                WebSocketReceiveResult result;
                using (var ms = new MemoryStream())
                {
                    ArraySegment<byte> messageBuffer;
                    do
                    {
                        messageBuffer = WebSocket.CreateClientBuffer(1024, 16);
                        result = await ws.ReceiveAsync(messageBuffer, CancellationToken.None);
                        ms.Write(messageBuffer.Array, messageBuffer.Offset, result.Count);
                    }
                    while (!result.EndOfMessage);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var msgString = Encoding.UTF8.GetString(ms.ToArray());
                        await ws.SendAsync(
                                new ArraySegment<byte>(messageBuffer.Array, 0, result.Count),
                                result.MessageType,
                                result.EndOfMessage,
                                CancellationToken.None);
                    }
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Position = 0;
                }
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
