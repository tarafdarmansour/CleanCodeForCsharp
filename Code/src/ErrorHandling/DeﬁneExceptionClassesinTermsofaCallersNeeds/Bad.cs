namespace DeﬁneExceptionClassesinTermsofaCallersNeeds;

public class Bad
{
    private readonly ILogger _logger;

    public void run()
    {
        var port = new ACMEPort(12);
        try
        {
            port.open();
        }
        catch (DeviceResponseException e)
        {
            reportPortError(e);
            _logger.Log("Device response exception", e);
        }
        catch (ATM1212UnlockedException e)
        {
            reportPortError(e);
            _logger.Log("Unlock exception", e);
        }
        catch (GMXError e)
        {
            reportPortError(e);
            _logger.Log("Device response exception");
        }
        finally
        {
            _logger.Log("finally section");
        }
    }

    private void reportPortError(Exception p0)
    {
        throw new NotImplementedException();
    }
}

public class ACMEPort
{
    public ACMEPort(int i)
    {
        throw new NotImplementedException();
    }

    public void open()
    {
        throw new NotImplementedException();
    }
}