namespace SwitchStatements;

public interface IServiceFactory
{
    IService CreateService(string path, ILogger log, IConfig mappingConfig);
}