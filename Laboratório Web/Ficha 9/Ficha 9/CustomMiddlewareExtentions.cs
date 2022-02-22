namespace Ficha_9
{
    public static class CustomMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomMiddleware(
        this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
        public static IApplicationBuilder UseLoggerMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }
    }
}
