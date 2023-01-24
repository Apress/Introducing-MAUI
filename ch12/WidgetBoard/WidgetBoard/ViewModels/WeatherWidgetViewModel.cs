using System.Windows.Input;
using Microsoft.Maui.ApplicationModel;
using WidgetBoard.Communications;
using WidgetBoard.Services;

namespace WidgetBoard.ViewModels;

public class WeatherWidgetViewModel : BaseViewModel, IWidgetViewModel
{
    public const string DisplayName = "Weather";

    readonly IWeatherForecastService weatherForecastService;
    readonly ILocationService locationService;
    string iconUrl;
    State state;
    double temperature;
    string weather;

    public ICommand LoadWeatherCommand { get; }

    public string IconUrl
    {
        get => iconUrl;
        set => SetProperty(ref iconUrl, value);
    }

    public State State
    {
        get => state;
        set => SetProperty(ref state, value);
    }

    public double Temperature
    {
        get => temperature;
        set => SetProperty(ref temperature, value);
    }

    public string Weather
    {
        get => weather;
        set => SetProperty(ref weather, value);
    }

    public WeatherWidgetViewModel(
        IWeatherForecastService weatherForecastService,
        ILocationService locationService)
	{
        this.weatherForecastService = weatherForecastService;
        this.locationService = locationService;
        LoadWeatherCommand = new Command(async () => await LoadWeatherForecast());

        Task.Run(async () => await LoadWeatherForecast());
    }

    public int Position { get; set; }

    public string Type => DisplayName;

    private async Task LoadWeatherForecast()
    {
        State = State.Loading;

        try
        {
            var location = await this.locationService.GetLocationAsync();

            // Something cleaner here?
            if (location is null)
            {
                State = State.PermissionError;
                return;
            }

            var forecast = await weatherForecastService.GetForecast(location.Latitude, location.Longitude);

            Temperature = forecast.Current.Temperature;
            Weather = forecast.Current.Weather.First().Main;
            IconUrl = forecast.Current.Weather.First().IconUrl;

            State = State.Loaded;
        }
        catch (Exception ex)
        {
            State = State.Error;
        }
    }
}
