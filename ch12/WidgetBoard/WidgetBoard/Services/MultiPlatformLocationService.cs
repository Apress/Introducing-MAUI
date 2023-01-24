namespace WidgetBoard.Services;

public partial class MultiPlatformLocationService : ILocationService
{
#if !ANDROID && !IOS && !MACCATALYST && !WINDOWS
    public Task<Location> GetLocationAsync()
    {
        throw new NotImplementedException();
    }
#endif
}
