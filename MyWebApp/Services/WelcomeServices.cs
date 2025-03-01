using MyWebApp.Interfaces;

public abstract class WelcomeServiceBase
{
    private readonly DateTime _serviceCreated;
    private readonly Guid _serviceId;

    protected WelcomeServiceBase()
    {
        _serviceCreated = DateTime.Now;
        _serviceId = Guid.NewGuid();
    }

    protected string GetMessage(string serviceType)
    {
        return $"[{serviceType}] Created at {_serviceCreated}, ID: {_serviceId}";
    }
}

public class TransientWelcomeService : WelcomeServiceBase, ITransientWelcomeService
{
    public string GetWelcomeMessage() => GetMessage("Transient");
}

public class ScopedWelcomeService : WelcomeServiceBase, IScopedWelcomeService
{
    public string GetWelcomeMessage() => GetMessage("Scoped");
}

public class SingletonWelcomeService : WelcomeServiceBase, ISingletonWelcomeService
{
    public string GetWelcomeMessage() => GetMessage("Singleton");
}
