namespace Pickonewordperconcept.Bad;

public class Product
{
    public List<Product> GetProducts()
    {
        throw new NotImplementedException();
    }
}

public class Customer
{
    public List<Customer> RetriveCustomers()
    {
        throw new NotImplementedException();
    }
}

public class Device
{
    public List<Device> FetchDevices()
    {
        throw new NotImplementedException();
    }
}

public class Main
{
    public void CallMethods()
    {
        var device = new Device();
        var devices = device.FetchDevices();
        var product = new Product();
        var products = product.GetProducts();
        var customer = new Customer();
        var customers = customer.RetriveCustomers();
    }
}