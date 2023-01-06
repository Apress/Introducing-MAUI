namespace WidgetBoard.Services;

public partial class MultiPlatformLocationService
{
    public Task<Location> GetLocationAsync()
    {
        return Task.FromResult(new Location(37.419857, -122.078827));
    }
}
