using Newtonsoft.Json;

namespace OneLevelofAbstractionperFunction.Example1;

public class GoodParseWeatherData
{
    public List<WeatherDataDto> GetWeatherReport()
    {
        var weatherDtoList = new List<WeatherDataDto>();

        var weatherReport = ReadWeatherReport();

        if (IsValidWeatherReport(weatherReport)) MapToReportDto(weatherDtoList, weatherReport);

        return weatherDtoList;
    }

    private static WeatherDataModel[] ReadWeatherReport()
    {
        return JsonConvert.DeserializeObject<WeatherDataModel[]>(File.ReadAllText("weather.json"));
    }

    private static bool IsValidWeatherReport(WeatherDataModel[] weatherReport)
    {
        return weatherReport != null && weatherReport.Length > 0;
    }

    private static void MapToReportDto(List<WeatherDataDto> weatherDtoList, WeatherDataModel[] weatherReport)
    {
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
    }
}