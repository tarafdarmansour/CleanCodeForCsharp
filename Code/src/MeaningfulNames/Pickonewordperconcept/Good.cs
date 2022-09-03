namespace Pickonewordperconcept.Good;

public class Product
{
    public List<Product> GetProducts()
    {
        throw new NotImplementedException();
    }
}

public class Customer
{
    public List<Customer> GetCustomers()
    {
        throw new NotImplementedException();
    }
}

public class Device
{
    public List<Device> GetDevices()
    {
        throw new NotImplementedException();
    }
}

public class Main
{
    public void CallMethods()
    {
        var device = new Device();
        var devices = device.GetDevices();
        var product = new Product();
        var products = product.GetProducts();
        var customer = new Customer();
        var customers = customer.GetCustomers();
    }
}