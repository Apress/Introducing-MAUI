using WidgetBoard.Communications;

namespace WidgetBoard.Tests.Mocks;

internal class MockWeatherForecastService : IWeatherForecastService
{
    readonly Forecast? forecast;
    private readonly TimeSpan delay;

    private MockWeatherForecastService(Forecast? forecast, TimeSpan delay)
    {
        this.forecast = forecast;
        this.delay = delay;
    }

    internal static IWeatherForecastService ThatReturns(Forecast? forecast, TimeSpan after) =>
        new MockWeatherForecastService(forecast, after);

    internal static IWeatherForecastService ThatReturnsNoForecast(TimeSpan after) =>
        new MockWeatherForecastService(null, after);

    public async Task<Forecast?> GetForecast(double latitude, double longitude)
    {
        await Task.Delay(this.delay);

        return forecast;
    }
}
