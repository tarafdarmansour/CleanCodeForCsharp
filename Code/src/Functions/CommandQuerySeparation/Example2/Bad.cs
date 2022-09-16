namespace CommandQuerySeparation.Example2;

public class BadIceCream
{
    private readonly List<int> temperatureReadings = new();
    private int currentTemperature; //Celsius degrees

    public int SetTemperature(int temperature)
    {
        if (temperature > 10) temperature = 10;
        temperatureReadings.Add(currentTemperature);
        currentTemperature = temperature;
        return currentTemperature;
    }

    public List<int> GetTemperatureReadings()
    {
        temperatureReadings.Add(currentTemperature);
        if (currentTemperature > 10) Alert(currentTemperature);

        return temperatureReadings;
    }

    public void Alert(int temperature)
    {
        Console.WriteLine($"Ice Cream Machine too warm. Temperature: {temperature}");
    }
}