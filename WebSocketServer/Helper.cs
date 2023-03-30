namespace WebSocketServer;

public static class Helper
{
    public static void WriteRequestParam(HttpContext context, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            Console.WriteLine("Request Method: " + context.Request.Method);
            Console.WriteLine("Request Protocol: " + context.Request.Protocol);

            if (context.Request.Headers != null)
            {
                Console.WriteLine("Request Headers: ");
                foreach (var h in context.Request.Headers)
                {
                    Console.WriteLine("--> " + h.Key + ": " + h.Value);
                }
            }
        }
    }
}
