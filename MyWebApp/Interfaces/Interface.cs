namespace MyWebApp.Interfaces
{
    public interface ISingletonWelcomeService
    {
        string GetWelcomeMessage();
    }

    public interface IScopedWelcomeService
    {
        string GetWelcomeMessage();
    }

    public interface ITransientWelcomeService
    {
        string GetWelcomeMessage();
    }
}
