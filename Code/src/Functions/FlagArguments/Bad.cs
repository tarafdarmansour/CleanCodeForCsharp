namespace FlagArguments;

public class Bad
{
    public Booking Book(Customer aCustomer, bool isPremium)
    {
        if (isPremium)
            doforPremium();
        // logic for premium book
        else
            doforNotPremium();
        // logic for regular booking
        throw new NotImplementedException();
    }

    private void doforPremium()
    {
        throw new NotImplementedException();
    }

    private void doforNotPremium()
    {
        throw new NotImplementedException();
    }
}