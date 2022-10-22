namespace TheLawofDemeter.Bad;

public class Wallet
{
    public float Value { get; set; }

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
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Wallet Wallet { get; set; }
}

public class Paperboy
{
    public void SellPaper(Customer customer)
    {
        var payment = 2.0f;
        var wallet = customer.Wallet;
        if (wallet.Value >= payment) wallet.SubMoney(payment);
    }
}