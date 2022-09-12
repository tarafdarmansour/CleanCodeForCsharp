namespace SwitchStatements;

public class GoodServiceFactory : IServiceFactory
{
    private readonly Dictionary<string, Func<ILogger, IConfig, IService>> _map;

    public GoodServiceFactory()
    {
        _map = new Dictionary<string, Func<ILogger, IConfig, IService>>();
        _map.Add(ServicePath.service1, (log, mappingConfig) => new service1(log, mappingConfig));
        _map.Add(ServicePath.service2, (log, mappingConfig) => new service2(log, mappingConfig));
        _map.Add(ServicePath.service3, (log, mappingConfig) => new service3(log, mappingConfig));
        _map.Add(ServicePath.service4, (log, mappingConfig) => new service4(log, mappingConfig));
    }

    public IService CreateService(string path, ILogger log, IConfig mappingConfig)
    {
        return _map.ContainsKey(path)
            ? _map[path](log, mappingConfig)
            : new notImpelmented(log, mappingConfig);
    }
}