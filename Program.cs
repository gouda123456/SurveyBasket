using DevCreedApi.Middlewares;
using DevCreedApi.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region MyServices

builder.Services.AddKeyedSingleton<myService>("serviceSingleton"); // ===> create one for all project
//builder.Services.AddScoped<myService>();    // ===> create one for Http request
//builder.Services.AddTransient<myService>(); // ===> create one for every object

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    //My Middleware
    app.MapScalarApiReference();
    
}

#region MyMiddlewares

var logger = app.Logger;

app.Use(async (context, next) =>
{
    logger.LogInformation("Handle Request");

    await next(context);

    logger.LogInformation("Handle Responed");


});


app.UseCustomMiddlewares();
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
