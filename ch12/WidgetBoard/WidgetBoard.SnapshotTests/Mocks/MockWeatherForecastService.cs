using WidgetBoard.Communications;

namespace WidgetBoard.SnapshotTests.Mocks;

internal class MockWeatherForecastService : IWeatherForecastService
{
    readonly Forecast? forecast;

    public MockWeatherForecastService(Forecast? forecast)
    {
        this.forecast = forecast;
    }

    public async Task<Forecast?> GetForecast(double latitude, double longitude)
    {
        await Task.Delay(TimeSpan.FromSeconds(5));

        return forecast;
    }
}
