
using System;
using Windows.UI.Xaml.Data;

namespace FxApp.Converters
{
    public class StringFormatInsertSpaceConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value?.ToString().Insert(3," ");
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            string language)
        {
            throw new NotImplementedException();
        }
    }
}
