namespace CommandQuerySeparation.Example2;

public class GoodIceCream
{
    private int currentTemperature; //Celsius degrees
    private readonly List<int> temperatureReadings = new();

    public void SetTemperature(int temperature) // commands should return void
    {
        if (temperature > 10) temperature = 10;
        temperatureReadings.Add(currentTemperature);
        currentTemperature = temperature;
    }

    public int GetCurrentTemperature() //add a new method to return the current temperature
    {
        return currentTemperature;
    }

    public void StartMonitor()
    {
        //start an async job that will monitor the current temperature and send an alert 
        if (currentTemperature > 10) Alert(currentTemperature);
    }

    public List<int> GetTemperatureReadings() //removed call to alert
    {
        temperatureReadings.Add(currentTemperature);
        return temperatureReadings;
    }

    public void Alert(int temperature)
    {
        Console.WriteLine($"Ice Cream Machine too warm. Temperature: {temperature}");
    }
}