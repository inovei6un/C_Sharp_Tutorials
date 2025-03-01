using MyWebApp.Interfaces;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// Register the same service with different lifetimes
builder.Services.AddSingleton<ISingletonWelcomeService, SingletonWelcomeService>();
builder.Services.AddScoped<IScopedWelcomeService, ScopedWelcomeService>();
builder.Services.AddTransient<ITransientWelcomeService, TransientWelcomeService>();

var app = builder.Build();

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

app.Run();
