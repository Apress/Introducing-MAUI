namespace WidgetBoard.Services;

public interface ILocationService
{
    Task<Location> GetLocationAsync();
}
