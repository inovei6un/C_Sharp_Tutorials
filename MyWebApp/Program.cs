using Microsoft.AspNetCore.Rewrite;
using MyWebApp.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Register the same service with different lifetimes
builder.Services.AddSingleton<ISingletonWelcomeService, SingletonWelcomeService>();
builder.Services.AddScoped<IScopedWelcomeService, ScopedWelcomeService>();
builder.Services.AddTransient<ITransientWelcomeService, TransientWelcomeService>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();
    Console.WriteLine($"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");

});

app.UseRewriter(new RewriteOptions().AddRedirect("history", "about"));

app.MapGet("/", (
    ISingletonWelcomeService singletonWelcomeService,
    IScopedWelcomeService scopedWelcomeService,
    ITransientWelcomeService transientWelcomeService) =>
{
    string message1 = $"Singleton: {singletonWelcomeService.GetWelcomeMessage()}";

    string message2 = $"Scoped: {scopedWelcomeService.GetWelcomeMessage()}";

    string message3 = $"Transient1: {transientWelcomeService.GetWelcomeMessage()}";

    return $"{message1}\n{message2}\n{message3}";
});

app.MapGet("/about", () => "This is an endpoint that shows the usage of UseRewriter middleware.");

app.Run();
