namespace RedundantComments;

public class Bad
{
    private bool closed;

    // Utility method that returns when this.closed is true. Throws an exception
    // if the timeout is reached.
    public void waitForClose(int timeoutMillis)
    {
        if (!closed)
        {
            wait(timeoutMillis);
            if (!closed)
                throw new Exception("MockResponseSender could not be closed");
        }
    }

    private void wait(int timeoutMillis)
    {
        Task.Delay(timeoutMillis);
    }
}