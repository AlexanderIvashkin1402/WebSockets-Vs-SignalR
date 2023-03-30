using System.Net.WebSockets;

namespace WebSocketServer;

public class WebSocketMessageHandler : IWebSocketMessageHandler
{
    public async Task ReceiveMessage(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
    {
        var buffer = new byte[1024 * 4];

        while (socket.State == WebSocketState.Open)
        {
            var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer), cancellationToken: CancellationToken.None);
            handleMessage(result, buffer);
        }
    }
}
