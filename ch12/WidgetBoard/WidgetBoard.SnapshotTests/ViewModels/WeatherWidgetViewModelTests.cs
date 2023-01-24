using WidgetBoard.SnapshotTests.Mocks;
using WidgetBoard.ViewModels;

namespace WidgetBoard.SnapshotTests.ViewModels;

[UsesVerify]
public class WeatherWidgetViewModelTests
{
    [Fact]
    public async Task NullLocationResultsInPermissionErrorState()
    {
        var viewModel = new WeatherWidgetViewModel(
            new MockWeatherForecastService(null),
            new MockLocationService(null));

        await viewModel.InitializeAsync();

        await Verify(viewModel);
    }

    [Fact]
    public async Task NullForecastResultsInErrorState()
    {
        var viewModel = new WeatherWidgetViewModel(
            new MockWeatherForecastService(null),
            new MockLocationService(new Location(0.0, 0.0)));

        await viewModel.InitializeAsync();

        await Verify(viewModel);
    }

    [Fact]
    public async Task NullForecaseResultsInErrorState()
    {
        var viewModel = new WeatherWidgetViewModel(
            new MockWeatherForecastService(new Communications.Forecast
            {
                Current = new Communications.Current
                {
                    Temperature = 18.0,
                    Weather = new Communications.Weather[]
                    {
                        new Communications.Weather
                        {
                            Icon = "abc.png",
                            Main = "Sunshine"
                        }
                    }
                }
            }),
            new MockLocationService(new Location(0.0, 0.0)));

        await viewModel.InitializeAsync();

        await Verify(viewModel);
    }
}
