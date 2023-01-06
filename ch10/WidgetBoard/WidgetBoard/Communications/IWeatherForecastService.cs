using Refit;

namespace WidgetBoard.Communications;

public interface IWeatherForecastService
{
    [Get("/onecall?lat={latitude}&lon={longitude}&units=metric&exclude=minutely,hourly,daily,alerts&appid=APIKEY")]
    Task<Forecast> GetForecast(double latitude, double longitude);
}
