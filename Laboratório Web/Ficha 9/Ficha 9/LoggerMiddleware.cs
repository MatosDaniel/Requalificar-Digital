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
            string before = String.Format("Before: {0}", context.Request.Path);
            File.AppendAllText("logs.txt", before);

            await next(context);

            string after = String.Format("After: {0}", context.Request.Method);
            File.AppendAllText("logs.txt", after);
        }
        /* public static IApplicationBuilder UseLoggerMiddleware(
        this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        } *
    }
}
