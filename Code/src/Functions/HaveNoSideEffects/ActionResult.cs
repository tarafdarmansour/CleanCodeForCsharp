namespace HaveNoSideEffects;

public class ActionResult
{
    public ActionResult(string message, int status)
    {
        Message = message;
        Status = status;
    }

    public string Message { get; }

    public int Status { get; }
}