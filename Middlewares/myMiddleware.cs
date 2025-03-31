namespace DevCreedApi.Middlewares
{
    public class myMiddleware
    {
        
        private readonly ILogger logger;
        private readonly RequestDelegate next;

        public myMiddleware(ILogger<myMiddleware> logger, RequestDelegate next)
        {


            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            logger.LogInformation("comblex middleware Begin ");

            await next(context);

            logger.LogInformation("comblex middleware End ");

        }
    }
}
