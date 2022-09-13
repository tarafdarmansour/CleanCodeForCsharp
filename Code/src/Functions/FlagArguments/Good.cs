namespace FlagArguments;

public class Good
{
    public Booking regularBook(Customer aCustomer)
    {
        doforNotPremium();
        // logic for regular booking
        throw new NotImplementedException();
    }

    public Booking premiumBook(Customer aCustomer)
    {
        doforPremium();
        // logic for premium book
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