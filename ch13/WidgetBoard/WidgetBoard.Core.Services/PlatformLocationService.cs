namespace WidgetBoard.Services;

public class PlatformLocationService : ILocationService
{
    public Task<Location> GetLocationAsync()
    {
        Location location;

#if ANDROID
        location = new Location(37.419857, -122.078827);
#elif WINDOWS
        location = new Location(47.639722, -122.128333);
#else
        location = new Location(37.334722, -122.008889);
#endif

        return Task.FromResult(location);
    }
}
