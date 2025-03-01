using MyWebApp.Interfaces;

public class TransientWelcomeService : ITransientWelcomeService
{
    private readonly DateTime _serviceCreated;
    private readonly Guid _serviceId;

    public TransientWelcomeService()
    {
        _serviceCreated = DateTime.Now;
        _serviceId = Guid.NewGuid();
    }

    public string GetWelcomeMessage()
    {
        return $"[Transient] Created at {_serviceCreated}, ID: {_serviceId}";
    }
}

public class ScopedWelcomeService : IScopedWelcomeService
{
    private readonly DateTime _serviceCreated;
    private readonly Guid _serviceId;

    public ScopedWelcomeService()
    {
        _serviceCreated = DateTime.Now;
        _serviceId = Guid.NewGuid();
    }

    public string GetWelcomeMessage()
    {
        return $"[Scoped] Created at {_serviceCreated}, ID: {_serviceId}";
    }
}

public class SingletonWelcomeService : ISingletonWelcomeService
{
    private readonly DateTime _serviceCreated;
    private readonly Guid _serviceId;

    public SingletonWelcomeService()
    {
        _serviceCreated = DateTime.Now;
        _serviceId = Guid.NewGuid();
    }

    public string GetWelcomeMessage()
    {
        return $"[Singleton] Created at {_serviceCreated}, ID: {_serviceId}";
    }
}
