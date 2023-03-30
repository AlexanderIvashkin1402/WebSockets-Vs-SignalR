using System.Net.WebSockets;

namespace WebSocketServer;

public interface IWebSocketMessageHandler
{
    Task ReceiveMessage(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage);
}
