using WebSocketServer.Middleware;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<IWebSocketMessageHandler, WebSocketMessageHandler>();
builder.Services.AddWebSocketServerConnectionManager();

var app = builder.Build();

app.UseWebSockets();

app.UseWebSocketServer();

//app.Use(async (context, next) =>
//{
//    Helper.WriteRequestParam(context, app.Environment);

//    if (context.WebSockets.IsWebSocketRequest)
//    {
//        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
//        Console.WriteLine("WebSocket Connected");

//        var webSocketMessageHandler = context.RequestServices.GetService<IWebSocketMessageHandler>();

//        await webSocketMessageHandler.ReceiveMessage(webSocket, async (result, buffer) =>
//        {
//            if (result.MessageType == WebSocketMessageType.Text)
//            {
//                Console.WriteLine($"Receive->Text");

//                return;
//            }
//            else if (result.MessageType == WebSocketMessageType.Close)
//            {
//                Console.WriteLine($"Receive->Close");

//                return;
//            }
//        });
//    }
//    else
//    {
//        Console.WriteLine("Hello from 2nd Request Delegate - No WebSocket");
//        await next();
//    }
//});

app.Run(async context => 
{
    Console.WriteLine("Hello from 3rd (terminal) Request Delegate");
    await context.Response.WriteAsync("Hello from 3rd (terminal) Request Delegate");
});

app.Run();
