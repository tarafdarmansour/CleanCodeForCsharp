namespace DeﬁneExceptionClassesinTermsofaCallersNeeds;

internal interface ILogger
{
    void Log(string message);
    void Log(string message, Exception e);
}