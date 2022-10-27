namespace DeﬁneExceptionClassesinTermsofaCallersNeeds;

public class LocalPort
{
    private readonly ACMEPort innerPort;

    public LocalPort(int portNumber)
    {
        innerPort = new ACMEPort(portNumber);
    }

    public void open()
    {
        try
        {
            innerPort.open();
        }
        catch (DeviceResponseException e)
        {
            throw new PortDeviceFailure(e);
        }
        catch (ATM1212UnlockedException e)
        {
            throw new PortDeviceFailure(e);
        }
        catch (GMXError e)
        {
            throw new PortDeviceFailure(e);
        }
    }
}