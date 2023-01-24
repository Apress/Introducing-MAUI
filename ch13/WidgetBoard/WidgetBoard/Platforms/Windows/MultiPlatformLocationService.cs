namespace WidgetBoard.Services;

public partial class MultiPlatformLocationService
{
    public Task<Location> GetLocationAsync()
    {
        return Task.FromResult(new Location(47.639722, -122.128333));
    }
}
