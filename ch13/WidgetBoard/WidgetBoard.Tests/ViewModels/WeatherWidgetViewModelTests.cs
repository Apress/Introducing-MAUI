using WidgetBoard.Tests.Mocks;
using WidgetBoard.ViewModels;

namespace WidgetBoard.Tests.ViewModels;

public class WeatherWidgetViewModelTests
{
    [Fact]
    public async Task NullLocationResultsInPermissionErrorState()
    {
        var viewModel = new WeatherWidgetViewModel(
            MockWeatherForecastService.ThatReturnsNoForecast(after: TimeSpan.FromSeconds(5)),
            MockLocationService.ThatReturnsNoLocation(after: TimeSpan.FromSeconds(2)));

        await viewModel.InitializeAsync();

        Assert.Equal(State.PermissionError, viewModel.State);
        Assert.Null(viewModel.Weather);
    }

    [Fact]
    public async Task NullForecastResultsInErrorState()
    {
        var viewModel = new WeatherWidgetViewModel(
            MockWeatherForecastService.ThatReturnsNoForecast(after: TimeSpan.FromSeconds(5)),
            MockLocationService.ThatReturns(new Location(0.0, 0.0), after: TimeSpan.FromSeconds(2)));

        await viewModel.InitializeAsync();

        Assert.Equal(State.Error, viewModel.State);
        Assert.Null(viewModel.Weather);
    }

    [Fact]
    public async Task ValidForecastResultsInSuccessfulLoad()
    {
        var weatherForecastService = MockWeatherForecastService.ThatReturns(
                new Communications.Forecast
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
                },
                after: TimeSpan.FromSeconds(5));
        var locationService = MockLocationService.ThatReturns(
                new Location(0.0, 0.0),
                after: TimeSpan.FromSeconds(2));

        var viewModel = new WeatherWidgetViewModel(
            weatherForecastService,
            locationService);

        await viewModel.InitializeAsync();

        Assert.Equal(State.Loaded, viewModel.State);
        Assert.Equal("Sunshine", viewModel.Weather);
    }
}
