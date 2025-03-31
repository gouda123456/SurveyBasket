using System.Threading.Tasks;

namespace DevCreedApi.Middlewares
{
    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public HelloWorldMiddleware(RequestDelegate next,ILogger<HelloWorldMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext http)
        {
            logger.LogWarning("Hello");

            await next(http);

            logger.LogWarning("World");
        }
    }
}
