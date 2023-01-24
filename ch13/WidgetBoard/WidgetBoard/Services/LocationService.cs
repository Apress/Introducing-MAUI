namespace WidgetBoard.Services;

public class LocationService : ILocationService
{
    readonly IGeolocation geolocation;

    public LocationService(IGeolocation geolocation)
    {
        this.geolocation = geolocation;
    }

    public async Task<Location> GetLocationAsync()
    {
        return await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            var status = await CheckAndRequestLocationPermission();

            if (status != PermissionStatus.Granted)
            {
                return null;
            }

            return await this.geolocation.GetLocationAsync();
        });
    }

    private async Task<PermissionStatus> CheckAndRequestLocationPermission()
    {
        PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

        if (status == PermissionStatus.Granted)
        {
            return status;
        }

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // Prompt the user to turn on in settings
            // On iOS once a permission has been denied it may not be requested again from the application
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
        {
            // Prompt the user with additional information as to why the permission is needed
        }

        status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

        return status;
    }
}
