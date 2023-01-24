using System.Text.Json;

namespace WidgetBoard.Communications;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly HttpClient httpClient;
    private const string ApiKey = "APIKEY";
    private const string ServerUrl = "https://api.openweathermap.org/data/2.5/onecall?";

    public WeatherForecastService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<Forecast> GetForecast(double latitude, double longitude)
    {
        var response = await httpClient
            .GetAsync($"{ServerUrl}lat={latitude}&lon={longitude}&units=metric&exclude=minutely,hourly,daily,alerts&appid={ApiKey}")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        var stringContent = await response.Content.ReadAsStringAsync();

        //var stringContent = "{\"lat\":20.7984,\"lon\":-156.3319,\"timezone\":\"Pacific/Honolulu\",\"timezone_offset\":-36000,\"current\":{\"dt\":1663101650,\"sunrise\":1663085531,\"sunset\":1663129825,\"temp\":20.77,\"feels_like\":21.15,\"pressure\":1017,\"humidity\":86,\"dew_point\":18.34,\"uvi\":7.89,\"clouds\":75,\"visibility\":10000,\"wind_speed\":5.66,\"wind_deg\":70,\"weather\":[{\"id\":501,\"main\":\"Rain\",\"description\":\"moderate rain\",\"icon\":\"10d\"}],\"rain\":{\"1h\":1.78}}}";

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<Forecast>(stringContent, options);
    }
}
