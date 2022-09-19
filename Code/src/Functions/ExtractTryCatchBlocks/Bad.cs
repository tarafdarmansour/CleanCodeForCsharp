namespace ExtractTryCatchBlocks;

public class Bad
{
    private readonly ICongigService _congigService;
    private readonly Ilogger _logger;
    private readonly IRegistery _registery;

    public Bad(Ilogger logger, IRegistery registery, ICongigService congigService)
    {
        _logger = logger;
        _registery = registery;
        _congigService = congigService;
    }

    public void BadDeleteFunction(Page page)
    {
        try
        {
            deletePage(page);
            _registery.DeleteReference(page.name);
            _congigService.DeleteKey(page.name.MakeKey());
        }
        catch (Exception e)
        {
            _logger.Log(e.Message);
        }
    }

    private void deletePage(Page page)
    {
        throw new NotImplementedException();
    }
}