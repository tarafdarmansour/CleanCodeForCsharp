namespace PreferExceptionstoReturningErrorCodes;

public class BadAccount
{
    private int _balance;

    public int Withdraw(int amount)
    {
        if (amount > _balance) return -1;

        _balance -= amount;
        return 0;
    }
}