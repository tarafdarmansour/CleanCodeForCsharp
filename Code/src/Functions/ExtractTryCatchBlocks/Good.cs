namespace ExtractTryCatchBlocks;

public class Good
{
    private readonly ICongigService _congigService;
    private readonly Ilogger _logger;
    private readonly IRegistery _registery;

    public Good(Ilogger logger, IRegistery registery, ICongigService congigService)
    {
        _logger = logger;
        _registery = registery;
        _congigService = congigService;
    }

    public void GoodDeleteFunction(Page page)
    {
        try
        {
            deletePageAndAllReferences(page);
        }
        catch (Exception e)
        {
            logError(e);
        }
    }

    private void deletePageAndAllReferences(Page page)
    {
        deletePage(page);
        _registery.DeleteReference(page.name);
        _congigService.DeleteKey(page.name.MakeKey());
    }

    private void logError(Exception e)
    {
        _logger.Log(e.Message);
    }

    private void deletePage(Page page)
    {
        throw new NotImplementedException();
    }
}