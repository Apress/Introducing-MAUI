using WidgetBoard.Services;
using Xunit;

namespace WidgetBoard.DeviceTests.Services;

public class PlatformLocationServiceTests
{
    [Fact]
    public async Task GetLocationAsyncWillReturnPlatformSpecificLocation()
    {
        var locationService = new PlatformLocationService();

        var location = await locationService.GetLocationAsync();

#if ANDROID
        Assert.Equal(37.419857, location.Latitude);
        Assert.Equal(-122.078827, location.Longitude);
#elif WINDOWS
        Assert.Equal(47.639722, location.Latitude);
        Assert.Equal(-122.128333, location.Longitude);
#else
        Assert.Equal(37.334722, location.Latitude);
        Assert.Equal(-122.008889, location.Longitude);
#endif
    }
}
