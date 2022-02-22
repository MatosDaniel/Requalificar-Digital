namespace Ficha_9
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate next;
        public LoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string before = String.Format($"Before: {context.Request.Path}, {context.Request.Method}, {DateTime.Now}\n");
            File.AppendAllText("logs.txt", before);

            await next(context);

            string after = String.Format($"After: {context.Request.Path}, {context.Request.Method}, {DateTime.Now}\n");
            File.AppendAllText("logs.txt", after);
        }
    }
}
