using RevitAPI_Task_10_1_TreePlacement.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace RevitAPI_Task_10_1_TreePlacement.ViewModels
{
    internal class TreeTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TreeType type)
            {
                switch (type)
                {
                    case TreeType.Tropical:
                        return "Тропическое";
                    case TreeType.Сoniferous:
                        return "Хвойное";
                    case TreeType.Deciduous:
                        return "Лиственное";
                    case TreeType.Bush:
                        return "Куст";
                    default:
                        return value != null ? value.ToString() : string.Empty;
                }
            }

            return value != null ? value.ToString() : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                switch (str)
                {
                    case "Тропическое":
                        return TreeType.Tropical;
                    case "Хвойное":
                        return TreeType.Сoniferous;
                    case "Лиственное":
                        return TreeType.Deciduous;
                    case "Куст":
                        return TreeType.Bush;
                    default:
                        throw new ArgumentException(string.Format("Неизвестный вид дерева: {0}", str));
                }
            }

            throw new ArgumentException("Некорректное значение для конвертации");
        }
    }
}
