namespace DevCreedApi.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static async void UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<myMiddleware>();
            app.UseMiddleware<HelloWorldMiddleware>();
        }


    }
}
