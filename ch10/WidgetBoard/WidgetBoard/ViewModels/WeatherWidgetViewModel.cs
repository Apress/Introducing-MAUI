using System.Windows.Input;
using WidgetBoard.Communications;

namespace WidgetBoard.ViewModels;

public class WeatherWidgetViewModel : BaseViewModel, IWidgetViewModel
{
    public const string DisplayName = "Weather";

    readonly IWeatherForecastService weatherForecastService;
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

    public WeatherWidgetViewModel(IWeatherForecastService weatherForecastService)
	{
        this.weatherForecastService = weatherForecastService;

        LoadWeatherCommand = new Command(async () => await LoadWeatherForecast());

        Task.Run(async () => await LoadWeatherForecast());
    }

    public int Position { get; set; }

    public string Type => DisplayName;

    private async Task LoadWeatherForecast()
    {
        try
        {
            State = State.Loading;

            var forecast = await weatherForecastService.GetForecast(20.798363, -156.331924);

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

public enum State
{
    None = 0,
    Loading = 1,
    Loaded = 2,
    Error = 3
}