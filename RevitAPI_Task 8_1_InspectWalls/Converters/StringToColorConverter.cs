using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace RevitAPI_Task_8_1_InspectWalls.Converters
{
    /// <summary>
    /// Преобразует строковое представление цвета в объект Color для привязки в XAML.
    /// </summary>
    public class StringToColorConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует строку в цвет. При ошибке возвращает серый цвет.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string colorString)
            {
                try
                {
                    return (Color)ColorConverter.ConvertFromString(colorString);
                }
                catch
                {
                    return Colors.Gray;
                }
            }
            return Colors.Gray;
        }

        /// <summary>
        /// Обратное преобразование не реализовано.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
