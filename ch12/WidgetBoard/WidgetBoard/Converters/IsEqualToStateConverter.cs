using System.Globalization;
using WidgetBoard.ViewModels;

namespace WidgetBoard.Converters;

public class IsEqualToStateConverter : IValueConverter
{
    public State State { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is State state)
        {
            return state == State;
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
