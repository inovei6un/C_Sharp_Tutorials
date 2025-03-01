namespace MyWebApp.Interfaces
{
    public interface IWelcomeService
    {
        string GetWelcomeMessage();
    }
    public interface ISingletonWelcomeService : IWelcomeService
    {
    }

    public interface IScopedWelcomeService : IWelcomeService
    {
    }

    public interface ITransientWelcomeService : IWelcomeService
    {
    }
}
