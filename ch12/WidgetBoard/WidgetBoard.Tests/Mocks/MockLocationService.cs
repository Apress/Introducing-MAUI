using WidgetBoard.Services;

namespace WidgetBoard.Tests.Mocks;

internal class MockLocationService : ILocationService
{
    readonly Location? location;
    private readonly TimeSpan delay;

    private MockLocationService(Location? mockLocation, TimeSpan delay)
    {
        location = mockLocation;
        this.delay = delay;
    }

    internal static ILocationService ThatReturns(Location? location, TimeSpan after) =>
        new MockLocationService(location, after);

    internal static ILocationService ThatReturnsNoLocation(TimeSpan after) =>
        new MockLocationService(null, after);

    public async Task<Location?> GetLocationAsync()
    {
        await Task.Delay(this.delay);

        return this.location;
    }
}
