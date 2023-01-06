using System;
using System.ComponentModel;

namespace WidgetBoard.ViewModels;

public class ClockWidgetViewModel : BaseViewModel, IWidgetViewModel
{
    private readonly Scheduler scheduler = new();
    private DateOnly date;
    private TimeOnly time;

    public ClockWidgetViewModel()
    {
        SetTime(DateTime.Now);
    }

    public DateOnly Date
    {
        get => date;
        set => SetProperty(ref date, value);
    }

    public TimeOnly Time
    {
        get => time;
        set => SetProperty(ref time, value);
    }

    private void SetTime(DateTime dateTime)
    {
        Date = DateOnly.FromDateTime(dateTime);
        Time = TimeOnly.FromDateTime(dateTime);

        scheduler.ScheduleAction(
            TimeSpan.FromSeconds(1),
            () =>
            {
                SetTime(DateTime.Now);
            });
    }

}
