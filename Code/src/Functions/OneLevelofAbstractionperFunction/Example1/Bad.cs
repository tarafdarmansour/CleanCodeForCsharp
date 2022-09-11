using Newtonsoft.Json;

namespace OneLevelofAbstractionperFunction.Example1;

public class BadParseWeatherData
{
    public List<WeatherDataDto> GetWeatherReport()
    {
        var weatherDtoList = new List<WeatherDataDto>();

        var weatherReport = JsonConvert.DeserializeObject<WeatherDataModel[]>(File.ReadAllText("weather.json"));

        if (weatherReport != null && weatherReport.Length > 0)
            foreach (var report in weatherReport)
            {
                var weatherDto = new WeatherDataDto
                {
                    City = report.city,
                    Temparature = report.temp,
                    ReportedBy = report.reportedBy
                };
                weatherDtoList.Add(weatherDto);
            }

        return weatherDtoList;
    }
}