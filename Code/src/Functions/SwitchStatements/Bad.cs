namespace SwitchStatements;

public class BadServiceFactory
{
    public static IService CreateService(string path, ILogger log, IConfig mappingConfig)
    {
        switch (path)
        {
            case ServicePath.service1:
                return new service1(log, mappingConfig);
            case ServicePath.service2:
                return new service2(log, mappingConfig);
            case ServicePath.service3:
                return new service3(log, mappingConfig);
            case ServicePath.service4:
                return new service4(log, mappingConfig);
        }

        return new notImpelmented(log, mappingConfig);
    }
}