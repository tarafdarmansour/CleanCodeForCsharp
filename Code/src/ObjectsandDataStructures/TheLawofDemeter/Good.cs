namespace TheLawofDemeter.Good;

public class Wallet
{
    public Wallet(float initialAmount)
    {
        Value = initialAmount;
    }

    public float Value { get; private set; }

    public void AddMoney(float amount)
    {
        Value += amount;
    }

    public void SubMoney(float amount)
    {
        Value -= amount;
    }
}

public class Customer
{
    private readonly Wallet _wallet;

    public Customer()
    {
        FirstName = "John";
        LastName = "Doe";
        _wallet = new Wallet(20.0f); // amount set to 20 for example
    }

    public string FirstName { get; }

    public string LastName { get; }

    public float PayAmount(float amountToPay)
    {
        if (_wallet.Value >= amountToPay)
        {
            _wallet.SubMoney(amountToPay);
            return amountToPay;
        }

        return 0;
    }
}

public class Paperboy
{
    public void SellPaper(Customer customer)
    {
        var payment = 2.0f;
        var amountPaid = customer.PayAmount(payment);
        if (amountPaid != payment)
        {
            // come back later
        }
    }
}