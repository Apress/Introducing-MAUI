using WidgetBoard.Services;

namespace WidgetBoard.SnapshotTests.Mocks;

internal class MockLocationService : ILocationService
{
    readonly Location? location;

    public MockLocationService(Location? mockLocation)
    {
        location = mockLocation;
    }

    public async Task<Location?> GetLocationAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));

        return this.location;
    }
}
