namespace DeﬁneExceptionClassesinTermsofaCallersNeeds;

public class Good
{
    private readonly ILogger _logger;

    public void run()
    {
        var port = new LocalPort(12);
        try
        {
            port.open();
        }
        catch (PortDeviceFailure e)
        {
            reportError(e);
            _logger.Log(e.getMessage(), e);
        }
        finally
        {
            _logger.Log("finally section");
        }
    }

    private void reportError(PortDeviceFailure portDeviceFailure)
    {
        throw new NotImplementedException();
    }
}