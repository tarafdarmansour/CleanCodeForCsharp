namespace DeﬁneExceptionClassesinTermsofaCallersNeeds;

public class PortDeviceFailure : Exception
{
    public PortDeviceFailure(Exception exception)
    {
    }

    public string getMessage()
    {
        throw new NotImplementedException();
    }
}